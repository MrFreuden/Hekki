using AutoFixture;
using ExcelController.Interfaces;
using ExcelController.Services.InteropWrappers;
using ExcelController.Services;
using ExcelControllerTests.Moq;
using Moq;

namespace ExcelControllerTests.Services
{
    public class ExcelWorkerTestBase
    {
        protected Mock<IExcelApplication> _mockExcel;
        protected Mock<IExcelReader> _mockReader;
        protected Mock<IExcelWriter> _mockWriter;
        protected Mock<IExcelCleaner> _mockCleaner;
        protected Mock<IExcelSearcher> _mockSearcher;
        protected ExcelWorker _excelWorker;
        protected Fixture _fixture;
        protected ExcelRangeMockFactory _mockFactory;

        [SetUp]
        public void Setup()
        {
            _mockExcel = new Mock<IExcelApplication>();
            _mockReader = new Mock<IExcelReader>();
            _mockWriter = new Mock<IExcelWriter>();
            _mockCleaner = new Mock<IExcelCleaner>();
            _mockSearcher = new Mock<IExcelSearcher>();
            _fixture = new Fixture();
            _mockFactory = new ExcelRangeMockFactory();
            _excelWorker = new ExcelWorker(
                _mockExcel.Object, _mockReader.Object, _mockWriter.Object, _mockCleaner.Object, _mockSearcher.Object);
        }

        protected void SetupColumns(params List<IExcelRange>[] columns)
        {
            var columnLists = columns.ToList();
            SetupSearcher(columnLists);
            SetupReader(columnLists);
        }

        protected void SetupReader(List<List<IExcelRange>> columns)
        {
            foreach (var column in columns)
            {
                foreach (var cell in column)
                {
                    _mockReader.Setup(x => x.ReadCell(cell.Row, cell.Column)).Returns(cell.Value2 != null ? cell.Value2.ToString() : null);
                }

            }
        }

        protected void SetupSearcher(List<List<IExcelRange>> columns)
        {
            var sortedHeaders = GetSortedHeaders(columns);
            _mockSearcher.Setup(x => x.GetCellsByValue(sortedHeaders.First().Value2.ToString(), (IExcelRange)null)).Returns(sortedHeaders);
        }

        protected List<IExcelRange> GetSortedHeaders(List<List<IExcelRange>> columns)
        {
            var nonEmptyColumns = columns.Where(columnList => columnList.Any()).ToList();

            var firstValues = nonEmptyColumns.Select(columnList => columnList.First().Value2).Distinct().ToList();
            if (firstValues.Count > 1)
            {
                throw new InvalidOperationException("Свойство Value2 у всех элементов должно совпадать.");
            }

            return nonEmptyColumns
                .Select(columnList => columnList.First())
                .OrderBy(cell => cell.Column)
                .ToList();

        }

        protected void VerifyWriteCalls(int startRow, int column, object[] data, Times times)
        {
            for (int i = 0; i < data.Length; i++)
            {
                _mockWriter.Verify(x => x.WriteCell(startRow + i, column, data[i].ToString()), times);
            }
        }

        protected List<List<string>> CreateExpectedData(List<IExcelRange> columnData)
        {
            return new List<List<string>> { columnData.Skip(1).Select(cell => cell.Value2.ToString()).ToList() };
        }

        protected void AssertResults(List<List<string>> result, List<List<string>> expected)
        {
            Assert.That(result, Has.Count.EqualTo(expected.Count));
            for (int i = 0; i < result.Count; i++)
            {
                Assert.That(result[i], Is.EqualTo(expected[i]));
            }
        }
    }
}
