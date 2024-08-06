using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController.Services.InteropWrappers
{
    public class ExcelRangeWrapper : IExcelRange
    {
        private readonly Range _range;
        
        public ExcelRangeWrapper(Range range)
        {
            _range = range;
        }

        public object Value2 => _range.Value2;
    }
}
