using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace Hekki
{
    public class Regulation
    {
        protected int pilotsCount;
        protected List<Pilot> pilots = new();
        protected int totalPilots;

        public virtual void ReadTime()
        {
            var names = ExcelWorker.ReadNamesInTotalBoard();
            var times = ExcelWorker.ReadTimeInRace(names);

            ExcelWorker.WriteTimeInTotalBoard(times);
            AddTimesToPilots(times);
        }

        public virtual void ReadScor()
        {
            //pilots = Race.MakePilotsFromTotalBoard(totalPilots);
            var names = ExcelWorker.ReadNamesInTotalBoard();
            pilotsCount = names.Count;
            var scores = ExcelWorker.ReadScoresInRace(names);

            ExcelWorker.WriteScoreInTotalBoard(scores);
            AddScoresToPilots(scores);
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
