using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController.Interfaces
{
    public interface IExcelWorker
    {
        void WriteDataInEmptyColumn<T>(List<T> data, string columnName, int startRow);
        void WriteDataInColumn<T>(List<T> data, int column, int startRow);
        List<List<string>> ReadDataInColumnsByName(string columnName, int count);
        List<string> ReadDataInColumn(int startRow, int column, int count);
        void AppendDataInColumn<T>(List<T> data, int column, int row);
        void SortTable(string nameColumn);
        Dictionary<string, List<int>> GetColumnNumberForAllHeaders(List<string> headers);
        void Clear(Range rangeToClean = null, int countBellow = 50);
    }
}
