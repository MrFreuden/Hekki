using ExcelController;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace RaceLogic.Regulations
{
    public class EveryOnEvery : Regulation
    {
        public void DoRaces(List<int> numbersKarts)
        {
            pilots.Clear();
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            foreach (var pilotName in pilotsNames)
                pilots.Add(new Pilot(pilotName));
            totalPilots = pilots.Count;

            pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            Race.StartRandomRace(pilots, numbersKarts);

        }

        public List<List<string>> GetScores(List<int> numbersKarts)
        {
            var namesInOrder = ExcelWorker.ReadNamesInTotalBoard();
            pilotsCount = namesInOrder.Count;
            var scores = ExcelWorker.ReadScoresInRaceEveryOnEvery(pilotsCount, numbersKarts.Count, out int[] cols);
            var namesInRace = ExcelWorker.ReadNamesInRace(numbersKarts.Count, cols, 111);

            return GetSortedDataInOrdenNames(scores, namesInRace, namesInOrder, false);
        }

        public List<List<string>> GetTimesEvery(List<int> numbersKarts)
        {
            var namesInOrder = ExcelWorker.ReadNamesInTotalBoard();
            pilotsCount = namesInOrder.Count;
            var scores = ExcelWorker.ReadTimesInRaceEveryOnEvery(pilotsCount, numbersKarts.Count, out int[] cols);
            var namesInRace = ExcelWorker.ReadNamesInRace(numbersKarts.Count, cols, 180);

            return GetSortedDataInOrdenNames(scores, namesInRace, namesInOrder, false);
        }

        public void SortTimeDeadEvery()
        {
            string firstCell = "P199";
            var keyCell = ExcelWorker.FindKeyCellByValue("Усього", null);
            var address = keyCell[0].Address;
            string lastCell = "AA";
            lastCell += (198 + pilots.Count).ToString();

            Range rangeToSort = ExcelWorker.excel.Range[firstCell, lastCell];

            var s = rangeToSort.GetEnumerator();
            var c2 = rangeToSort.Columns[keyCell[0].Column - 15];
            rangeToSort.Sort(c2, XlSortOrder.xlAscending);
        }
    }
}
