using ExcelController.Interfaces;
using RaceLogic.Interfaces;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace RaceLogic.Services
{
    public class RaceDataService : IRaceDataService
    {
        public const int StartRowByDefault = 4;
        public const int EndRowByDefault = 53;
        public const int MaxKarts = 10;
        private readonly IExcelWorker _excelWorker;
        private Dictionary<string, List<int>> _keyCellsColumnNumbers;
        private List<string> _headers = new()
            {
                { "Номера" },
                { "Best Lap" },
                { "ХІТ" },
                { "Карт" },
                { "Пілоти" },
                { "Штраф" },
                { "Час" },
                { "Ім'я" },
                { "Ліга" },
                { "Очки" }
            };

        public RaceDataService(IExcelWorker excelWorker)
        {
            _excelWorker = excelWorker;
            _keyCellsColumnNumbers = GetColumnNumberForAllHeaders();
        }

        private Dictionary<string, List<int>> GetColumnNumberForAllHeaders()
        {
            return _excelWorker.GetColumnNumberForAllHeaders(_headers);
        }

        public List<List<int>> ReadResultsInBoard(string nameOfColumn, int countRows)
        {
            var result = new List<List<int>>();
            var numbersColumns = _keyCellsColumnNumbers[nameOfColumn];
            for (int i = 0; i < numbersColumns.Count; i++)
            {
                var res = ConvertDataToInt(_excelWorker.ReadDataInColumn(StartRowByDefault, numbersColumns[i], countRows));
                result.Add(res);
            }
            return result;
        }

        public List<List<int>> ReadResultsInRace(string nameOfColumn, int count)
        {
            var result = new List<List<int>>();
            var score = _excelWorker.ReadDataInColumnsByName(nameOfColumn, count);

            foreach (var data in score)
            {
                result.Add(ConvertDataToInt(data));
            }

            return result;
        }

        public List<List<int>> ReadUsedKartsInBoard(int count)
        {
            var karts = new List<List<int>>();
            var numbersColumns = _keyCellsColumnNumbers["Номера"];
            for (int i = 0; i < numbersColumns.Count; i++)
            {
                karts.Add(new List<int>());
                var kartsAsString = _excelWorker.ReadDataInColumn(StartRowByDefault, numbersColumns[i], count);
                foreach (var item in kartsAsString)
                {
                    karts.Add(ConvertStringToListInt(item));
                }
            }
            return karts;
        }

        public List<string> ReadLiquesInBoard(int countRows)
        {
            var numbersColumns = _keyCellsColumnNumbers["Ліга"];
            return _excelWorker.ReadDataInColumn(StartRowByDefault, numbersColumns.First(), countRows);
        }

        public List<string> ReadNamesInBoard(int countRows)
        {
            var numbersColumns = _keyCellsColumnNumbers["Ім'я"];
            return _excelWorker.ReadDataInColumn(StartRowByDefault, numbersColumns.First(), countRows);
        }

        public void WriteDataInfoInBoard<T>(List<T> data, string nameOfColumn, int number)
        {
            var numbersColumns = _keyCellsColumnNumbers[nameOfColumn];
            _excelWorker.WriteDataInColumn(data, numbersColumns[number], StartRowByDefault);
        }

        public void WriteUsedKartsInBoard(List<int> karts)
        {
            var numbersColumns = _keyCellsColumnNumbers["Номера"];
            _excelWorker.AppendDataInColumn(karts, numbersColumns.First(), StartRowByDefault);
        }

        public void WriteDataInfoInRace<T>(List<List<T>> data, string nameOfColumn, List<int> countRows)
        {
            var startRow = StartRowByDefault;
            for (int i = 0; i < countRows.Count; i++)
            {
                _excelWorker.WriteDataInEmptyColumn(data[i], nameOfColumn, startRow);
                startRow += MaxKarts;
            }
        }

        public void SortTable(string nameColumn)
        {
            _excelWorker.SortTable(nameColumn);
        }

        public void ClearExcelData(Range rangeToClean = null, int countBellow = 50)
        {
            _excelWorker.Clear(rangeToClean, countBellow);
        }

        private List<int> ConvertDataToInt(List<string> data)
        {
            return data.Select(int.Parse).ToList();
        }

        private List<int> ConvertStringToListInt(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException("Input string cannot be null or empty", nameof(str));
            }

            return str
                .Split(' ')
                .Select(str =>
                {
                    bool success = int.TryParse(str, out int result);
                    if (!success)
                    {
                        throw new FormatException($"Unable to convert '{str}' to an integer.");
                    }
                    return result;
                })
                .ToList();
        }
    }
}
