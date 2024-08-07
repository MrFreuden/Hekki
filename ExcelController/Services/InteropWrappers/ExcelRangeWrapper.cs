using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController.Services.InteropWrappers
{
    public class ExcelRangeWrapper : IExcelRange
    {
        private readonly Range _range;
        public string Address => _range.Address;
        public int Column => _range.Column;
        public int Row => _range.Row;
        public ExcelRangeWrapper(Range range)
        {
            _range = range;
        }

        public object Value2
        {
            get => _range.Value2;
            set
            {
                if (value != null)
                {
                    _range.Value2 = value.ToString();
                }
                else
                {
                    _range.Value2 = null;
                }
            }
        }

        public void ClearContents()
        {
            _range.ClearContents();
        }

        public IExcelRange Find(object value)
        {
            return new ExcelRangeWrapper(_range.Find(value));
        }

        public IExcelRange FindNext(object after)
        {
            return new ExcelRangeWrapper(_range.FindNext(after));
        }
    }
}
