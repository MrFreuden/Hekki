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
            Assert.That(result, Is.EqualTo(expectedData));
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
            Assert.That(result, Is.EqualTo(expectedData));
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
                new() { "Data1", "Data2", "Data3" },
                new() { "Data4", "Data5", "Data6" }
            };
            var dataE = new List<string> { "Data1", "Data2", "Data3", null, null, null, null, null, null, null, 
                                            "Data4", "Data5", "Data6", null, null, null, null, null, null, null };
            string nameOfColumn = "Очки";
            _excelWorkerMock.Setup(x => x.WriteDataInEmptyColumn(It.IsAny<List<string>>(), It.IsAny<int>(), nameOfColumn));

            // Act
            _raceDataService.WriteDataInfoInRace(data, nameOfColumn);

            // Assert
            _excelWorkerMock.Verify(x => x.WriteDataInEmptyColumn(dataE, It.IsAny<int>(), nameOfColumn), Times.Once);
        }

        [Test]
        public void WriteDataInfoInRace_ShouldNotWrite_WhenDataIsEmpty()
        {
            // Arrange
            var data = new List<List<string>>();
            string nameOfColumn = "Очки";

            // Act
            _raceDataService.WriteDataInfoInRace(data, nameOfColumn);

            // Assert
            _excelWorkerMock.Verify(x => x.WriteDataInEmptyColumn(It.IsAny<List<string>>(), It.IsAny<int>(), nameOfColumn), Times.Never);
        }

        [Test]
        public void WriteDataInfoInRace_ShouldNotWrite_WhenNameOfColumnDoesNotExist()
        {
            // Arrange
            var data = new List<List<string>>();
            string nameOfColumn = "DoesNotExist";
            // Act
            _raceDataService.WriteDataInfoInRace(data, nameOfColumn);

            // Assert
            _excelWorkerMock.Verify(x => x.WriteDataInColumn(It.IsAny<List<string>>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void WriteDataInfoInRace_ShouldThrowException_WhenDataCountExceedsMaxKarts()
        {
            // Arrange
            var data = new List<List<string>>();
            for (int i = 0; i < RaceDataService.MaxKarts + 1; i++)
            {
                data.Add(new List<string> { $"Data{i}" });
            }
            string nameOfColumn = "Очки";

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _raceDataService.WriteDataInfoInRace(data, nameOfColumn));
            Assert.That(ex.Message, Is.EqualTo("Количество подсписков превышает MaxKarts"));
        }

        [Test]
        public void ReadResultsInBoard_ReturnCorrect()
        {
            // Arrange
            var data = new List<string>() { "1", "2", "3" };
            var expected = new List<List<int>>() { new() { 1, 2, 3 } };
            var countRows = 3;
            string nameOfColumn = "ХІТ";
            _excelWorkerMock.Setup(x => x.ReadDataInColumn(RaceDataService.StartRowByDefault, It.IsAny<int>(), countRows)).Returns(data);

            // Act
            var result = _raceDataService.ReadResultsInBoard(nameOfColumn, countRows);

            // Assert
           Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ReadResultsInBoard_ReturnCorrect_WhenCountRowsMoreThanDataCount()
        {
            // Arrange
            var data = new List<string>() { "1", "2", "3" };
            var expected = new List<List<int>>() { new() { 1, 2, 3 } };
            var countRows = 5;
            string nameOfColumn = "ХІТ";
            _excelWorkerMock.Setup(x => x.ReadDataInColumn(RaceDataService.StartRowByDefault, It.IsAny<int>(), countRows)).Returns(data);

            // Act
            var result = _raceDataService.ReadResultsInBoard(nameOfColumn, countRows);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ReadResultsInBoard_ReturnEmptyList_WhenNameOfColumnDoesNotExist()
        {
            // Arrange
            var expected = new List<List<int>>();
            var countRows = 3;
            string nameOfColumn = "DoesNotExist";

            // Act
            var result = _raceDataService.ReadResultsInBoard(nameOfColumn, countRows);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ReadResultsInBoard_ShouldThrowException_WhenDataContainsLetters()
        {
            // Arrange
            var data = new List<string>() { "A", "B", "C" };
            var countRows = 3;
            string nameOfColumn = "ХІТ";
            _excelWorkerMock.Setup(x => x.ReadDataInColumn(RaceDataService.StartRowByDefault, It.IsAny<int>(), countRows)).Returns(data);

            // Act & Assert
            var ex = Assert.Throws<FormatException>(() => _raceDataService.ReadResultsInBoard(nameOfColumn, countRows));
            Assert.That(ex.Message, Is.EqualTo("Input string was not in a correct format."));
        }

        [Test]
        public void ReadResultsInRace_ShouldReturnCorrectData()
        {
            // Arrange
            var data = new List<List<string>> { new() { "1", "2", "3" } };
            var expected = new List<List<int>> { new() { 1, 2, 3 } };
            string nameOfColumn = "Очки";
            _excelWorkerMock.Setup(x => x.ReadDataInColumnsByNameInRace(nameOfColumn, It.IsAny<int>())).Returns(data);

            // Act
            var result = _raceDataService.ReadResultsInRace(nameOfColumn, 3);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ReadResultsInRace_ShouldThrowException_WhenDataContainsLetters()
        {
            // Arrange
            var data = new List<List<string>> { new() { "A", "B", "C" } };
            var countRows = 3;
            string nameOfColumn = "ХІТ";
            _excelWorkerMock.Setup(x => x.ReadDataInColumnsByNameInRace(nameOfColumn, It.IsAny<int>())).Returns(data);

            // Act & Assert
            var ex = Assert.Throws<FormatException>(() => _raceDataService.ReadResultsInRace(nameOfColumn, countRows));
            Assert.That(ex.Message, Is.EqualTo("Input string was not in a correct format."));
        }

        [Test]
        public void ReadUsedKartsInBoard_ShouldReturnCorrectData()
        {
            // Arrange
            var data = new List<string> { "1 2 3", "4 5 6" };
            var expected = new List<List<int>> { new() { 1, 2, 3 }, new() { 4, 5, 6 } };
            int count = 2;
            _excelWorkerMock.Setup(x => x.ReadDataInColumn(RaceDataService.StartRowByDefault, It.IsAny<int>(), count)).Returns(data);

            // Act
            var result = _raceDataService.ReadUsedKartsInBoard(count);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ReadUsedKartsInBoard_ShouldThrowException_WhenDataContainsLetters()
        {
            // Arrange
            var data = new List<string>  { "A", "B", "C" };
            var countRows = 3;
            string nameOfColumn = "ХІТ";
            _excelWorkerMock.Setup(x => x.ReadDataInColumn(It.IsAny<int>(), It.IsAny<int>(), countRows)).Returns(data);
            // Act & Assert
            var ex = Assert.Throws<FormatException>(() => _raceDataService.ReadUsedKartsInBoard(countRows));
            Assert.That(ex.Message, Is.EqualTo("Input string was not in a correct format."));
        }
    }
}