using Application = Microsoft.Office.Interop.Excel.Application;

namespace ExcelController.Interfaces
{
    public interface IExcelWorker
    {
        void OpenWorkbook(string path);
        void CloseWorkbook();
        string ReadCell(int row, int column);
        void WriteCell(int row, int column, string value);
    }
}
