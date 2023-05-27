using ExcelController;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace RaceLogic.Regulations
{
    public class Sprint : Regulation
    {
        private static int proCountFinal;
        private static int amatorsCountFinal;
        private static int proCount;
        public static int TotalRacesCount;
        public static int maxKarts;

        public void DoOneRace(List<int> numbersKarts)
        {
            int numberRace = pilots[0].GetNumbersKarts().Count;
            pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            int countGroups = (int)Math.Ceiling((double)pilots.Count / numbersKarts.Count);
            Race.StartFinalRace(pilots, numbersKarts, numberRace);
        }

        public void DoQualRandom(List<int> numbersKarts)
        {
            pilots.Clear();
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            foreach (var pilotName in pilotsNames)
                pilots.Add(new Pilot(pilotName));
            totalPilots = pilots.Count;

            pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            Race.StartHeatRace(pilots, numbersKarts, 0);

        }

        public void DoQualByList(List<int> numbersKarts)
        {
            pilots.Clear();
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            foreach (var pilotName in pilotsNames)
                pilots.Add(new Pilot(pilotName));
            totalPilots = pilots.Count;

            pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            Race.StartFinalRace(pilots, numbersKarts, 0);

        }
        
        public void DoFinalPro(List<int> numbersKarts, int numberRace)
        {
            pilots = Race.MakePilotsFromTotalBoard(proCountFinal);
            Race.StartFinalRace(pilots, numbersKarts, numberRace);
        }

        public void DoFinalAmators(List<int> numbersKarts, int numberRace)
        {
            Race.ReBuildCountPilotsInFirstGroup(numbersKarts);
            pilots = Race.MakePilotsFromTotalBoard(proCount + amatorsCountFinal);
            for (int i = 0; i < proCount; i++)
            {
                pilots.RemoveAt(0);
            }
            Race.StartFinalRace(pilots, numbersKarts, numberRace);
        }

        public void WriteUsedKartsAmators()
        {
            WriteUsedKarts(proCount);
        }

        public void SortTwoLiques(List<int> numbersKarts)
        {
            if (totalPilots == 0) ReBuildPilots(numbersKarts);
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
            var c2 = rangeToSort.Columns[11];
            rangeToSort.Sort(c1, XlSortOrder.xlDescending, c2, Type.Missing, XlSortOrder.xlDescending);

            proCount = pilots.FindAll(x => x.Ligue == "Pro").Count;
            w += proCount;

            rangeToSort = ExcelWorker.excel.Range[firstCell + w.ToString(), lastCell];
            rangeToSort.Sort(c1, XlSortOrder.xlAscending, c2, Type.Missing, XlSortOrder.xlDescending);
        }

        public override List<List<string>> GetScores()
        {
            var scores = base.GetScores();
            if (scores[0].Count > 4)
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
            return scores;
        }

        public void ReBuildPilots(List<int> numbersKarts)
        {
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            pilots = Race.MakePilotsFromTotalBoard(pilotsNames.Count);
            totalPilots = pilots.Count;
            pilotsCount = pilots.Count;
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
