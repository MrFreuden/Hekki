using Moq;
using ExcelController.Services;
using ExcelController.Services.InteropWrappers;
using ExcelControllerTests.Moq;
namespace ExcelControllerTests.Services
{
    [TestFixture]
    public class ExcelSearcherTest
    {
        private Mock<IExcelApplication> _mockExcel;
        private Mock<IExcelRange> _mockSearchedRange;
        private ExcelRangeMockFactory _mockFactory;

        [SetUp]
        public void Setup()
        {
            _mockExcel = new Mock<IExcelApplication>();
            _mockSearchedRange = new Mock<IExcelRange>();
            _mockFactory = new ExcelRangeMockFactory();
        }

        [Test]
        public void GetCellsByValue_ReturnsCorrectRanges()
        {
            // Arrange
            string searchValue = "Test Value";
            string initialAddress = "$A$1";
            int count = 2;

            _mockSearchedRange = _mockFactory.CreateMockRange(initialAddress, count);

            var excelSearcher = new ExcelSearcher(_mockExcel.Object);

            // Act
            var result = excelSearcher.GetCellsByValue(searchValue, _mockSearchedRange.Object);

            // Assert
            Assert.AreEqual(count, result.Count);
            Assert.AreEqual("$A$1", result[0].Address);
            Assert.AreEqual("$A$2", result[1].Address);
        }
        [Test]
        public void Test()
        {
            // Arrange
            string searchValue = "Test Value";
            string initialAddress = "$A$1";
            int count = 2;
            var headers = _mockFactory.CreateHeaders(1, 1, searchValue, count, count + count);
            _mockSearchedRange = _mockFactory.GetSearchRange(headers);
            var excelSearcher = new ExcelSearcher(_mockExcel.Object);

            // Act
            var result = excelSearcher.GetCellsByValue(searchValue, _mockSearchedRange.Object);

            // Assert
            Assert.AreEqual(count, result.Count);
            Assert.AreEqual("$A$1", result[0].Address);
            Assert.AreEqual("$E$1", result[1].Address);
        }

        [Test]
        public void FindNext_ReturnsCorrectChain()
        {
            // Arrange
            string initialAddress = "$A$1";
            int count = 3;

            _mockSearchedRange = _mockFactory.CreateMockRange(initialAddress, count);

            var firstRange = _mockSearchedRange.Object.Find("Test Value");
            var secondRange = _mockSearchedRange.Object.FindNext(firstRange);
            var thirdRange = _mockSearchedRange.Object.FindNext(secondRange);
            var fourthRange = _mockSearchedRange.Object.FindNext(thirdRange);

            // Act & Assert
            Assert.IsNotNull(firstRange);
            Assert.AreEqual("$A$1", firstRange.Address);

            Assert.IsNotNull(secondRange);
            Assert.AreEqual("$A$2", secondRange.Address);

            Assert.IsNotNull(thirdRange);
            Assert.AreEqual("$A$3", thirdRange.Address);

            Assert.IsNull(fourthRange);
        }
    }
}