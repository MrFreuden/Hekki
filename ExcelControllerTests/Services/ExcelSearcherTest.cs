using Moq;
using Application = Microsoft.Office.Interop.Excel.Application;
using ExcelController.Services;
using Range = Microsoft.Office.Interop.Excel.Range;
using ExcelController.Interfaces;
using Microsoft.Office.Interop.Excel;
namespace ExcelControllerTests.Services
{
    public class ExcelSearcherTest
    {
        private Mock<Application> _mockExcel;
        private Mock<Range> _mockSearchedRange;
        private Mock<Range> _mockFoundRange;

        [SetUp]
        public void Setup()
        {
            _mockExcel = new Mock<Application>();
            _mockSearchedRange = new Mock<Range>();
            _mockFoundRange = new Mock<Range>();
        }

        [Test]
        public void GetCellsByValue_ReturnsCorrectRanges()
        {
            // Arrange
            string searchValue = "Test Value";
            string firstAddress = "$A$1";
            string secondAddress = "$B$2";
            _mockFoundRange.SetupSequence(range => range.Address)
                .Returns(firstAddress)
                .Returns(secondAddress);

            _mockSearchedRange.Setup(range => range.Find(
                It.IsAny<object>(),
                It.IsAny<object>(),
                It.IsAny<object>(),
                It.IsAny<object>(),
                It.IsAny<object>(),
                It.IsAny<XlSearchDirection>(),
                It.IsAny<object>(),
                It.IsAny<object>(),
                It.IsAny<object>())).Returns(_mockFoundRange.Object);

            _mockSearchedRange.Setup(range => range.FindNext(It.IsAny<Range>()))
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