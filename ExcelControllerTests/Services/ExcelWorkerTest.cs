using AutoFixture;
using ExcelController.Interfaces;
using ExcelController.Services;
using ExcelController.Services.InteropWrappers;
using ExcelControllerTests.Moq;
using Moq;

namespace ExcelControllerTests.Services
{
    public class ExcelWorkerTest
    {
        private Mock<IExcelApplication> _mockExcel;
        private Mock<IExcelReader> _mockReader;
        private Mock<IExcelWriter> _mockWriter;
        private Mock<IExcelCleaner> _mockCleaner;
        private Mock<IExcelSearcher> _mockSearcher;
        private ExcelWorker _excelWorker;
        private Fixture _fixture;
        private ExcelRangeMockFactory _mockFactory;

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

        [Test]
        [TestCase(4, "Test String", 1, 2, 3)]
        [TestCase(4, "Test String", "Name1", "Name2", "Name3")]
        public void WriteDataInEmptyColumn_ShouldWriteData_WhenColumnIsEmpty(
            int startRowIndex, string columnHeader, params object[] data)
        {
            // Arrange
            var columnIndex = _fixture.Create<int>();
            var emptyColumn = _mockFactory.CreateColumnWithData(
                startRowIndex - 1, columnIndex, columnHeader, data.Length, Moq.ValueType.None);
            SetupColumns(emptyColumn);
            
            // Act
            _excelWorker.WriteDataInEmptyColumn(data.ToList(), startRowIndex, columnHeader);

            // Assert
            VerifyWriteCalls(startRowIndex, columnIndex, data, Times.Once());
        }

        [Test]
        [TestCase(4, "Test String", 1, 2, 3)]
        public void WriteDataInEmptyColumn_ShouldWriteData_WhenFirstColumnIsFilledButSecondIsEmpty(
            int startRowIndex, string columnHeader, params object[] data)
        {
            // Arrange
            var indexFilledColumn = 3;
            var indexEmptyColumn = indexFilledColumn + 2;
            var filledColumn = _mockFactory.CreateColumnWithData(
                startRowIndex - 1, indexFilledColumn, columnHeader, data.Length, Moq.ValueType.RandomString);
            var emptyColumn = _mockFactory.CreateColumnWithData(
                startRowIndex - 1, indexEmptyColumn, columnHeader, data.Length, Moq.ValueType.None);
            SetupColumns(filledColumn, emptyColumn);

            // Act
            _excelWorker.WriteDataInEmptyColumn(data.ToList(), startRowIndex, columnHeader);

            // Assert
            VerifyWriteCalls(startRowIndex, indexFilledColumn, data, Times.Never());
            VerifyWriteCalls(startRowIndex, indexEmptyColumn, data, Times.Once());
        }

        [Test]
        [TestCase(4, "Test String", 1, 2, 3)]
        [TestCase(4, "Test String", "Name1", "Name2", "Name3")]
        public void WriteDataInEmptyColumn_ShouldNotWriteData_WhenHasNoEmptyColumn(
            int startRowIndex, string columnHeader, params object[] data)
        {
            // Arrange
            var indexColumn = _fixture.Create<int>();
            var filledColumn = _mockFactory.CreateColumnWithData(
                startRowIndex - 1, indexColumn, columnHeader, data.Length, Moq.ValueType.RandomString);
            SetupColumns(filledColumn);

            // Act
            _excelWorker.WriteDataInEmptyColumn(data.ToList(), startRowIndex, columnHeader);
            
            // Assert
            VerifyWriteCalls(startRowIndex, filledColumn.First().Column, data, Times.Never());
        }

        [Test]
        public void WriteDataInColumn_ShouldWriteData()
        {
            // Arrange
            var data = new List<string> { "Data1", "Data2", "Data3" };
            int startRowIndex = 1;
            int columnIndex = 1;
            var column = _mockFactory.CreateColumnWithData(
                startRowIndex - 1, columnIndex, "Header", data.Count, Moq.ValueType.None);
            SetupColumns(column);

            // Act
            _excelWorker.WriteDataInColumn(data, startRowIndex, columnIndex);

            // Assert
            VerifyWriteCalls(startRowIndex, columnIndex, data.ToArray(), Times.Once());
        }

        [Test]
        public void WriteDataInColumn_ShouldNotWriteData_WhenDataListIsEmpty()
        {
            // Arrange
            var data = new List<string>();
            int startRowIndex = 1;
            int columnIndex = 1;
            var column = _mockFactory.CreateColumnWithData(
                startRowIndex - 1, columnIndex, "Header", data.Count, Moq.ValueType.None);
            SetupColumns(column);

            // Act
            _excelWorker.WriteDataInColumn(data, startRowIndex, columnIndex);

            // Assert
            VerifyWriteCalls(startRowIndex, columnIndex, data.ToArray(), Times.Never());
        }

        [Test]
        public void WriteDataInColumn_ShouldWriteData_WhenDataHasDifferentTypes()
        {
            // Arrange
            var data = new List<object> { "StringData", 123, 45.67 };
            int startRowIndex = 1;
            int columnIndex = 1;
            var column = _mockFactory.CreateColumnWithData(
                startRowIndex - 1, columnIndex, "Header", data.Count, Moq.ValueType.None);
            SetupColumns(column);

            // Act
            _excelWorker.WriteDataInColumn(data, startRowIndex, columnIndex);

            // Assert
            for (int i = 0; i < data.Count; i++)
            {
                VerifyWriteCalls(startRowIndex, columnIndex, data.ToArray(), Times.Once());
            }
        }

        private void SetupColumns(params List<IExcelRange>[] columns)
        {
            var columnLists = columns.ToList();
            SetupSearcher(columnLists);
            SetupReader(columnLists);
        }

        private void SetupReader(List<List<IExcelRange>> columns)
        {
            foreach (var column in columns)
            {
                foreach (var cell in column)
                {
                    _mockReader.Setup(x => x.ReadCell(cell.Row, cell.Column)).Returns(cell.Value2 != null ? cell.Value2.ToString() : null);
                }

            }
        }

        private void SetupSearcher(List<List<IExcelRange>> columns)
        {
            var sortedHeaders = GetSortedHeaders(columns);
            _mockSearcher.Setup(x => x.GetCellsByValue(sortedHeaders.First().Value2.ToString(), (IExcelRange)null)).Returns(sortedHeaders);
        }

        private List<IExcelRange> GetSortedHeaders(List<List<IExcelRange>> columns)
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

        private void VerifyWriteCalls(int startRow, int column, object[] data, Times times)
        {
            for (int i = 0; i < data.Length; i++)
            {
                _mockWriter.Verify(x => x.WriteCell(startRow + i, column, data[i].ToString()), times);
            }
        }

        [Test]
        public void ReadDataInColumnsByName_ReturnsExpected_WhenNoOffset()
        {
            // Arrange
            var columnName = "Time";
            var count = 3;
            var offset = 1;
            var columnIndex = _fixture.Create<int>();
            var columnOfNames = _mockFactory.CreateColumnWithData(
                ExcelWorker.StartRowByDefault - 1, columnIndex, "Пілоти", count, Moq.ValueType.RandomString);
            var columnOfData = _mockFactory.CreateColumnWithData(
                ExcelWorker.StartRowByDefault - 1, columnIndex + offset, columnName, count, Moq.ValueType.RandomNumber);
            var expected = CreateExpectedData(columnOfData);
            SetupColumns(columnOfNames);
            SetupColumns(columnOfData);
            // Act
            var result = _excelWorker.ReadDataInColumnsByName(columnName, count);

            // Assert
            AssertResults(result, expected);
        }

        private List<List<string>> CreateExpectedData(List<IExcelRange> columnData)
        {
            return new List<List<string>> { columnData.Skip(1).Select(cell => cell.Value2.ToString()).ToList() };
        }

        private void AssertResults(List<List<string>> result, List<List<string>> expected)
        {
            Assert.That(result, Has.Count.EqualTo(expected.Count));
            for (int i = 0; i < result.Count; i++)
            {
                Assert.That(result[i], Is.EqualTo(expected[i]));
            }
        }

        [Test]
        public void ReadDataInColumn_ReturnsExpected_WhenAllGood()
        {
            // Arrange
            int startRow = 1;
            int column = 1;
            int count = 3;
            var cells = _mockFactory.CreateCellsInColumn(startRow, column, count).Select(x => x.Object).ToList();
            var expected = cells.Select(cell => cell.Value2.ToString()).ToList();
            SetupReader(new List<List<IExcelRange>> { cells });

            // Act
            var result = _excelWorker.ReadDataInColumn(startRow, column, count);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}