using ExcelController.Interfaces;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController
{
    public class ExcelReader : IExcelReader
    {
        private readonly IExcelWorker _excelWorker;

        public ExcelReader(IExcelWorker excelWorker)
        {
            _excelWorker = excelWorker;
        }

        public List<string> ReadDataInColumn(int startRow, int column, int count)
        {
            var data = new List<string>();
            for (int i = 0; i < count; i++)
            {
                data.Add(_excelWorker.ReadCell(startRow, column));
            }
            return data;
        }
    }
}
