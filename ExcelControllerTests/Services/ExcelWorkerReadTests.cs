using AutoFixture;
using ExcelController.Services.InteropWrappers;
using ExcelController.Services;
using Moq;

namespace ExcelControllerTests.Services
{
    internal class ExcelWorkerReadTests : ExcelWorkerTestBase
    {
        [Test]
        public void ReadDataInColumnsByName_ReturnsExpected()
        {
            // Arrange
            var columnName = "Time";
            var countData = 3;
            var offset = 1;
            var columnIndex = _fixture.Create<int>();
            var columnOfNames = _mockFactory.CreateColumnWithData(
                ExcelWorker.StartRowByDefault - 1, columnIndex, "Пілоти", countData, Moq.ValueType.RandomString);
            var columnOfData = _mockFactory.CreateColumnWithData(
                ExcelWorker.StartRowByDefault - 1, columnIndex + offset, columnName, countData, Moq.ValueType.RandomNumber);
            var expected = CreateExpectedData(columnOfData);
            SetupColumns(columnOfNames);
            SetupColumns(columnOfData);

            // Act
            var result = _excelWorker.ReadDataInColumnsByName(columnName, countData);

            // Assert
            AssertResults(result, expected);
        }

        [Test]
        public void ReadDataInColumnsByName_ReturnsEmptyList_WhenColumnNamesDoesNotExist()
        {
            // Arrange
            var columnName = "Time";
            var countData = 3;
            var offset = 1;
            var columnIndex = _fixture.Create<int>();
            var columnOfData = _mockFactory.CreateColumnWithData(
                ExcelWorker.StartRowByDefault - 1, columnIndex + offset, columnName, countData, Moq.ValueType.RandomNumber);
            var expected = new List<List<string>>();
            _mockSearcher.Setup(x => x.GetCellsByValue("Пілоти", null)).Returns(new List<IExcelRange>());
            SetupColumns(columnOfData);

            // Act
            var result = _excelWorker.ReadDataInColumnsByName(columnName, countData);

            // Assert
            AssertResults(result, expected);
        }

        [Test]
        public void ReadDataInColumnsByName_ReturnsEmptyList_WhenColumnDoesNotExist()
        {
            // Arrange
            var columnName = "Time";
            var countData = 3;
            var expected = new List<List<string>>();
            _mockSearcher.Setup(x => x.GetCellsByValue(It.IsAny<string>(), null)).Returns(new List<IExcelRange>());

            // Act
            var result = _excelWorker.ReadDataInColumnsByName(columnName, countData);

            // Assert
            AssertResults(result, expected);
        }

        [Test]
        public void ReadDataInColumnsByName_ReturnsExpected_WhenCountMoreThanCountData()
        {
            // Arrange
            var columnName = "Time";
            var countData = 3;
            var offset = 1;
            var columnIndex = _fixture.Create<int>();
            var columnOfNames = _mockFactory.CreateColumnWithData(
                ExcelWorker.StartRowByDefault - 1, columnIndex, "Пілоти", countData, Moq.ValueType.RandomString);
            var columnOfData = _mockFactory.CreateColumnWithData(
                ExcelWorker.StartRowByDefault - 1, columnIndex + offset, columnName, countData, Moq.ValueType.RandomNumber);
            var expected = CreateExpectedData(columnOfData);
            SetupColumns(columnOfNames);
            SetupColumns(columnOfData);

            // Act
            var result = _excelWorker.ReadDataInColumnsByName(columnName, countData + 1);

            // Assert
            AssertResults(result, expected);
        }

        [Test]
        public void ReadDataInColumn_ReturnsExpected_WhenAllGood()
        {
            // Arrange
            int startRow = 1;
            int column = 1;
            int count = 3;
            var cells = _mockFactory.CreateCellsInColumn(startRow, column, count);
            var expected = cells.Select(cell => cell.Value2.ToString()).ToList();
            SetupReader(new List<List<IExcelRange>> { cells });

            // Act
            var result = _excelWorker.ReadDataInColumn(startRow, column, count);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        [TestCase(0, 0)]
        public void ReadDataInColumn_ReturnsException_WhenIndexesIsLessThenOne(int startRow, int columnIndex)
        {
            // Arrange
            int count = 3;
            var cells = _mockFactory.CreateCellsInColumn(startRow, columnIndex, count);
            var expected = cells.Select(cell => cell.Value2.ToString()).ToList();
            SetupReader(new List<List<IExcelRange>> { cells });

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _excelWorker.ReadDataInColumn(startRow, columnIndex, count));
        }
    }
}
