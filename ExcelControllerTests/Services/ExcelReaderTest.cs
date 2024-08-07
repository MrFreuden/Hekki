using Moq;
using Application = Microsoft.Office.Interop.Excel.Application;
using ExcelController.Services;
using Range = Microsoft.Office.Interop.Excel.Range;
using ExcelController.Services.InteropWrappers;
namespace ExcelControllerTests.Services
{
    public class ExcelReaderTest
    {
        private Mock<IExcelApplication> _mockExcel;
        private Mock<IExcelRange> _mockRange;

        [SetUp]
        public void Setup()
        {
            _mockExcel = new Mock<IExcelApplication>();
            _mockRange = new Mock<IExcelRange>();
        }

        [Test]
        [TestCase(1, 1, "Test Value")]
        [TestCase(2, 2, "1234")]
        [TestCase(3, 3, "")]
        [TestCase(4, 4, "41,123")]
        public void ReadCell_ReturnCorrectValue(int row, int column, string expectedValue)
        {
            // Arrange
            _mockRange.Setup(range => range.Value2).Returns(expectedValue);
            _mockExcel.Setup(excel => excel.GetCell(row, column)).Returns(_mockRange.Object);

            var excelReader = new ExcelReader(_mockExcel.Object);

            // Act
            var cellData = excelReader.ReadCell(row, column);

            // Assert
            Assert.That(cellData, Is.EqualTo(expectedValue));
        }

        [Test]
        public void ReadCell_HandlesNullCell()
        {
            // Arrange
            int row = 1;
            int column = 1;
            _mockExcel.Setup(excel => excel.GetCell(row, column)).Returns((IExcelRange)null);

            var excelReader = new ExcelReader(_mockExcel.Object);

            // Act
            var cellData = excelReader.ReadCell(row, column);

            // Assert
            Assert.IsNull(cellData);
        }
    }
}