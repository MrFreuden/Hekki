namespace ExcelController.Interfaces
{
    public interface IExcelCleaner
    {
        void ClearExcelData(Microsoft.Office.Interop.Excel.Range rangeToClean = null, int countBellow = 50);
    }
}