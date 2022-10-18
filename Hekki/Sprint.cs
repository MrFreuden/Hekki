using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;
namespace Hekki
{
    internal class Sprint
    {
        private static List<Pilot> pilots = new List<Pilot>();
        private static int totalPilots;
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
            ExcelWorker.CleanData();

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
                pilots = Race.MakePilotsFromTotalBoard(Race.CountPilotsInFirstGroup);
                Race.StartFinalRace(pilots, numbersKarts, numberRace);
            }
            ExcelWorker.WriteUsedKarts(pilots);
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
                var lastCellRow = keyCells[i].Row + 32;
                var lastCellCol = keyCells[i].Column;

                Range rangeToSort = ExcelWorker.excel.Range[ExcelWorker.excel.Cells[firstCellRow + 1, firstCellCol + 1], keyCells[i][50]];


                rangeToSort.Sort(rangeToSort.Columns[(j - 1) * -1], XlSortOrder.xlDescending);
            }
        }

        public static void ReadScor()
        {
            pilots = ExcelWorker.ReadScoresInRace(pilots);
            ExcelWorker.WriteScoreInTotalBoard(pilots);
        }

        public static void ReBuildPilots()
        {
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            pilots = Race.MakePilotsFromTotalBoard(pilotsNames.Count);
            totalPilots = pilots.Count;
        }
    }
}
