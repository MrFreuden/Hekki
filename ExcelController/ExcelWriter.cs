using ExcelController.Interfaces;
using Application = Microsoft.Office.Interop.Excel.Application;


namespace ExcelController
{
    public class ExcelWriter : IExcelWriter
    {
        private readonly IExcelWorker _excelWorker;

        public ExcelWriter(IExcelWorker excelWorker)
        {
            _excelWorker = excelWorker;
        }

        public void WriteDataInColumn<T>(List<T> data, int column, int row)
        {
            foreach (var dat in data)
            {
                _excelWorker.WriteCell(row, column, dat.ToString());
                row++;
            }
        }

        public void AppendDataInColumn<T>(List<T> data, int column, int row)
        {
            foreach (var dat in data)
            {
                var currentData = dat.ToString();
                var prewData = _excelWorker.ReadCell(row, column);
                _excelWorker.WriteCell(row, column, prewData + " " + dat);
                row++;
            }
        }
    }
}
