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

        //[Test]
        //public void GetCellsByValue_ReturnsCorrectRanges()
        //{
        //    // Arrange
        //    var searchValue = "Test Value";
        //    var row = 1;
        //    var col = 1;
        //    var count = 2;
        //    var headers = _mockFactory.CreateHeaders(row, col, searchValue, count, count + count);
        //    _mockFactory.SetupSearchRange(_mockSearchedRange, headers);
        //    var excelSearcher = new ExcelSearcher(_mockExcel.Object);

        //    // Act
        //    var result = excelSearcher.GetCellsByValue(searchValue, _mockSearchedRange.Object);

        //    // Assert
        //    Assert.That(result, Has.Count.EqualTo(count));
        //    Assert.That(result[0].Address, Is.EqualTo("$A$1"));
        //    Assert.That(result[1].Address, Is.EqualTo("$E$1"));
        //}

        //[Test]
        //public void FindNext_ReturnsCorrectChain()
        //{
        //    // Arrange
        //    var searchValue = "Test Value";
        //    var row = 1;
        //    var col = 1;
        //    var count = 3;
        //    var headers = _mockFactory.CreateHeaders(row, col, searchValue, count, count + count);
        //    _mockFactory.SetupSearchRange(_mockSearchedRange, headers);

        //    // Act
        //    var firstRange = _mockSearchedRange.Object.Find("Test Value");
        //    var secondRange = _mockSearchedRange.Object.FindNext(firstRange);
        //    var thirdRange = _mockSearchedRange.Object.FindNext(secondRange);
        //    var fourthRange = _mockSearchedRange.Object.FindNext(thirdRange);

        //    // Assert
        //    Assert.That(firstRange, Is.Not.Null);
        //    Assert.That(firstRange.Address, Is.EqualTo("$A$1"));

        //    Assert.That(secondRange, Is.Not.Null);
        //    Assert.That(secondRange.Address, Is.EqualTo("$G$1"));

        //    Assert.That(thirdRange, Is.Not.Null);
        //    Assert.That(thirdRange.Address, Is.EqualTo("$M$1"));

        //    Assert.That(fourthRange.Address, Is.EqualTo(fourthRange.Address));
        //}
    }
}