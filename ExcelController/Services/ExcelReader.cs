using ExcelController.Interfaces;
using ExcelController.Services.InteropWrappers;

namespace ExcelController.Services
{
    public class ExcelReader : IExcelReader
    {
        private readonly IExcelApplication _excel;

        public ExcelReader(IExcelApplication excel)
        {
            _excel = excel;
        }

        public string ReadCell(int row, int column)
        {
            var cell = _excel.GetCell(row, column);
            return cell?.Value2?.ToString();
        }
    }
}
