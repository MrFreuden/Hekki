using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;


namespace ExcelController
{
    public class ExcelWriter : IExcelWriter
    {
        private readonly Application _excel;
        private readonly IExcelHelper _excelHelper;

        public ExcelWriter(Application excel, IExcelHelper excelHelper)
        {
            _excel = excel;
            _excelHelper = excelHelper;
        }

        public int GroupAmount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void WriteLiquesInBoard(List<string> liques)
        {
            throw new NotImplementedException();
        }

        public void WriteNamesInBoard(List<string> names)
        {
            throw new NotImplementedException();
        }

        public void WriteNamesInRace(List<string> names)
        {
            throw new NotImplementedException();
        }

        public void WriteScoresInBoard(List<List<int>> scores)
        {
            throw new NotImplementedException();
        }

        public void WriteTimesInBoard(List<List<int>> times)
        {
            throw new NotImplementedException();
        }

        public void WriteUsedKartsInBoard(List<List<int>> karts)
        {
            throw new NotImplementedException();
        }

        public void WriteUsedKartsInRace(List<List<int>> karts)
        {
            throw new NotImplementedException();
        }
    }
}
