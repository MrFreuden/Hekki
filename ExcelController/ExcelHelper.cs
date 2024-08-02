using ExcelController.Interfaces;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController
{
    public class ExcelHelper : IExcelHelper
    {
        private readonly Application _excel;

        public ExcelHelper(Application excel) 
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
                    string q = keyCells[j][i][2].Address.Replace("$", String.Empty);
                    string s = keyCells[j][i][countBellow].Address.Replace("$", String.Empty);
                    var aras = _excel.get_Range(q, s);
                    aras.ClearContents();
                }
            }
        }

        public IList<Range> FindKeyCellByValue(string value, Range searchedRange)
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

        public void SortTable(string nameColumn)
        {
            throw new NotImplementedException();
        }

        public Range GetHeadersTB()
        {
            var keyCells = FindKeyCellByValue("№", null);
            var keyCells2 = FindKeyCellByValue("Сума", null);
            //TODO: переписать метод без if
            if (keyCells2.Count == 0)
            {
                keyCells2 = FindKeyCellByValue("Best Lap", null);
            }
            string ad1 = keyCells[0].Address.Replace("$", String.Empty);
            string ad2 = keyCells2[0].Address.Replace("$", String.Empty);
            return _excel.get_Range(ad1, ad2);
        }

        public int GetIndexNearColLeft(string keyWord, int startRow, int startCol)
        {
            int index = 0;
            while (_excel.Cells[startRow, startCol - index].Value != keyWord)
                index++;

            return startCol - index;
        }

        public int GetStartIndexOfEmptyTable(int row, int column)
        {
            int index = row;
            while (_excel.Cells[index, column].Value != null)
                index++;
            return index;
        }
    }
}
