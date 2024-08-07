using Moq;
using ExcelController.Services;
using ExcelController.Services.InteropWrappers;

namespace ExcelControllerTests.Services
{
    [TestFixture]
    public class ExcelWriterTest
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
        public void WriteCell_SetsCorrectValue(int row, int column, string value)
        {
            // Arrange
            _mockExcel.Setup(excel => excel.GetCell(row, column)).Returns(_mockRange.Object);

            var excelWriter = new ExcelWriter(_mockExcel.Object);

            // Act
            excelWriter.WriteCell(row, column, value);

            // Assert
            _mockRange.VerifySet(range => range.Value2 = value, Times.Once);
        }
    }
}
