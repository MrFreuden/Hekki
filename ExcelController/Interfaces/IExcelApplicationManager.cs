using Microsoft.Office.Interop.Excel;

namespace ExcelController.Interfaces
{
    internal interface IExcelApplicationManager
    {
        Application Excel { get; }

        void CloseWorkbook();
        void OpenWorkbook(string path);
    }
}