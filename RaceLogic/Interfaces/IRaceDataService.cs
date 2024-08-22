namespace RaceLogic.Interfaces
{
    public interface IRaceDataService
    {
        void ClearExcelData(Microsoft.Office.Interop.Excel.Range rangeToClean = null, int countBellow = 50);
        List<string> ReadLiquesInBoard(int countRows);
        List<string> ReadNamesInBoard(int countRows);
        List<string> ReadNamesInBoard();
        List<List<int>> ReadResultsInBoard(string nameOfColumn, int countRows);
        List<List<int>> ReadResultsInRace(string nameOfColumn, int count);
        List<List<int>> ReadUsedKartsInBoard(int count);
        void SortTable(string nameColumn);
        void WriteDataInfoInBoard<T>(List<T> data, string nameOfColumn, int number);
        void WriteDataInfoInRace<T>(List<List<T>> data, string nameOfColumn);
        void WriteUsedKartsInBoard(List<int> karts);
    }
}