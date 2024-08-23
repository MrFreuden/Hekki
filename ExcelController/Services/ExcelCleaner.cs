using ExcelController.Interfaces;
using ExcelController.Services.InteropWrappers;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController.Services
{
    public class ExcelCleaner : IExcelCleaner
    {
        private readonly IExcelApplication _excel;

        public ExcelCleaner(IExcelApplication excel)
        {
            _excel = excel;
        }

        public void ClearExcelData(IExcelRange rangeToClean, int countBellow = 50)
        {
            var aras = _excel.GetCell(rangeToClean.Row + countBellow, rangeToClean.Column);
            aras.ClearContents();
        }
    }
}
