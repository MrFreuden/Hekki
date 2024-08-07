using ExcelController.Interfaces;
using ExcelController.Services.InteropWrappers;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;


namespace ExcelController.Services
{
    public class ExcelWriter : IExcelWriter
    {
        private readonly IExcelApplication _excel;

        public ExcelWriter(IExcelApplication excel)
        {
            _excel = excel;
        }

        public void WriteCell(int row, int column, string value)
        {
            var cell = _excel.GetCell(row, column);
            cell.Value2 = value;
        }
    }
}
