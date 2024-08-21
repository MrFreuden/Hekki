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

        private List<int> ConvertDataToInt(List<string> data)
        {
            return data.Select(int.Parse).ToList();
        }

        public List<List<int>> ReadResultsInRace(string nameOfColumn, int count)
        {
            var result = new List<List<int>>();
            var score = _excelWorker.ReadDataInRaceInColumnsByName(nameOfColumn, count);

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
            _excelWorker.WriteDataInColumn(data, StartRowByDefault, numbersColumns[number]);
        }

        public void WriteUsedKartsInBoard(List<int> karts)
        {
            var numbersColumns = _keyCellsColumnNumbers["Номера"];
            _excelWorker.AppendDataInColumn(karts, StartRowByDefault, numbersColumns.First());
        }

        public void WriteDataInfoInRace<T>(List<List<T>> data, string nameOfColumn)
        {
            if (data.Count == 0)
            {
                return;
            }
            _excelWorker.WriteDataInEmptyColumn(FlattenAndPadData(data), StartRowByDefault, nameOfColumn);
        }

        private List<T> FlattenAndPadData<T>(List<List<T>> data)
        {
            var result = new List<T>();

            foreach (var sublist in data)
            {
                result.AddRange(sublist);

                int paddingCount = MaxKarts - sublist.Count;
                if (paddingCount > 0)
                {
                    result.AddRange(Enumerable.Repeat(default(T), paddingCount));
                }
            }

            return result;
        }

        public void SortTable(string nameColumn)
        {
            _excelWorker.SortTable(nameColumn);
        }

        public void ClearExcelData(Range rangeToClean = null, int countBellow = 50)
        {
            _excelWorker.Clear(rangeToClean, countBellow);
        }
    }
}
