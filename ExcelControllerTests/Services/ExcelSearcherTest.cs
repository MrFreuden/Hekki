using Moq;
using ExcelController.Services;
using ExcelController.Services.InteropWrappers;
namespace ExcelControllerTests.Services
{
    public class ExcelSearcherTest
    {
        private Mock<IExcelApplication> _mockExcel;
        private Mock<IExcelRange> _mockSearchedRange;
        private Mock<IExcelRange> _mockFoundRange;

        [SetUp]
        public void Setup()
        {
            _mockExcel = new Mock<IExcelApplication>();
            _mockSearchedRange = new Mock<IExcelRange>();
            _mockFoundRange = new Mock<IExcelRange>();
        }

        [Test]
        public void GetCellsByValue_ReturnsCorrectRanges()
        {
            // Arrange
            string searchValue = "Test Value";
            string firstAddress = "A1";
            string secondAddress = "B2";
            _mockFoundRange.SetupSequence(range => range.Address)
                .Returns(firstAddress)
                .Returns(secondAddress);

            _mockSearchedRange.Setup(range => range.Find(It.IsAny<object>())).Returns(_mockFoundRange.Object);

            _mockSearchedRange.Setup(range => range.FindNext(It.IsAny<IExcelRange>()))
                .Returns(_mockFoundRange.Object);

            var excelSearcher = new ExcelSearcher(_mockExcel.Object);

            // Act
            var result = excelSearcher.GetCellsByValue(searchValue, _mockSearchedRange.Object);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(firstAddress, result[0].Address);
            Assert.AreEqual(secondAddress, result[1].Address);
        }
    }
}