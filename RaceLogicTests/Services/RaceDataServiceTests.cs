using ExcelController.Interfaces;
using Moq;
using RaceLogic.Services;

namespace RaceLogicTests.Services
{
    public class RaceDataServiceTests
    {
        private Mock<IExcelWorker> _excelWorkerMock;
        private RaceDataService _raceDataService;

        [SetUp]
        public void Setup()
        {
            _excelWorkerMock = new Mock<IExcelWorker>();
            _excelWorkerMock.Setup(x => x.GetColumnNumberForAllHeaders(It.IsAny<List<string>>()))
                            .Returns(new Dictionary<string, List<int>>
                            {
                                { "Ліга", new List<int> { 1 } },
                                { "Ім'я", new List<int> { 2 } },
                                { "Номера", new List<int> { 3 } },
                                { "Best Lap", new List<int> { 4 } },
                                { "ХІТ", new List<int> { 5 } },
                                { "Карт", new List<int> { 6 } },
                                { "Пілоти", new List<int> { 7 } },
                                { "Штраф", new List<int> { 8 } },
                                { "Час", new List<int> { 9 } },
                                { "Очки", new List<int> { 10 } }
                            });
            _raceDataService = new RaceDataService(_excelWorkerMock.Object);
        }

        [Test]
        public void ReadLiquesInBoard_ShouldReturnCorrectData()
        {
            // Arrange
            int countRows = 5;
            var expectedData = new List<string> { "Лига1", "Лига2", "Лига3", "Лига4", "Лига5" };
            _excelWorkerMock.Setup(x => x.ReadDataInColumn(It.IsAny<int>(), It.IsAny<int>(), countRows))
                            .Returns(expectedData);

            // Act
            var result = _raceDataService.ReadLiquesInBoard(countRows);

            // Assert
            Assert.AreEqual(expectedData, result);
        }

        [Test]
        public void ReadNamesInBoard_ShouldReturnCorrectData()
        {
            // Arrange
            int countRows = 5;
            var expectedData = new List<string> { "Имя1", "Имя2", "Имя3", "Имя4", "Имя5" };
            _excelWorkerMock.Setup(x => x.ReadDataInColumn(It.IsAny<int>(), It.IsAny<int>(), countRows))
                            .Returns(expectedData);

            // Act
            var result = _raceDataService.ReadNamesInBoard(countRows);

            // Assert
            Assert.AreEqual(expectedData, result);
        }

        [Test]
        public void WriteDataInfoInBoard_ShouldWriteDataCorrectly()
        {
            // Arrange
            var data = new List<string> { "Data1", "Data2", "Data3" };
            string nameOfColumn = "Очки";
            int number = 0;
            _excelWorkerMock.Setup(x => x.WriteDataInColumn(data, It.IsAny<int>(), It.IsAny<int>()));

            // Act
            _raceDataService.WriteDataInfoInBoard(data, nameOfColumn, number);

            // Assert
            _excelWorkerMock.Verify(x => x.WriteDataInColumn(data, It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void WriteUsedKartsInBoard_ShouldAppendDataCorrectly()
        {
            // Arrange
            var karts = new List<int> { 1, 2, 3, 4, 5 };
            _excelWorkerMock.Setup(x => x.AppendDataInColumn(karts, It.IsAny<int>(), It.IsAny<int>()));

            // Act
            _raceDataService.WriteUsedKartsInBoard(karts);

            // Assert
            _excelWorkerMock.Verify(x => x.AppendDataInColumn(karts, It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void WriteDataInfoInRace_ShouldWriteDataCorrectly()
        {
            // Arrange
            var data = new List<List<string>>
            {
                new List<string> { "Data1", "Data2", "Data3" },
                new List<string> { "Data4", "Data5", "Data6" }
            };
            string nameOfColumn = "Очки";
            var countRows = new List<int> { 3, 3 };
            _excelWorkerMock.Setup(x => x.WriteDataInEmptyColumn(It.IsAny<List<string>>(), It.IsAny<int>(), nameOfColumn));

            // Act
            _raceDataService.WriteDataInfoInRace(data, nameOfColumn, countRows);

            // Assert
            _excelWorkerMock.Verify(x => x.WriteDataInEmptyColumn(data[0], It.IsAny<int>(), nameOfColumn), Times.Once);
            _excelWorkerMock.Verify(x => x.WriteDataInEmptyColumn(data[1], It.IsAny<int>(), nameOfColumn), Times.Once);
        }
    }
}