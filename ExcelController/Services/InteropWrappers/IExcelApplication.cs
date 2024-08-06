using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController.Services.InteropWrappers
{
    public interface IExcelApplication
    {
        IExcelRange GetCell(int row, int column);
        IExcelRange GetRange(string firstCellAdress, string secondCellAdress);
    }
}
