using ExcelController.Interfaces;
using Application = Microsoft.Office.Interop.Excel.Application;


namespace ExcelController
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
            _excel.Cells[row, column] = value;
        }
    }
}
