using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController.Services.InteropWrappers
{
    public class ExcelApplicationWrapper : IExcelApplication
    {
        private readonly Application _excelApplication;

        public ExcelApplicationWrapper(Application excelApplication)
        {
            _excelApplication = excelApplication;
        }

        public IExcelRange GetCell(int row, int column)
        {
            var cell = _excelApplication.Cells[row, column];
            return new ExcelRangeWrapper(cell);
        }

        public IExcelRange GetRange(string firstCellAdress, string secondCellAdress)
        {
            var range = _excelApplication.get_Range(firstCellAdress, secondCellAdress);
            return new ExcelRangeWrapper(range);
        }
    }
}
