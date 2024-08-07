

namespace ExcelController.Services.InteropWrappers
{
    public interface IExcelRange
    {
        object Value2 { get; set; }
        string Address { get; }
        int Column { get; }
        int Row { get; }
        void ClearContents();
        IExcelRange Find(object value);
        IExcelRange FindNext(object after);
    }
}
