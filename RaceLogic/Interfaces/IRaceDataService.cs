using ExcelController;
using Range = Microsoft.Office.Interop.Excel.Range;
namespace RaceLogic.Interfaces
{
    public interface IRaceDataService
    {
        void ClearExcelData(Range rangeToClean = null, int countBellow = 50);
        IList<Range> FindKeyCellByValue(string value, Range searchedRange);
        Range GetHeadersTB();
        int GetIndexNearColLeft(string keyWord, int startRow, int startCol);
        void SortTable(string nameColumn);
        List<int> ReadResultsInBoard(int column, int countRows);
        List<List<int>> ReadResultsInRace(int column, List<int> countRows);
        List<List<string>> ReadNamesInRace(int column, List<int> countRows);
        List<List<int>> ReadUsedKartsInBoard(int column, int countRows);
        List<int> ReadUsedKartsInRace(int column, List<int> countRows);
        List<string> ReadLiquesInBoard(int column, int countRows);
        List<string> ReadNamesInBoard(int column, int countRows);
        void WriteDataInfoInBoard<T>(List<T> data, int column);
        void WriteUsedKartsInBoard(List<int> karts, int column);
        void WriteDataInfoInRace<T>(List<List<T>> data, int column, List<int> countRows);
    }
}
