using ExcelController.Interfaces;
using ExcelController.Services.InteropWrappers;

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
            searchedRange ??= _excel.GetRange("A1", "DZ1000");
            var finded = searchedRange.Find(value);
            if (finded == null)
                return new List<IExcelRange>();

            var firstAdress = finded.Address;
            List<IExcelRange> ranges = new();
            while (true)
            {
                ranges.Add(finded);
                finded = searchedRange.FindNext(finded);
                if (finded == null || firstAdress == finded.Address)
                    return ranges;
            }
        }
    }
}
