using ExcelController.Interfaces;
using ExcelController.Services.InteropWrappers;

namespace ExcelController.Services
{
    public class ExcelWorker : IExcelWorker
    {
        public const int StartRowByDefault = 4;
        public const int EndRowByDefault = 53;
        private readonly IExcelApplication _application;
        private readonly IExcelReader _reader;
        private readonly IExcelWriter _writer;
        private readonly IExcelCleaner _cleaner;
        private readonly IExcelSearcher _searcher;

        public ExcelWorker()
        {
            _application = new ExcelApplicationManager().ExcelWrapper;
            _reader = new ExcelReader(_application);
            _writer = new ExcelWriter(_application);
            _cleaner = new ExcelCleaner(_application);
            _searcher = new ExcelSearcher(_application);
        }

        public ExcelWorker(IExcelApplication excelApplication, 
            IExcelReader excelReader, 
            IExcelWriter excelWriter, 
            IExcelCleaner excelCleaner, 
            IExcelSearcher excelSearcher)
        {
            _application = excelApplication;
            _reader = excelReader;
            _writer = excelWriter;
            _cleaner = excelCleaner;
            _searcher = excelSearcher;
        }

        public void WriteDataInEmptyColumn<T>(List<T> data, int startRow, string columnName)
        {
            var column = GetNumberOfEmptyColumnByName(columnName);
            if (column == -1)
            {
                return;
            }

            WriteDataInColumn(data, startRow, column);
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
            return _reader.ReadCell(row + 1, column) == null;
        }

        public void WriteDataInColumn<T>(List<T> data, int startRow, int column)
        {
            foreach (var item in data)
            {
                _writer.WriteCell(startRow, column, item.ToString());
                startRow++;
            }
        }

        public List<List<string>> ReadDataInColumnsByName(string columnName, int count)
        {
            var data = new List<List<string>>();
            var columnIndexes = GetNumberOfFilledColumnsByName(columnName);
            var columnNameIndexes = GetNumberOfFilledColumnsByName("Пілоти");
           
            for (int i = 0, j = 0; i < columnIndexes.Count; i++, j++)
            {
                while(j < columnNameIndexes.Count && columnIndexes[i] - columnNameIndexes[j] > 6)
                {
                    j++;
                }
                if (columnIndexes[i] - columnNameIndexes[j] > 6)
                {
                    return new List<List<string>>();
                }

                var rows = GetFilledRowsForColumns(columnNameIndexes[j], count);
                data.Add(new List<string>());
                for (int k = 0; k < rows.Count; k++)
                {
                    data[i].Add(ReadDataInCell(rows[k], columnIndexes[i]));
                }
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

        private List<int> GetFilledRowsForColumns(int column, int count)
        {
            var rows = new List<int>();
            var row = StartRowByDefault;

            for (int i = 0; i < count && i < EndRowByDefault; i++)
            {
                if (_reader.ReadCell(row, column) != null)
                {
                    rows.Add(row);
                }
                row++;
            }

            return rows;
        }

        public string ReadDataInCell(int row, int column)
        {
            return _reader.ReadCell(row, column);
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

        

        

       

        

        public void AppendDataInColumn<T>(List<T> data, int row, int column)
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

        public Dictionary<string, List<int>> GetColumnNumberForAllHeaders(List<string> headers)
        {
            var dict = new Dictionary<string, List<int>>();
            foreach (var header in headers)
            {
                var list = _searcher.GetCellsByValue(header, null);
                var listNumbers = new List<int>();
                foreach (var item in list)
                {
                    listNumbers.Add(item.Column);
                }
                dict[header] = listNumbers;
            }
            return dict;
        }

        public void Clear(Microsoft.Office.Interop.Excel.Range rangeToClean = null, int countBellow = 50)
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