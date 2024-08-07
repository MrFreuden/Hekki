using ExcelController.Services.InteropWrappers;
using Microsoft.Office.Interop.Excel;

namespace ExcelController.Interfaces
{
    public interface IExcelApplicationManager
    {
        IExcelApplication ExcelWrapper { get; }

        void CloseWorkbook();
        void OpenWorkbook(string path);
    }
}