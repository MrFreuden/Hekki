using ExcelController.Interfaces;
using ExcelController.Services.InteropWrappers;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController.Services
{
    public class ExcelCleaner : IExcelCleaner
    {
        private readonly IExcelApplication _excel;

        public ExcelCleaner(IExcelApplication excel)
        {
            _excel = excel;
        }

        public void ClearExcelData(Range rangeToClean = null, int countBellow = 50)
        {
            List<IList<Range>> keyCells = new()
            {
                //FindKeyCellByValue("Номера", rangeToClean),
                //FindKeyCellByValue("Best Lap", rangeToClean),
                //FindKeyCellByValue("ХІТ", rangeToClean),
                //FindKeyCellByValue("Карт", rangeToClean),
                //FindKeyCellByValue("Пілоти", rangeToClean),
                //FindKeyCellByValue("Штраф", rangeToClean),
                //FindKeyCellByValue("Час", rangeToClean),
                ////FindKeyCellByValue("Ім'я", rangeToClean),
                ////FindKeyCellByValue("Ліга", rangeToClean),
                //FindKeyCellByValue("Очки", rangeToClean)
            };

            for (int j = 0; j < keyCells.Count; j++)
            {
                for (int i = 0; i < keyCells[j].Count; i++)
                {
                    string q = keyCells[j][i][2].Address.Replace("$", string.Empty);
                    string s = keyCells[j][i][countBellow].Address.Replace("$", string.Empty);
                    var aras = _excel.get_Range(q, s);
                    aras.ClearContents();
                }
            }
        }
    }
}
