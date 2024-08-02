using ExcelController.Interfaces;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController
{
    public class ExcelReader : IExcelReader
    {
        private readonly Application _excel;

        public ExcelReader(Application excel)
        {
            _excel = excel;
        }

        public string ReadCell(int row, int column)
        {
            return _excel.Cells[row, column].Value.ToString();
        }
    }
}
