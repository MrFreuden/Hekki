using ExcelController.Interfaces;
using RaceLogic.Interfaces;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace RaceLogic
{
    public class RaceService : IRaceService
    {
        private IExcelHelper _excelHelper;
        private IExcelReader _excelReader;
        private IExcelWriter _excelWriter;

        public RaceService(IExcelHelper excelHelper, IExcelReader excelReader, IExcelWriter excelWriter, IExcelWorker excelWorker) 
        { 
            _excelHelper = excelHelper;
            _excelReader = excelReader;
            _excelWriter = excelWriter;
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

        public List<List<int>> ReadColScoresInBoard(int countRows)
        {
            return _excelReader.ReadColScoresInBoard(countRows);
        }

        public List<int> ReadColScoresInRace(int countRows, int startRow)
        {
            return _excelReader.ReadColScoresInRace(countRows, startRow);
        }

        public List<List<int>> ReadColTimesInBoard(int countRows)
        {
            return _excelReader.ReadColTimesInBoard(countRows);
        }

        public List<int> ReadColTimesInRace(int countRows, int startRow)
        {
            return _excelReader.ReadColTimesInRace(countRows, startRow);
        }

        public List<string> ReadLiquesInBoard()
        {
            return _excelReader.ReadLiquesInBoard();
        }

        public List<string> ReadNamesInBoard()
        {
            return _excelReader.ReadNamesInBoard();
        }

        public List<List<string>> ReadNamesInRace()
        {
            return _excelReader.ReadNamesInRace();
        }

        public List<List<int>> ReadUsedKartsInBoard()
        {
            return _excelReader.ReadUsedKartsInBoard();
        }

        public List<List<int>> ReadUsedKartsInRace()
        {
            return _excelReader.ReadUsedKartsInRace();
        }

        public void SortTable(string nameColumn)
        {
            _excelHelper.SortTable(nameColumn);
        }

        public void WriteLiquesInBoard(List<string> liques)
        {
            _excelWriter.WriteLiquesInBoard(liques);
        }

        public void WriteNamesInBoard(List<string> names)
        {
            _excelWriter.WriteNamesInBoard(names);
        }

        public void WriteNamesInRace(List<string> names)
        {
            _excelWriter.WriteNamesInRace(names);
        }

        public void WriteScoresInBoard(List<List<int>> scores)
        {
            _excelWriter.WriteScoresInBoard(scores);
        }

        public void WriteTimesInBoard(List<List<int>> times)
        {
            _excelWriter.WriteTimesInBoard(times);
        }

        public void WriteUsedKartsInBoard(List<List<int>> karts)
        {
            _excelWriter.WriteUsedKartsInBoard(karts);
        }

        public void WriteUsedKartsInRace(List<List<int>> karts)
        {
            _excelWriter.WriteUsedKartsInRace(karts);
        }
    }
}
