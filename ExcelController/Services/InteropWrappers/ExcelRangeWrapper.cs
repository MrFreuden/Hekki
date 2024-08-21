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

        public IExcelRange? Find(object value)
        {
            var findedRange = _range.Find(value);
            return findedRange != null ? new ExcelRangeWrapper(findedRange) : null;
        }

        public IExcelRange FindNext(object after)
        {
            var wrapper = after as ExcelRangeWrapper;
            if (wrapper == null)
            {
                throw new ArgumentException("The 'after' parameter must be of type ExcelRangeWrapper.", nameof(after));
            }
            var afterRange = wrapper._range;
            return new ExcelRangeWrapper(_range.FindNext(afterRange));
        }
    }
}
