﻿using Moq;
using ExcelController.Services;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;


namespace ExcelControllerTests.Services
{
    [TestFixture]
    public class ExcelWriterTest
    {
        private Mock<Application> _mockExcel;
        private Mock<Range> _mockRange;

        [SetUp]
        public void Setup()
        {
            _mockExcel = new Mock<Application>();
            _mockRange = new Mock<Range>();
        }

        [Test]
        [TestCase(1, 1, "Test Value")]
        [TestCase(2, 2, "1234")]
        [TestCase(3, 3, "")]
        [TestCase(4, 4, "41,123")]
        public void WriteCell_SetsCorrectValue(int row, int column, string value)
        {
            // Arrange
            _mockExcel.Setup(excel => excel.Cells[row, column]).Returns(_mockRange.Object);

            var excelWriter = new ExcelWriter(_mockExcel.Object);

            // Act
            excelWriter.WriteCell(row, column, value);

            // Assert
            _mockRange.VerifySet(range => range.Value = value, Times.Once);
        }
    }
}
