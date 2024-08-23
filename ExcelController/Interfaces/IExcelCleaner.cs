using ExcelController.Services.InteropWrappers;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController.Interfaces
{
    public interface IExcelCleaner
    {
        void ClearExcelData(IExcelRange rangeToClean, int countBellow = 50);
    }
}