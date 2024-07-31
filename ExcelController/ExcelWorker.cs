using ExcelController.Interfaces;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController
{
    public class ExcelWorker : IExcelWorker
    {
        private Application _excel;

        public ExcelWorker()
        {
            _excel = GetExcel();
        }

        private Application GetExcel()
        {
            Application myExcel;

            try
            {
                myExcel = (Application)Marshal2.GetActiveObject("Excel.Application");
            }
            catch (Exception)
            {
                throw new Exception("Excel is not founded");
            }
            return myExcel;
        }

        public void CloseWorkbook()
        {
            throw new NotImplementedException();
        }

        public void OpenWorkbook(string path)
        {
            throw new NotImplementedException();
        }

        public string ReadCell(int row, int column)
        {
            return _excel.Cells[row, column].Value.ToString();
        }

        public void WriteCell(int row, int column, string value)
        {
            _excel.Cells[row, column] = value;
        }
    }
}