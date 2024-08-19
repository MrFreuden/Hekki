using AutoFixture;
using ExcelController.Interfaces;
using ExcelController.Services;
using ExcelController.Services.InteropWrappers;
using ExcelControllerTests.Moq;
using Moq;

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
        private Fixture _fixture;
        private ExcelRangeMockFactory _mockFactory;

        [SetUp]
        public void Setup()
        {
            _mockExcel = new Mock<IExcelApplication>();
            _mockReader = new Mock<IExcelReader>();
            _mockWriter = new Mock<IExcelWriter>();
            _mockCleaner = new Mock<IExcelCleaner>();
            _mockSearcher = new Mock<IExcelSearcher>();
            _fixture = new Fixture();
            _mockFactory = new ExcelRangeMockFactory();
            _excelWorker = new ExcelWorker(
                _mockExcel.Object, _mockReader.Object, _mockWriter.Object, _mockCleaner.Object, _mockSearcher.Object);
        }
    }
}