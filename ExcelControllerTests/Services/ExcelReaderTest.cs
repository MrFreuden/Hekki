using Moq;
using Application = Microsoft.Office.Interop.Excel.Application;
using ExcelController.Services;
using Range = Microsoft.Office.Interop.Excel.Range;
namespace ExcelControllerTests.Services
{
    public class ExcelReaderTest
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
        public void ReadCell_ReturnCorrectValue()
        {
            // Arrange
            int row = 1;
            int column = 1;
            string expectedValue = "Test Value";

            _mockRange.Setup(range => range.Value2).Returns(expectedValue);

            _mockExcel.Setup(excel => excel.Cells[row, column]).Returns(_mockRange.Object);

            var excelReader = new ExcelReader(_mockExcel.Object);



            // Act
            var cellData = excelReader.ReadCell(row, column);



            // Assert
            Assert.That(cellData, Is.EqualTo(expectedValue));
        }
    }
}