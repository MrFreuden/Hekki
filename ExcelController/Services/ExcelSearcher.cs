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

        public IList<IExcelRange> GetCellsByValue(string value, IExcelRange searchedRange)
        {
            searchedRange ??= _excel.GetCell(1, 1);
            var finded = searchedRange.Find(value);

            if (finded == null)
                return new List<IExcelRange>();

            var firstAdress = finded.Address;
            List<IExcelRange> ranges = new();
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
