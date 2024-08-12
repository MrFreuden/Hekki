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

            _excelWorker = new ExcelWorker(_mockExcel.Object, _mockReader.Object, _mockWriter.Object, _mockCleaner.Object, _mockSearcher.Object);
        }

        [Test]
        [TestCase(1, 4, "Test String", 1, 2, 3)]
        [TestCase(1, 4, "Test String", "Name1", "Name2", "Name3")]
        public void WriteDataInEmptyColumn_ShouldWriteData_WhenColumnIsEmpty(int countCells, int startRow, string columnName, params object[] data)
        {
            // Arrange
            var cells = _mockFactory.CreateCellsInOneRow(startRow - 1, _fixture.Create<int>(), columnName, countCells);
            _mockSearcher.Setup(x => x.GetCellsByValue(It.IsAny<string>(), It.IsAny<IExcelRange>()))
                .Returns(cells);
            _mockReader.Setup(x => x.ReadCell(It.IsAny<int>(), It.IsAny<int>())).Returns((string)null);
            // Act
            _excelWorker.WriteDataInEmptyColumn(data.ToList(), startRow, columnName);

            // Assert
            VerifyWriteCalls(startRow, cells.First().Column, data, Times.Once());
        }

        [Test]
        [TestCase(2, 4, "Test String", 1, 2, 3)]
        public void WriteDataInEmptyColumn_ShouldWriteData_WhenFirstColumnIsFilledButSecondIsEmpty(int countCells, int startRow, string columnName, params object[] data)
        {
            // Arrange
            var cells = _mockFactory.CreateCellsInOneRow(startRow - 1, _fixture.Create<int>(), columnName, countCells);
            _mockSearcher.Setup(x => x.GetCellsByValue(It.IsAny<string>(), It.IsAny<IExcelRange>()))
                .Returns(cells);
            _mockReader.SetupSequence(x => x.ReadCell(It.IsAny<int>(), It.IsAny<int>()))
                .Returns("The Cell is Filled")
                .Returns((string)null);

            // Act
            _excelWorker.WriteDataInEmptyColumn(data.ToList(), startRow, columnName);

            // Assert
            VerifyWriteCalls(startRow, cells.First().Column, data, Times.Never());
            VerifyWriteCalls(startRow, cells.Last().Column, data, Times.Once());
        }

        [Test]
        [TestCase(1, 4, "Test String", 1, 2, 3)]
        [TestCase(1, 4, "Test String", "Name1", "Name2", "Name3")]
        public void WriteDataInEmptyColumn_ShouldNotWriteData_WhenHasNoEmptyColumn(int countCells, int startRow, string columnName, params object[] data)
        {
            // Arrange
            var cells = _mockFactory.CreateCellsInOneRow(startRow - 1, _fixture.Create<int>(), columnName, countCells);
            _mockSearcher.Setup(x => x.GetCellsByValue(It.IsAny<string>(), It.IsAny<IExcelRange>()))
                .Returns(cells);
            _mockReader.Setup(x => x.ReadCell(It.IsAny<int>(), It.IsAny<int>())).Returns("The Cell is Filled");
            // Act
            _excelWorker.WriteDataInEmptyColumn(data.ToList(), startRow, columnName);

            // Assert
            VerifyWriteCalls(startRow, cells.First().Column, data, Times.Never());
        }

        private void VerifyWriteCalls(int startRow, int column, object[] data, Times times)
        {
            for (int i = 0; i < data.Length; i++)
            {
                _mockWriter.Verify(x => x.WriteCell(startRow + i, column, data[i].ToString()), times);
            }
        }

        [Test]
        [TestCase(4, 4, 1, 2, 3)]
        [TestCase(4, 5, "Name1", "Name2", "Name3")]
        public void WriteDataInColumn_ShouldWriteData_WhenCorrectArg(int startRow, int column, params object[] data)
        {
            _excelWorker.WriteDataInColumn(data.ToList(), startRow, column);

            VerifyWriteCalls(startRow, column, data, Times.Once());
        }

        [Test]
        public void ReadDataInColumnsByName_ReturnsExpected_WhenNoOffset()
        {
            string columnName = "Time";
            int count = 3;
            int offset = 1;
            var cellsHeaders = SetupHeaderData(ExcelWorker.StartRowByDefault - 1, _fixture.Create<int>(), columnName, 1);
            var cellsNameHeaders = SetupHeaderData(cellsHeaders.First().Row, cellsHeaders.First().Column - offset, "Пілоти", 1);
            var cellsInColumn = SetupColumnData(cellsHeaders, count);
            var cellsInColumnName = SetupColumnData(cellsNameHeaders, count);

            var expected = CreateExpectedData(cellsInColumn);

            _mockReader.Setup(x => x.ReadCell(cellsHeaders.First().Row, cellsHeaders.First().Column))
                .Returns(cellsInColumn.First().Value2.ToString());
            _mockReader.Setup(x => x.ReadCell(cellsNameHeaders.First().Row, cellsNameHeaders.First().Column))
                .Returns(cellsNameHeaders.First().Value2.ToString());

            var result = _excelWorker.ReadDataInColumnsByName(columnName, count);

            AssertResults(result, expected);
        }

        private List<IExcelRange> SetupHeaderData(int startRow, int startColumn, string columnName, int count)
        {
            var cellsHeaders = _mockFactory.CreateCellsInOneRow(startRow, startColumn, columnName, count);
            _mockSearcher.Setup(x => x.GetCellsByValue(columnName, It.IsAny<IExcelRange>()))
               .Returns(cellsHeaders);

            return cellsHeaders;
        }

        private List<IExcelRange> SetupColumnData(List<IExcelRange> cellsData, int count)
        {
            var columnData = _mockFactory.CreateCellsInOneColumn(cellsData.First().Row + 1, cellsData.First().Column, count);
            for (int i = 0; i < count; i++)
            {
                _mockReader.Setup(x => x.ReadCell(columnData[i].Row, columnData[i].Column))
                    .Returns(columnData[i].Value2.ToString());
            }
            return columnData;
        }

        private List<List<string>> CreateExpectedData(List<IExcelRange> columnData)
        {
            return new List<List<string>> { columnData.Select(cell => cell.Value2.ToString()).ToList() };
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
            int startRow = 1;
            int column = 1;
            int count = 3;
            var cells = _mockFactory.CreateCellsInOneColumn(startRow, column, count);
            var expected = cells.Select(cell => cell.Value2.ToString()).ToList();

            for (int i = 0; i < count; i++)
            {
                _mockReader.Setup(x => x.ReadCell(cells[i].Row, cells[i].Column)).Returns(cells[i].Value2.ToString());
            }

            var result = _excelWorker.ReadDataInColumn(startRow, column, count);

            // Assert

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}