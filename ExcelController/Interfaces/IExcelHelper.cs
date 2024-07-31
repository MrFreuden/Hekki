using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController.Interfaces
{
    public interface IExcelHelper
    {
        void ClearExcelData(Range rangeToClean = null, int countBellow = 50);
        IList<Range> FindKeyCellByValue(string value, Range searchedRange);
        void SortTable(string nameColumn);
        Range GetHeadersTB();
        int GetIndexNearColLeft(string keyWord, int startRow, int startCol);
        int GetStartIndexOfEmptyTable(int row, int column);
    }
}
