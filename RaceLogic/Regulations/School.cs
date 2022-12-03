using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;
namespace RaceLogic
{
    public class School
    {
        private static List<Pilot> pilots = new List<Pilot>();
        private static int totalPilots;
        public static int TotalRacesCount;
        public static int maxKarts;

        public static void DoRace(List<int> numbersKarts)
        {
            int numberRace;
            try
            {
                numberRace = pilots[0].GetNumbersKarts().Count;
            }
            catch (Exception)
            {
                numberRace = 0;
            }

            pilots.Clear();
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            foreach (var pilotName in pilotsNames)
                pilots.Add(new Pilot(pilotName));
            totalPilots = pilots.Count;

            pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            Race.StartFinalRace(pilots, numbersKarts, numberRace);
            ExcelWorker.WriteUsedKarts(pilots);
        }

        public static void ReadTime()
        {
            pilots = ExcelWorker.ReadTimeInRace(pilots);
            ExcelWorker.WriteTimeInTotalBoard(pilots);
        }

        public static void ReBuildPilots()
        {
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            pilots = Race.MakePilotsFromTotalBoard(pilotsNames.Count);
            totalPilots = pilots.Count;
        }

        public static void SortTimeInTB()
        {
            var keyCells = ExcelWorker.FindKeyCellByValue("Best Lap", null);
            var range = ExcelWorker.GetTotalBoardRange(pilots.Count);

            for (int i = 0; i < keyCells.Count; i++)
            {
                range.Sort(range.Columns[keyCells[i].Column - 2], XlSortOrder.xlAscending);
            }
        }

        public static void SortTimeInRace()
        {
            var keyCells = ExcelWorker.FindKeyCellByValue("ВРЕМЯ", null);
            for (int i = 0; i < keyCells.Count; i++)
            {
                int j = 0;
                while (keyCells[i][1, j--].Value != null) { }
                var firstCellRow = keyCells[i].Row;
                var firstCellCol = keyCells[i][1, j].Column;

                Range rangeToSort = ExcelWorker.excel.Range[ExcelWorker.excel.Cells[firstCellRow + 1, firstCellCol + 1], keyCells[i][50]];


                rangeToSort.Sort(rangeToSort.Columns[(j - 1) * -1], XlSortOrder.xlAscending);
            }
        }
    }
}