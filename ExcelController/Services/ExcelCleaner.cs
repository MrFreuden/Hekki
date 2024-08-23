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
            var s1 = _excel.GetCell(rangeToClean.Row + 1, rangeToClean.Column).Address.Replace("$", String.Empty);
            var s2 = _excel.GetCell(rangeToClean.Row + countBellow, rangeToClean.Column).Address.Replace("$", String.Empty);
            var aras = _excel.GetRange(s1, s2);
            aras.ClearContents();
        }
    }
}
