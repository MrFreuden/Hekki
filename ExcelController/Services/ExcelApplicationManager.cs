using ExcelController.Interfaces;
using ExcelController.Services.InteropWrappers;
using ExcelController.Utils;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace ExcelController.Services
{
    public class ExcelApplicationManager : IExcelApplicationManager
    {
        private IExcelApplication _excelWrapper;

        public IExcelApplication ExcelWrapper => _excelWrapper;

        public ExcelApplicationManager()
        {
            var excel_Interop = GetExcel();
            _excelWrapper = new ExcelApplicationWrapper(excel_Interop);
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
    }
}
