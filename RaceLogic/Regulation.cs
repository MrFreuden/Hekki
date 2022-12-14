using ExcelController;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace RaceLogic
{
    public class Regulation
    {
        protected int pilotsCount;
        protected List<Pilot> pilots = new();
        protected int totalPilots;

        public virtual List<List<string>> GetTimes()
        {
            var namesInOrder = ExcelWorker.ReadNamesInTotalBoard();
            //var timesInRace = ExcelWorker.ReadTimesInRace(namesInOrder.Count, out int[] cols);
            var timesInRace = ExcelWorker.ReadDataInRace("Время", pilotsCount, out int[] cols);
            var namesInRace = ExcelWorker.ReadNamesInRace(namesInOrder.Count, cols);
            return GetSortedDataInOrdenNames(timesInRace, namesInRace, namesInOrder);
        }

        public void WriteTimes(List<List<string>> times)
        {
            ExcelWorker.WriteTimeInTotalBoard(times);
            AddTimesToPilots(times);
        }

        public virtual List<List<string>> GetScores()
        {
            var namesInOrder = ExcelWorker.ReadNamesInTotalBoard();
            pilotsCount = namesInOrder.Count;
            //var scoresInRace = ExcelWorker.ReadScoresInRace(pilotsCount, out int[] cols);
            var scoresInRace = ExcelWorker.ReadDataInRace("Итого", pilotsCount, out int[] cols);
            var namesInRace = ExcelWorker.ReadNamesInRace(pilotsCount, cols);
            return GetSortedDataInOrdenNames(scoresInRace, namesInRace, namesInOrder);
        }

        public void WriteScores(List<List<string>> score)
        {
            ExcelWorker.WriteScoreInTotalBoard(score);
            AddScoresToPilots(score);
        }

        public List<List<string>> GetSortedDataInOrdenNames(List<List<string>> data, 
            List<List<string>> namesInRace, 
            List<string> namesOrder,
            bool IsZeroScoreNeeded = true)
        {
            var sortedData = new List<List<string>>();
            for (int i = 0; i < namesOrder.Count; i++)
                sortedData.Add(new List<string>());

            for (int indexRace = 0; indexRace < data.Count; indexRace++)
            {
                for (int i = 0, j = 0; i < data[indexRace].Count; )
                {
                    int index = namesInRace[indexRace].FindIndex(x => x == namesOrder[j]);
                    if (index == -1)
                    {
                        j++;
                        continue;
                    }
                    sortedData[j].Add(data[indexRace][index]);
                    i++;
                    j++;
                }
                if (IsZeroScoreNeeded)
                {
                    var pilotsWithOutScore = sortedData.Where(x => x.Count < indexRace + 1).ToList();
                    for (int i = 0; i < pilotsWithOutScore.Count; i++)
                        pilotsWithOutScore[i].Add("0");
                }
            }
            return sortedData;
        }

        public virtual void WriteUsedKarts()
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
            ExcelWorker.WriteUsedKarts(karts);
        }

        public virtual void SortTimeInTB()
        {
            var keyCells = ExcelWorker.FindKeyCellByValue("Best Lap", null);
            var range = ExcelWorker.GetTotalBoardRange(pilots.Count);

            for (int i = 0; i < keyCells.Count; i++)
            {
                range.Sort(range.Columns[keyCells[i].Column - 2], XlSortOrder.xlAscending);
            }
        }

        public virtual void SortTimeInRace()
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

        public virtual void SortScores()
        {
            var keyCells = ExcelWorker.FindKeyCellByValue("ВСЕГО", null);

            for (int i = 0; i < keyCells.Count; i++)
            {
                int j = 0;
                while (keyCells[i][1, j--].Value != null) { }
                var firstCellRow = keyCells[i].Row;
                var firstCellCol = keyCells[i][1, j].Column;

                Range rangeToSort = ExcelWorker.excel.Range[ExcelWorker.excel.Cells[firstCellRow + 1, firstCellCol + 1], keyCells[i][pilotsCount + 1]];
                rangeToSort.Sort(rangeToSort.Columns[(j - 1) * -1], XlSortOrder.xlDescending);
            }
        }

        public virtual void ReBuildPilots()
        {
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            pilots = Race.MakePilotsFromTotalBoard(pilotsNames.Count);
            totalPilots = pilots.Count;
        }

        protected void AddTimesToPilots(List<List<string>> data)
        {
            for (int i = 0; i < data[0].Count; i++)
            {
                for (int j = 0; j < data.Count; j++)
                {
                    pilots[j].AddTime(data[j][i]);
                }
            }
        }

        protected void AddScoresToPilots(List<List<string>> data)
        {
            for (int i = 0; i < data[0].Count; i++)
            {
                for (int j = 0; j < pilots.Count; j++) //data.Count
                {
                    pilots[j].AddScore(data[j][i]);
                }
            }
        }
    }
}
