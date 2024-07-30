using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController
{
    public interface IExcelHelper
    {
        void ClearExcelData();
        IList<Range> FindKeyCellByValue(string value, Range searchedRange);
    }
}
