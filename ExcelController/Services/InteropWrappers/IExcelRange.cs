

namespace ExcelController.Services.InteropWrappers
{
    public interface IExcelRange
    {
        object Value2 { get; set; }
        string Address { get; }
        void ClearContents();
        IExcelRange Find(object value);
        IExcelRange FindNext(object after);
    }
}
