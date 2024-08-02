using ExcelController.Interfaces;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace ExcelController
{
    public class ExcelApplicationManager : IExcelApplicationManager
    {
        private Application _excel;

        public Application Excel => _excel;

        public ExcelApplicationManager()
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
    }
}
