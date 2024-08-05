using ExcelController.Interfaces;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;


namespace ExcelController.Services
{
    public class ExcelWriter : IExcelWriter
    {
        private readonly Application _excel;

        public ExcelWriter(Application excel)
        {
            _excel = excel;
        }

        public void WriteCell(int row, int column, string value)
        {
            var cell = (Range)_excel.Cells[row, column];
            cell.Value = value;
        }
    }
}
