namespace ExcelController.Interfaces
{
    public interface IExcelSearcher
    {
        IList<Microsoft.Office.Interop.Excel.Range> GetCellsByValue(string value, Microsoft.Office.Interop.Excel.Range searchedRange);
    }
}