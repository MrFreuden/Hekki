using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController
{
    public class ExcelWorker
    {
        public const int MAXkarts = 10;
        public static readonly Application excel = GetExcel();

        public static Application GetExcel()
        {
            Application myExcel;

            try
            {
                myExcel = (Application)Marshal2.GetActiveObject("Excel.Application");
            }
            catch (Exception)
            {
                throw new Exception("Excel не открыт");
            }
            return myExcel;
        }
    }
}