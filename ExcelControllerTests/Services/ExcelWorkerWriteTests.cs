using AutoFixture;
using ExcelController.Services.InteropWrappers;
using Moq;

namespace ExcelControllerTests.Services
{
    internal class ExcelWorkerWriteTests : ExcelWorkerTestBase
    {
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

        [Test]
        public void AppendDataInColumn_Append()
        {
            // Arrange
            var data = new List<string> { "Test2" };
            var rowIndex = 1;
            var columnIndex = 1;
            var column = _mockFactory.CreateCellsInColumn(rowIndex, columnIndex, data.Count, Moq.ValueType.RandomString);
            var value = column.First().Value2 as string;
            SetupReader(new List<List<IExcelRange>> { column });

            // Act
            _excelWorker.AppendDataInColumn(data, rowIndex, columnIndex);

            // Assert
            _mockWriter.Verify(x => x.WriteCell(rowIndex, columnIndex, value + " " + data.First()));
        }

        [Test]
        public void AppendDataInColumn_WriteNewData_WhenOldDataIsNull()
        {
            // Arrange
            var data = new List<string> { "Test2" };
            var rowIndex = 1;
            var columnIndex = 1;
            var column = _mockFactory.CreateCellsInColumn(rowIndex, columnIndex, data.Count, Moq.ValueType.None);
            var value = column.First().Value2 as string;
            SetupReader(new List<List<IExcelRange>> { column });

            // Act
            _excelWorker.AppendDataInColumn(data, rowIndex, columnIndex);

            // Assert
            _mockWriter.Verify(x => x.WriteCell(rowIndex, columnIndex, data.First()));
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        [TestCase(0, 0)]
        public void AppendDataInColumn_ReturnsException_WhenIndexesIsLessThenOne(int starRowIndex, int columnIndex)
        {
            // Arrange
            var data = new List<string> { "Test2" };
            var column = _mockFactory.CreateCellsInColumn(starRowIndex, columnIndex, data.Count, Moq.ValueType.None);
            var value = column.First().Value2 as string;
            SetupReader(new List<List<IExcelRange>> { column });

            // Act & Assert
            _mockWriter.Verify(x => x.WriteCell(starRowIndex, columnIndex, data.First()));
            Assert.Throws<ArgumentException>(() => _excelWorker.AppendDataInColumn(data, starRowIndex, columnIndex));
        }
    }
}
