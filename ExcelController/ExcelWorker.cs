using ExcelController.Interfaces;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController
{
    public class ExcelWorker : IExcelWorker
    {
        private readonly ExcelApplicationManager _applicationManager;
        private readonly ExcelReader _reader;
        private readonly ExcelWriter _writer;
        private readonly ExcelCleaner _cleaner;
        private readonly ExcelSearcher _searcher;

        public ExcelWorker()
        {
            _applicationManager = new ExcelApplicationManager();
            _reader = new ExcelReader(_applicationManager.Excel);
            _writer = new ExcelWriter(_applicationManager.Excel);
            _cleaner = new ExcelCleaner(_applicationManager.Excel);
            _searcher = new ExcelSearcher(_applicationManager.Excel);
        }



        //public List<string> ReadDataInColumn(int startRow, int column, int count)
        //{
        //    var data = new List<string>();
        //    for (int i = 0; i < count; i++)
        //    {
        //        data.Add(_excel.ReadCell(startRow, column));
        //    }
        //    return data;
        //}

        //public string ReadDataInCell(int startRow, int column)
        //{
        //    return _excel.ReadCell(startRow, column);
        //}

        //public void WriteDataInColumn<T>(List<T> data, int column, int row)
        //{
        //    foreach (var dat in data)
        //    {
        //        _excelWorker.WriteCell(row, column, dat.ToString());
        //        row++;
        //    }
        //}

        //public void AppendDataInColumn<T>(List<T> data, int column, int row)
        //{
        //    foreach (var dat in data)
        //    {
        //        var currentData = dat.ToString();
        //        var prewData = _excelWorker.ReadCell(row, column);
        //        _excelWorker.WriteCell(row, column, prewData + " " + dat);
        //        row++;
        //    }
        //}

        //public void SortTable(string nameColumn)
        //{
        //    throw new NotImplementedException();
        //}

        //public Range GetHeadersTB()
        //{
        //    var keyCells = GetCellsByValue("№", null);
        //    var keyCells2 = GetCellsByValue("Сума", null);
        //    //TODO: переписать метод без if
        //    if (keyCells2.Count == 0)
        //    {
        //        keyCells2 = GetCellsByValue("Best Lap", null);
        //    }
        //    string ad1 = keyCells[0].Address.Replace("$", String.Empty);
        //    string ad2 = keyCells2[0].Address.Replace("$", String.Empty);
        //    return _excel.get_Range(ad1, ad2);
        //}

        //public int GetIndexNearColLeft(string keyWord, int startRow, int startCol)
        //{
        //    int index = 0;
        //    while (_excel.Cells[startRow, startCol - index].Value != keyWord)
        //        index++;

        //    return startCol - index;
        //}

        //public int GetStartIndexOfEmptyTable(int row, int column)
        //{
        //    int index = row;
        //    while (_excel.Cells[index, column].Value != null)
        //        index++;
        //    return index;
        //}
    }
}