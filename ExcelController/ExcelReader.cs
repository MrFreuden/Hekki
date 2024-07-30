using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController
{
    public class ExcelReader : IExcelReader
    {
        private readonly Application _excel;
        private readonly IExcelHelper _excelHelper;

        public ExcelReader(Application excel, IExcelHelper excelHelper)
        {
            _excel = excel;
        }

        public List<string> ReadNamesInBoard()
        {
            var keyCells = _excelHelper.FindKeyCellByValue("Ім'я", null);
            List<string> names = new();

            int i = 2;
            while (keyCells[0].Cells[i].Value != null)
            {
                names.Add(keyCells[0].Cells[i].Value.ToString());
                i++;
            }
            return names;
        }

        public List<List<int>> ReadColScoresInBoard(int countRows)
        {
            var keyCells = _excelHelper.FindKeyCellByValue("Хіт", _excelHelper.GetHeadersTB());
            if (keyCells.Count == 0)
            {
                return new List<List<int>>();
            }
            List<List<int>> data = new();

            int i = 0;
            int k = 1;

            for (int j = 0; j < countRows; j++)
            {
                data.Add(new List<int>());
                for (int q = 0; q < keyCells.Count; q++)
                {
                    int number;
                    if (keyCells[q].Cells[1 + k].Value == null)
                        continue;
                    else
                        number = keyCells[q].Cells[1 + k].Value.ToString();
                    data[i].Add(number);
                }
                i++;
                k++;
            }
            return data;
        }

        public List<int> ReadColScoresInRace(int countRows, int startRow)
        {
            var keyCells = _excelHelper.FindKeyCellByValue("Разом", null);
            var scores = new List<int>();
            for (int i = startRow; i < countRows; i++)
            {
                scores.Add(_excel.Cells[i, keyCells[0].Column].Value);
            }
            return scores;
        }

        private List<List<int>> ReadColumnsWithOffset(IList<Range> columns, int countRows, int offset)
        {
            var pilotsData = new List<List<int>>();

            for (int j = 0; j < columns.Count; j++)
            {
                pilotsData.Add(new List<int>());
                var startIndexKey = columns[j].Row + 1;

                for (int i = 0; i < countRows && startIndexKey < countBreaker; startIndexKey++)
                {
                    if (Convert.ToString(_excel.Cells[startIndexKey, columnIndexName].Value) == null)
                        continue;
                    var val = Convert.ToString(_excel.Cells[startIndexKey, columns[j].Column].Value);

                    pilotsData[j].Add(val);
                    i++;
                }
            }
            return pilotsData;
        }

        public List<List<int>> ReadColTimesInBoard(int countRows)
        {
            var keyCells = _excelHelper.FindKeyCellByValue("Best Lap", _excelHelper.GetHeadersTB());
            if (keyCells.Count == 0)
            {
                return new List<List<int>>();
            }
            List<List<int>> data = new();

            int i = 0;
            int k = 1;

            for (int j = 0; j < countRows; j++)
            {
                data.Add(new List<int>());
                for (int q = 0; q < keyCells.Count; q++)
                {
                    int number;
                    if (keyCells[q].Cells[1 + k].Value == null)
                        continue;
                    else
                        number = keyCells[q].Cells[1 + k].Value.ToString();
                    data[i].Add(number);
                }
                i++;
                k++;
            }
            return data;
        }

        public List<int> ReadColTimesInRace(int countRows, int startRow)
        {
            var pilotsData = new List<List<string>>();
            var keyCells = FindKeyCellByValue(keyWord, null);
            cols = new int[keyCells.Count];
            for (int j = 0; j < keyCells.Count; j++)
            {
                var startIndexKey = keyCells[j].Row + 1;
                int columnIndexName = GetIndexNearColLeft("Пілоти", keyCells[j].Row, keyCells[j][startIndexKey - 1].Column);
                cols[j] = columnIndexName;

                if (Convert.ToString(excel.Cells[startIndexKey, columnIndexName].Value) == null)
                    continue;
                pilotsData.Add(new List<string>());
                for (int i = 0; i < pilotsCount && startIndexKey < countBreaker; startIndexKey++)
                {
                    if (Convert.ToString(excel.Cells[startIndexKey, columnIndexName].Value) == null)
                        continue;
                    var val = Convert.ToString(excel.Cells[startIndexKey, keyCells[j].Column].Value);

                    pilotsData[j].Add(val);
                    i++;
                }
            }
            return pilotsData;
        }

        public List<List<int>> ReadUsedKartsInBoard()
        {
            var keyCells = _excelHelper.FindKeyCellByValue("Номера", null);
            if (keyCells.Count == 0)
                return new List<List<int>>();
            List<List<int>> karts = new();

            int i = 2;
            int q = 0;

            while (keyCells[0].Cells[i].Value != null)
            {
                karts.Add(new List<int>());

                string numbers = keyCells[0].Cells[i, 1].Value.ToString();
                var splitedNumbers = numbers.Split(' ').ToList();
                if (string.IsNullOrEmpty(splitedNumbers[splitedNumbers.Count - 1]))
                {
                    splitedNumbers.RemoveAt(splitedNumbers.Count - 1);
                }
                for (int j = 0, k = 0; j < splitedNumbers.Count; j++, k++)
                {
                    karts[q].Add(Int32.Parse(splitedNumbers[k]));
                }
                i++;
                q++;
            }

            return karts;
        }

        public List<string> ReadLiquesInBoard()
        {
            throw new NotImplementedException();
        }

        public List<List<int>> ReadUsedKartsInRace()
        {
            throw new NotImplementedException();
        }

        public List<List<string>> ReadNamesInRace()
        {
            throw new NotImplementedException();
        }
    }
}
