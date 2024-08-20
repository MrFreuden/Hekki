using AutoFixture;
using ExcelController.Interfaces;
using ExcelController.Services;
using ExcelController.Services.InteropWrappers;
using ExcelControllerTests.Moq;
using Moq;

namespace ExcelControllerTests.Services
{
    public class ExcelWorkerTest : ExcelWorkerTestBase
    {
        [Test]
        public void GetColumnNumberForAllHeaders()
        {
            // Arrange
            var row = 1;
            var column = 1;
            var expected = new Dictionary<string, List<int>>();
            var headers = new List<string>
                { "Номера" ,
                 "Best Lap" ,
                 "ХІТ" };
            var headersCells = new List<IExcelRange>();
            for (int i = 0; i < headers.Count; i++)
            {
                var he = _mockFactory.CreateHeader(row, column + i, headers[i]);
                headersCells.Add(he);
                expected.Add(headers[i], new List<int> { he.Column });
                SetupSearcher(new List<List<IExcelRange>> { new() { he } });
            }

            // Act
            var result = _excelWorker.GetColumnNumberForAllHeaders(headers);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetColumnNumberForAllHeaders_ReturnsEmptyDictionary_WhenEmptyHeaders()
        {
            // Arrange
            var row = 1;
            var column = 1;
            var expected = new Dictionary<string, List<int>>();
            var headers = new List<string>();
            var headersCells = new List<IExcelRange>();
            for (int i = 0; i < headers.Count; i++)
            {
                var he = _mockFactory.CreateHeader(row, column + i, headers[i]);
                headersCells.Add(he);
                expected.Add(headers[i], new List<int> { he.Column });
                SetupSearcher(new List<List<IExcelRange>> { new() { he } });
            }

            // Act
            var result = _excelWorker.GetColumnNumberForAllHeaders(headers);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetColumnNumberForAllHeaders_ReturnsExists_WhenOneHeaderIsNotExist()
        {
            // Arrange
            var row = 1;
            var column = 1;
            var expected = new Dictionary<string, List<int>>();
            var headers = new List<string>
                { "Номера" ,
                 "Best Lap" ,
                 "ХІТ" };
            var headersCells = new List<IExcelRange>();
            for (int i = 0; i < headers.Count - 1; i++)
            {
                var he = _mockFactory.CreateHeader(row, column + i, headers[i]);
                headersCells.Add(he);
                expected.Add(headers[i], new List<int> { he.Column });
                SetupSearcher(new List<List<IExcelRange>> { new() { he } });
            }

            // Act
            var result = _excelWorker.GetColumnNumberForAllHeaders(headers);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetColumnNumberForAllHeaders_ReturnsEmptyDictionary_WhenAllHeaderIsNotExist()
        {
            // Arrange
            var row = 1;
            var column = 1;
            var expected = new Dictionary<string, List<int>>();
            var headers = new List<string>
                { "Номера" ,
                 "Best Lap" ,
                 "ХІТ" };
            var headersCells = new List<IExcelRange>();
            _mockSearcher.Setup(x => x.GetCellsByValue(It.IsAny<string>(), null)).Returns(new List<IExcelRange>());

            // Act
            var result = _excelWorker.GetColumnNumberForAllHeaders(headers);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}