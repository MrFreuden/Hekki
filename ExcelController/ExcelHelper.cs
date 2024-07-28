using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController
{
    public static class ExcelHelper
    {
        public static Range GetTBRange(int countPilots)
        {
            var keyCells = ExcelRead.FindKeyCellByValue("№", null);
            var keyCells2 = ExcelRead.FindKeyCellByValue("Сума", null);
            string ad1 = keyCells[0][2, 3].Address.Replace("$", String.Empty);
            string ad2 = keyCells2[0].Address.Replace("$", String.Empty);
            var t = ad2[1];
            var t2 = ad2[0];
            ad2 = ad2[0] + (ad2[1] - '0' + countPilots).ToString();
            return ExcelWorker.excel.get_Range(ad1, ad2);
        }

        public static int GetStartIndexOfEmptyTable(int row, int column)
        {
            int index = row;
            while (ExcelWorker.excel.Cells[index, column].Value != null)
                index++;
            return index;
        }

        public static List<string> AddEmptysInList(List<string> group, string value)
        {
            while (group.Count < ExcelWorker.MAXkarts)
                group.Add(value);
            return group;
        }

        public static Range GetHeadersTB()
        {
            var keyCells = ExcelRead.FindKeyCellByValue("№", null);
            var keyCells2 = ExcelRead.FindKeyCellByValue("Сума", null);
            //переписать метод без if
            if (keyCells2.Count == 0)
            {
                keyCells2 = ExcelRead.FindKeyCellByValue("Best Lap", null);
            }
            string ad1 = keyCells[0].Address.Replace("$", String.Empty);
            string ad2 = keyCells2[0].Address.Replace("$", String.Empty);
            return ExcelWorker.excel.get_Range(ad1, ad2);
        }

        public static int GetIndexNearColLeft(string keyWord, int startRow, int startCol)
        {
            int index = 0;
            while (ExcelWorker.excel.Cells[startRow, startCol - index].Value != keyWord)
                index++;

            return startCol - index;
        }
    }
}
