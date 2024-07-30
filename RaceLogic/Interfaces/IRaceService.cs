using ExcelController;
using Range = Microsoft.Office.Interop.Excel.Range;
namespace RaceLogic.Interfaces
{
    public interface IRaceService
    {
        void ClearExcelData(Range rangeToClean = null, int countBellow = 50);
        IList<Range> FindKeyCellByValue(string value, Range searchedRange);
        Range GetHeadersTB();
        int GetIndexNearColLeft(string keyWord, int startRow, int startCol);
        List<List<int>> ReadColScoresInBoard(int countRows);
        List<int> ReadColScoresInRace(int countRows, int startRow);
        List<List<int>> ReadColTimesInBoard(int countRows);
        List<int> ReadColTimesInRace(int countRows, int startRow);
        List<string> ReadLiquesInBoard();
        List<string> ReadNamesInBoard();
        List<List<string>> ReadNamesInRace();
        List<List<int>> ReadUsedKartsInBoard();
        List<List<int>> ReadUsedKartsInRace();
        void SortTable(string nameColumn);
        void WriteLiquesInBoard(List<string> liques);
        void WriteNamesInBoard(List<string> names);
        void WriteNamesInRace(List<string> names);
        void WriteScoresInBoard(List<List<int>> scores);
        void WriteTimesInBoard(List<List<int>> times);
        void WriteUsedKartsInBoard(List<List<int>> karts);
        void WriteUsedKartsInRace(List<List<int>> karts);
    }
}
