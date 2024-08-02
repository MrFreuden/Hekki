using ExcelController;
using Range = Microsoft.Office.Interop.Excel.Range;
namespace RaceLogic.Interfaces
{
    public interface IRaceDataService
    {
        void ClearExcelData(Range rangeToClean = null, int countBellow = 50);
        //IList<Range> FindKeyCellByValue(string value, Range searchedRange);  TODO: узнать как правильно сделать
        Range GetHeadersTB();
        int GetIndexNearColLeft(string keyWord, int startRow, int startCol);
        void SortTable(string nameColumn);
        List<int> ReadResultsInBoard(string nameOfColumn, int countRows);
        List<List<int>> ReadResultsInRace(string nameOfColumn, List<int> countRows);
        List<List<string>> ReadNamesInRace(string nameOfColumn, List<int> countRows);
        List<List<int>> ReadUsedKartsInBoard(string nameOfColumn, int countRows);
        List<int> ReadUsedKartsInRace(string nameOfColumn, List<int> countRows);
        List<string> ReadLiquesInBoard(string nameOfColumn, int countRows);
        List<string> ReadNamesInBoard(string nameOfColumn, int countRows);
        void WriteDataInfoInBoard<T>(List<T> data, string nameOfColumn);
        void WriteUsedKartsInBoard(List<int> karts, string nameOfColumn);
        void WriteDataInfoInRace<T>(List<List<T>> data, string nameOfColumn, List<int> countRows);
    }
}
