using ExcelController.Interfaces;
using ExcelController.Services.InteropWrappers;
using ExcelController.Utils;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace ExcelController.Services
{
    public class ExcelApplicationManager : IExcelApplicationManager
    {
        private Application _excel_Interop;
        private IExcelApplication _excelWrapper;

        public IExcelApplication Excel => _excelWrapper;

        public ExcelApplicationManager()
        {
            _excel_Interop = GetExcel();
            _excelWrapper = new ExcelApplicationWrapper(_excel_Interop);
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
