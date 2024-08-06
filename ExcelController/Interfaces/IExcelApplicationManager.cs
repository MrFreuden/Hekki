using ExcelController.Services.InteropWrappers;
using Microsoft.Office.Interop.Excel;

namespace ExcelController.Interfaces
{
    internal interface IExcelApplicationManager
    {
        IExcelApplication Excel { get; }

        void CloseWorkbook();
        void OpenWorkbook(string path);
    }
}