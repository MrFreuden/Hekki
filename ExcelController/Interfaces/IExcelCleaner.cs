using ExcelController.Services.InteropWrappers;

namespace ExcelController.Interfaces
{
    public interface IExcelCleaner
    {
        void Clear(IExcelRange cell);
        void ClearExcelData(Microsoft.Office.Interop.Excel.Range rangeToClean = null, int countBellow = 50);
    }
}