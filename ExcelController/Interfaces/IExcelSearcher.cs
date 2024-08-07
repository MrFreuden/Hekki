using ExcelController.Services.InteropWrappers;

namespace ExcelController.Interfaces
{
    public interface IExcelSearcher
    {
        IList<IExcelRange> GetCellsByValue(string value, IExcelRange searchedRange);
    }
}