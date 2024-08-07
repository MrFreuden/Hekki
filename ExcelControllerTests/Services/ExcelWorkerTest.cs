using Moq;
using ExcelController.Services;
using ExcelController.Services.InteropWrappers;
using ExcelController.Interfaces;

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

        [SetUp]
        public void Setup()
        {
            _mockExcel = new Mock<IExcelApplication>();
            _mockReader = new Mock<IExcelReader>();
            _mockWriter = new Mock<IExcelWriter>();
            _mockCleaner = new Mock<IExcelCleaner>();
            _mockSearcher = new Mock<IExcelSearcher>();

            _excelWorker = new ExcelWorker(_mockExcel.Object, _mockReader.Object, _mockWriter.Object, _mockCleaner.Object, _mockSearcher.Object);
        }

        [Test]
        [TestCase(1, 1, "Test Value")]
        [TestCase(2, 2, "1234")]
        [TestCase(3, 3, "")]
        [TestCase(4, 4, "41,123")]
        public void ReadCell_ReturnCorrectValue(int row, int column, string expectedValue)
        {
            //// Arrange
            //_mockRange.Setup(range => range.Value2).Returns(expectedValue);
            //_mockExcel.Setup(excel => excel.GetCell(row, column)).Returns(_mockRange.Object);

            //// Act
            //var cellData = _excelReader.ReadCell(row, column);

            //// Assert
            //Assert.That(cellData, Is.EqualTo(expectedValue));
        }
    }
}