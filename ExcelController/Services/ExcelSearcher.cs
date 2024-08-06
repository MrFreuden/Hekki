using ExcelController.Interfaces;
using ExcelController.Services.InteropWrappers;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController.Services
{
    public class ExcelSearcher : IExcelSearcher
    {
        private readonly IExcelApplication _excel;

        public ExcelSearcher(IExcelApplication excel)
        {
            _excel = excel;
        }

        public IList<Range> GetCellsByValue(string value, Range searchedRange)
        {
            searchedRange ??= _excel.get_Range("A1", "XFD1048576");
            var finded = searchedRange.Find(value);

            if (finded == null)
                return new List<Range>();

            var firstAdress = finded.Address;
            List<Range> ranges = new();
            while (true)
            {
                ranges.Add(finded);
                finded = searchedRange.FindNext(finded);
                if (firstAdress == finded.Address)
                    return ranges;
            }
        }
    }
}
