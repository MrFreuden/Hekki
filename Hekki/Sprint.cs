using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;
namespace Hekki
{
    public class Sprint : Regulation
    {
        private static int proCountFinal;
        private static int amatorsCountFinal;
        public static int TotalRacesCount;
        public static int maxKarts;

        public void DoThreeRaces(List<int> numbersKarts)
        {
            pilots.Clear();
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            foreach (var pilotName in pilotsNames)
                pilots.Add(new Pilot(pilotName));
            totalPilots = pilots.Count;
            TotalRacesCount = totalPilots > 16 ? 3 : 4;

            for (int i = 0; i < 3; i++)
                Race.StartHeatRace(pilots, numbersKarts, i);

        }
        public void DoOneRace(List<int> numbersKarts)
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

        }

        public void DoNextRace(List<int> numbersKarts, int numberRace)
        {
            Race.ReBuildCountPilotsInFirstGroup(numbersKarts);
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
        }

        public void DoFinalAmators(List<int> numbersKarts, int numberRace)
        {
            Race.ReBuildCountPilotsInFirstGroup(numbersKarts);
            pilots = Race.MakePilotsFromTotalBoard(proCountFinal + amatorsCountFinal);
            for (int i = 0; i < proCountFinal; i++)
            {
                pilots.RemoveAt(0);
            }
            Race.StartFinalAmators(pilots, numbersKarts, numberRace);
        }

        public void WriteUsedKartsAmators()
        {
            var names = ExcelWorker.ReadNamesInTotalBoard();
            List<string> karts = new();
            foreach (var name in names)
            {
                var index = pilots.FindIndex(x => x.Name == name);
                if (index == -1)
                    continue;
                karts.Add(pilots[index].GetAllNumbersKarts());
            }
            ExcelWorker.WriteUsedKartsAmators(karts, proCountFinal);
        }

        public void SortTwoLiques(List<int> numbersKarts)
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

        public override void ReadScor()
        {
            var names = ExcelWorker.ReadNamesInTotalBoard();
            pilotsCount = names.Count;
            var scores = ExcelWorker.ReadScoresInRace(names);
            if (scores[0].Count > 5)
            {
                var amators = scores.Where(x => x[x.Count - 1] != "0").ToList();
                foreach (var pilotScores in amators)
                {
                    pilotScores.RemoveAt(pilotScores.Count - 2);
                }
                var others = scores.Where(x => x[x.Count - 1] == "0").ToList();
                foreach (var pilotScores in others)
                {
                    pilotScores.RemoveAt(pilotScores.Count - 1);
                }
            }
            ExcelWorker.WriteScoreInTotalBoard(scores);
            AddScoresToPilots(scores);

            
        }

        private void Test(List<Pilot> pNew)
        {
            foreach (var pilot in pNew)
            {
                pilot.DeleteScore(pilot.ScoresCount - 2);
            }
        }

        public void ReBuildPilots(List<int> numbersKarts)
        {
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            pilots = Race.MakePilotsFromTotalBoard(pilotsNames.Count);
            totalPilots = pilots.Count;
            Race.ReBuildCountPilotsInFirstGroup(numbersKarts);
            DefineCountPilotsInFinals();
        }

        private void DefineCountPilotsInFinals()
        {
            proCountFinal = Race.DefineCountPilotsInFinal(pilots, "Pro");
            amatorsCountFinal = Race.DefineCountPilotsInFinal(pilots, "Am");
        }
    }
}
