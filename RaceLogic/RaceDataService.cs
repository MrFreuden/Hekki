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
        private readonly IExcelHelper _excelHelper;
        private readonly IExcelReader _excelReader;
        private readonly IExcelWriter _excelWriter;

        public RaceDataService(IExcelHelper excelHelper, IExcelReader excelReader, IExcelWriter excelWriter) 
        { 
            _excelHelper = excelHelper;
            _excelReader = excelReader;
            _excelWriter = excelWriter;
        }

        //TODO: перенести в отдельный класс



        public List<int> ReadResultsInBoard(int column, int countRows)
        {
            //var keyCells = FindKeyCellByValue("ХІТ", null);
            //var keyCells = FindKeyCellByValue("Best Lap", null);
            var result = _excelReader.ReadDataInColumn(StartRowByDefault, column, countRows);
            return ConvertDataToInt(result);
        }

        public List<List<int>> ReadResultsInRace(int column, List<int> countRows)
        {
            var result = new List<List<int>>(countRows.Count);
            var startRow = StartRowByDefault;
            for (int i = 0; i < countRows.Count; i++)
            {
                var score = _excelReader.ReadDataInColumn(startRow, column, countRows[i]);
                result.Add(ConvertDataToInt(score));
                startRow += countRows[i];
            }
            return result;
        }

        public List<List<string>> ReadNamesInRace(int column, List<int> countRows)
        {
            var names = new List<List<string>>(countRows.Count);
            var startRow = StartRowByDefault;
            for (int i = 0; i < countRows.Count; i++)
            {
                names.Add(_excelReader.ReadDataInColumn(startRow, column, countRows[i]));
                startRow += countRows[i];
            }
            return names;
        }

        public List<List<int>> ReadUsedKartsInBoard(int column, int countRows)
        {
            var karts = new List<List<int>>(countRows);
            var currentRow = StartRowByDefault;
            for (int i = 0; i < countRows; i++)
            {
                var kartsAsString = _excelReader.ReadDataInCell(currentRow, column);
                karts.Add(ConvertStringToListInt(kartsAsString));
            }
            return karts;
        }

        public List<int> ReadUsedKartsInRace(int column, List<int> countRows)
        {
            var karts = new List<int>();
            var currentRow = StartRowByDefault;
            for (int i = 0; i < countRows.Count; i++)
            {
                var kartsAsString = _excelReader.ReadDataInColumn(currentRow, column, countRows[i]);
                karts.AddRange(ConvertDataToInt(kartsAsString));
            }
            return karts;
        }

        public List<string> ReadLiquesInBoard(int column, int countRows)
        {
            return _excelReader.ReadDataInColumn(StartRowByDefault, column, countRows);
        }

        public List<string> ReadNamesInBoard(int column, int countRows)
        {
            return _excelReader.ReadDataInColumn(StartRowByDefault, column, countRows);
        }

        public void WriteDataInfoInBoard<T>(List<T> data, int column)
        {
            _excelWriter.WriteDataInColumn(data, column, StartRowByDefault);
        }

        public void WriteUsedKartsInBoard(List<int> karts, int column)
        {
            _excelWriter.AppendDataInColumn(karts, column, StartRowByDefault);
        }

        public void WriteDataInfoInRace<T>(List<List<T>> data, int column, List<int> countRows)
        {
            for (int i = 0; i < countRows.Count; i++)
            {
                _excelWriter.WriteDataInColumn(data[i], column, countRows[i]);
            }
        }

        public void SortTable(string nameColumn)
        {
            _excelHelper.SortTable(nameColumn);
        }

        public void ClearExcelData(Range rangeToClean = null, int countBellow = 50)
        {
            _excelHelper.ClearExcelData(rangeToClean, countBellow);
        }

        public IList<Range> FindKeyCellByValue(string value, Range searchedRange)
        {
            return _excelHelper.FindKeyCellByValue(value, searchedRange);
        }

        public Range GetHeadersTB()
        {
            return _excelHelper.GetHeadersTB();
        }

        public int GetIndexNearColLeft(string keyWord, int startRow, int startCol)
        {
            return _excelHelper.GetIndexNearColLeft(keyWord, startRow, startCol);
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
