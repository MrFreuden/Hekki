using ExcelController.Interfaces;
using RaceLogic.Interfaces;
using System.Data.Common;
using static System.Formats.Asn1.AsnWriter;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace RaceLogic
{
    public class RaceDataService : IRaceDataService
    {
        public const int StartRowByDefault = 4;
        private readonly IExcelWorker _excelWorker;

        public RaceDataService(IExcelWorker excelWorker) 
        { 
            _excelWorker = excelWorker;
        }

        //TODO: перенести в отдельный класс



        public List<int> ReadResultsInBoard(string nameOfColumn, int countRows)
        {
            //var keyCells = FindKeyCellByValue("ХІТ", null);
            //var keyCells = FindKeyCellByValue("Best Lap", null);
            var result = _excelWorker.ReadDataInColumn(StartRowByDefault, column, countRows);
            return ConvertDataToInt(result);
        }

        public List<List<int>> ReadResultsInRace(string nameOfColumn, List<int> countRows)
        {
            var result = new List<List<int>>(countRows.Count);
            var startRow = StartRowByDefault;
            for (int i = 0; i < countRows.Count; i++)
            {
                var score = _excelWorker.ReadDataInColumn(startRow, column, countRows[i]);
                result.Add(ConvertDataToInt(score));
                startRow += countRows[i];
            }
            return result;
        }

        public List<List<string>> ReadNamesInRace(string nameOfColumn, List<int> countRows)
        {
            var names = new List<List<string>>(countRows.Count);
            var startRow = StartRowByDefault;
            for (int i = 0; i < countRows.Count; i++)
            {
                names.Add(_excelWorker.ReadDataInColumn(startRow, column, countRows[i]));
                startRow += countRows[i];
            }
            return names;
        }

        public List<List<int>> ReadUsedKartsInBoard(string nameOfColumn, int countRows)
        {
            var karts = new List<List<int>>(countRows);
            var currentRow = StartRowByDefault;
            for (int i = 0; i < countRows; i++)
            {
                var kartsAsString = _excelWorker.ReadDataInCell(currentRow, column);
                karts.Add(ConvertStringToListInt(kartsAsString));
            }
            return karts;
        }

        public List<int> ReadUsedKartsInRace(string nameOfColumn, List<int> countRows)
        {
            var karts = new List<int>();
            var currentRow = StartRowByDefault;
            for (int i = 0; i < countRows.Count; i++)
            {
                var kartsAsString = _excelWorker.ReadDataInColumn(currentRow, column, countRows[i]);
                karts.AddRange(ConvertDataToInt(kartsAsString));
            }
            return karts;
        }

        public List<string> ReadLiquesInBoard(string nameOfColumn, int countRows)
        {
            return _excelWorker.ReadDataInColumn(StartRowByDefault, column, countRows);
        }

        public List<string> ReadNamesInBoard(string nameOfColumn, int countRows)
        {
            return _excelWorker.ReadDataInColumn(StartRowByDefault, column, countRows);
        }

        public void WriteDataInfoInBoard<T>(List<T> data, string nameOfColumn)
        {
            _excelWorker.WriteDataInColumn(data, column, StartRowByDefault);
        }

        public void WriteUsedKartsInBoard(List<int> karts, string nameOfColumn)
        {
            _excelWorker.AppendDataInColumn(karts, column, StartRowByDefault);
        }

        public void WriteDataInfoInRace<T>(List<List<T>> data, string nameOfColumn, List<int> countRows)
        {
            for (int i = 0; i < countRows.Count; i++)
            {
                _excelWorker.WriteDataInColumn(data[i], column, countRows[i]);
            }
        }

        public void SortTable(string nameColumn)
        {
            _excelWorker.SortTable(nameColumn);
        }

        public void ClearExcelData(Range rangeToClean = null, int countBellow = 50)
        {
            _excelWorker.ClearExcelData(rangeToClean, countBellow);
        }

        public int GetColumnNumberByName(string value, Range searchedRange)
        {
            return _excelWorker.FindKeyCellByValue(value, searchedRange);
        }

        public Range GetHeadersTB()
        {
            return _excelWorker.GetHeadersTB();
        }

        public int GetIndexNearColLeft(string keyWord, int startRow, int startCol)
        {
            return _excelWorker.GetIndexNearColLeft(keyWord, startRow, startCol);
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
