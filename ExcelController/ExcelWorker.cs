using ExcelController.Interfaces;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController
{
    public class ExcelWorker : IExcelWorker
    {
        public const int StartRowByDefault = 4;
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

        public void WriteDataInEmptyColumn<T>(List<T> data, string columnName, int row)
        {
            var column = GetNumberOfEmptyColumnByName(columnName);
            if (column == -1)
            {
                return;
            }

            WriteDataInColumn(data, column, row);
        }

        private int GetNumberOfEmptyColumnByName(string columnName)
        {
            var cells = _searcher.GetCellsByValue(columnName, null);
            foreach (var cell in cells)
            {
                if (IsCellAboveEmpty(cell.Row, cell.Column))
                {
                    return cell.Column;
                }
            }
            return -1;
        }

        private bool IsCellAboveEmpty(int row, int column)
        {
            return _reader.ReadCell(row + 1, column) == "";
        }

        public void WriteDataInColumn<T>(List<T> data, int column, int startRow)
        {
            foreach (var item in data)
            {
                _writer.WriteCell(startRow, column, item.ToString());
                startRow++;
            }
        }

        public List<List<string>> ReadDataInColumnsByName(string columnName, int columnNumber, List<int> grousCapacity)
        {
            var data = new List<List<string>>();
            var cellIndexes = GetNumberOfFilledColumnsByName(columnName);
            var startRow = StartRowByDefault;
            for (int i = 0; i < grousCapacity.Count; i++)
            {
                data.Add(ReadDataInColumn(startRow, cellIndexes[columnNumber], grousCapacity[i]));
            }
            return data;
        }

        private List<int> GetNumberOfFilledColumnsByName(string columnName)
        {
            var cells = _searcher.GetCellsByValue(columnName, null);
            var columnIndexes = new List<int>();
            foreach (var cell in cells)
            {
                if (!IsCellAboveEmpty(cell.Row, cell.Column))
                {
                    columnIndexes.Add(cell.Column);
                }
            }
            return columnIndexes;
        }

        public List<string> ReadDataInColumn(int startRow, int column, int count)
        {
            var data = new List<string>();
            for (int i = 0; i < count; i++)
            {
                data.Add(_reader.ReadCell(startRow, column));
                startRow++;
            }
            return data;
        }

        public string ReadDataInCell(int row, int column)
        {
            return _reader.ReadCell(row, column);
        }

        public void AppendDataInColumn<T>(List<T> data, int column, int row)
        {
            foreach (var dat in data)
            {
                var currentData = dat.ToString();
                var prewData = _reader.ReadCell(row, column);
                _writer.WriteCell(row, column, prewData + " " + dat);
                row++;
            }
        }

        public void SortTable(string nameColumn)
        {
            throw new NotImplementedException();
        }

        //public Range GetHeadersTB()
        //{
        //    var keyCells = _searcher.GetCellsByValue("№", null);
        //    var keyCells2 = _searcher.GetCellsByValue("Сума", null);
        //    //TODO: переписать метод без if
        //    if (keyCells2.Count == 0)
        //    {
        //        keyCells2 = _searcher.GetCellsByValue("Best Lap", null);
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