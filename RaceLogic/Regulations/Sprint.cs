using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;
namespace RaceLogic
{
    public class Sprint
    {
        private static List<Pilot> pilots = new();
        private static int totalPilots;
        private static int proCountFinal;
        private static int amatorsCountFinal;
        public static int TotalRacesCount;
        public static int maxKarts;

        public static void DoThreeRaces(List<int> numbersKarts)
        {
            pilots.Clear();
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            foreach (var pilotName in pilotsNames)
                pilots.Add(new Pilot(pilotName));
            totalPilots = pilots.Count;
            TotalRacesCount = totalPilots > 16 ? 3 : 4;
            //ExcelWorker.CleanData();

            for (int i = 0; i < 3; i++)
                Race.StartHeatRace(pilots, numbersKarts, i);

            ExcelWorker.WriteUsedKarts(pilots);
        }
        public static void DoOneRace(List<int> numbersKarts)
        {
            pilots.Clear();
            Race.ReBuildCountPilotsInFirstGroup(numbersKarts);
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            foreach (var pilotName in pilotsNames)
                pilots.Add(new Pilot(pilotName));
            pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            totalPilots = pilots.Count;
            TotalRacesCount = totalPilots > 16 ? 3 : 4;

            Race.StartHeatRace(pilots, numbersKarts, pilots[0].KartsCount);

            ExcelWorker.WriteUsedKarts(pilots);
        }

        public static void DoNextRace(List<int> numbersKarts, int numberRace)
        {
            Race.ReBuildCountPilotsInFirstGroup(numbersKarts);
            //int numberRace = pilots.Count >= 17 ? 3 : 4;
            if (numberRace == 3)
            {
                pilots = Race.MakePilotsFromTotalBoard(Race.CountPilotsInFirstGroup * 2);
                Race.StartSemiRace(pilots, numbersKarts, numberRace);
            }
            else
            {
                if (pilots.Count < 19)
                {
                    var k1 = ExcelWorker.FindKeyCellByValue("Карт", null);
                    var k2 = ExcelWorker.FindKeyCellByValue("Пилоты", null);
                    k1[3][2] = 0.ToString();
                    k2[3][2] = 0.ToString();
                }
                pilots = Race.MakePilotsFromTotalBoard(proCountFinal);
                Race.StartFinalRace(pilots, numbersKarts, numberRace);
            }
            ExcelWorker.WriteUsedKarts(pilots);
        }

        public static void DoFinalAmators(List<int> numbersKarts, int numberRace)
        {
            Race.ReBuildCountPilotsInFirstGroup(numbersKarts);
            pilots = Race.MakePilotsFromTotalBoard(proCountFinal + amatorsCountFinal);
            for (int i = 0; i < proCountFinal; i++)
            {
                pilots.RemoveAt(0);
            }
            Race.StartFinalAmators(pilots, numbersKarts, numberRace);
            ExcelWorker.WriteUsedKartsAmators(pilots, proCountFinal);
        }

        public static void Sort()
        {
            var keyCells = ExcelWorker.FindKeyCellByValue("ВСЕГО", null);

            for (int i = 0; i < keyCells.Count; i++)
            {
                int j = 0;
                while (keyCells[i][1, j--].Value != null) { }
                var firstCellRow = keyCells[i].Row;
                var firstCellCol = keyCells[i][1, j].Column;

                Range rangeToSort = ExcelWorker.excel.Range[ExcelWorker.excel.Cells[firstCellRow + 1, firstCellCol + 1], keyCells[i][50]];


                rangeToSort.Sort(rangeToSort.Columns[(j - 1) * -1], XlSortOrder.xlDescending);
            }
        }

        public static void SortTwoLiques(List<int> numbersKarts)
        {
            pilots = Race.MakePilotsFromTotalBoard(totalPilots);
            DefineCountPilotsInFinals();

            string firstCell = "C";
            var keyCell = ExcelWorker.FindKeyCellByValue("ВСЕГО", null);
            var address = keyCell[0].Address;
            string lastCell = address[1].ToString();
            lastCell += (3 + pilots.Count).ToString();
            int w = 4;

            Range rangeToSort = ExcelWorker.excel.Range[firstCell + w.ToString(), lastCell];
            var c1 = rangeToSort.Columns[1];
            var c2 = rangeToSort.Columns[9];
            rangeToSort.Sort(c1, XlSortOrder.xlDescending, c2, Type.Missing, XlSortOrder.xlDescending);

            w += proCountFinal;

            rangeToSort = ExcelWorker.excel.Range[firstCell + w.ToString(), lastCell];
            rangeToSort.Sort(c1, XlSortOrder.xlAscending, c2, Type.Missing, XlSortOrder.xlDescending);

            w += amatorsCountFinal;

            rangeToSort = ExcelWorker.excel.Range[firstCell + w.ToString(), lastCell];
            rangeToSort.Sort(c2, XlSortOrder.xlDescending);
        }

        public static void ReadScor(List<int> numbersKarts)
        {
            pilots = Race.MakePilotsFromTotalBoard(totalPilots);
            pilots = ExcelWorker.ReadScoresInRace(pilots);
            var pNew = pilots.Where(x => x.ScoresCount > 5).ToList();
            if (pNew.Count > 0)
            {
                pNew = pNew.Where(x => x.GetScoreByNumberRace(x.ScoresCount - 1) != 0).ToList();
                Test(pNew);
            }
            ExcelWorker.WriteScoreInTotalBoard(pilots);
        }

        private static void Test(List<Pilot> pNew)
        {
            foreach (var pilot in pNew)
            {
                pilot.DeleteScore(pilot.ScoresCount - 2);
            }
        }

        public static void ReBuildPilots(List<int> numbersKarts)
        {
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            pilots = Race.MakePilotsFromTotalBoard(pilotsNames.Count);
            totalPilots = pilots.Count;
            Race.ReBuildCountPilotsInFirstGroup(numbersKarts);
            DefineCountPilotsInFinals();
        }

        private static void DefineCountPilotsInFinals()
        {
            proCountFinal = Race.DefineCountPilotsInFinal(pilots, "Pro");
            amatorsCountFinal = Race.DefineCountPilotsInFinal(pilots, "Am");
        }
    }
}