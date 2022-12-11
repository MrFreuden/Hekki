using AutoFixture;
using ExcelController;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelWorkerTest
{
    [TestFixture]
    public class ReaderTests
    {
        private static Fixture _fixture = new();
        private ExcelWorker excelWorker;
        private List<string> namesFromTxt;
        private int countPilots;

        [OneTimeSetUp]
        public void Setup()
        {
            ExcelWorker.excel.ActiveWorkbook.Sheets["ExcelTests"].Select();
            namesFromTxt = ExcelWorker.ReadNamesInTotalBoard();
            countPilots = namesFromTxt.Count;
        }

        [Test, Order(1)]
        public void ReadNamesInTotalBoard_MethodIsInvoked_CorrectValue()
        {
            // Arrange
            
            // Act
            var sut = ExcelWorker.ReadNamesInTotalBoard();
            // Assert
            int row = 4;
            for (int i = 0; i < sut.Count; i++, row++)
            {
                Assert.AreEqual(ExcelWorker.excel.Cells[row, 5].Value.ToString(), sut[i]);
            }
        }

        [Test]
        public void ReadUsedKartsInTotalBoard_MethodIsInvoked_CorrectValue()
        {
            // Arrange

            // Act
            var sut = ExcelWorker.ReadUsedKartsInTotalBoard();

            // Assert
            int row = 4;
            for (int i = 0; i < countPilots; i++, row++)
            {
                for (int j = 0; j < sut[i].Count; j++)
                {
                    Assert.AreEqual(ExcelWorker.excel.Cells[row, 4].Value.ToString()[j] - '0', sut[i][j]);
                }
            }
        }

        [Test]
        public void ReadScoresInTotalBoard_MethodIsInvoked_CorrectValue()
        {
            // Arrange

            // Act
            var sut = ExcelWorker.ReadScoresInTotalBoard(
                countPilots);

            // Assert
            
            int col = 9;
            for (int i = 0; i < 5; i++, col++)
            {
                int row = 4;
                for (int j = 0; j < countPilots; j++, row++)
                {
                    Assert.AreEqual(ExcelWorker.excel.Cells[row, col].Value.ToString(), sut[j][i].ToString());
                }
            }
        }

        [Test]
        public void ReadTimesInTotalBoard_MethodIsInvoked_CorrectValue()
        {
            // Arrange

            // Act
            var sut = ExcelWorker.ReadTimesInTotalBoard(
                countPilots);

            // Assert
            int col = 6;
            for (int i = 0; i < 3; i++, col++)
            {
                int row = 4;
                for (int j = 0; j < countPilots; j++, row++)
                {
                    Assert.AreEqual(ExcelWorker.excel.Cells[row, col].Value.ToString(), sut[j][i]);
                }
            }
        }

        [Test]
        public void ReadLique_MethodIsInvoked_CorrectValue()
        {
            // Arrange

            // Act
            var sut = ExcelWorker.ReadLique(
                countPilots);

            // Assert
            int row = 4;
            for (int i = 0; i < sut.Count; i++, row++)
            {
                Assert.AreEqual(ExcelWorker.excel.Cells[row, 3].Value.ToString(), sut[i]);
            }
        }

        [Test]
        public void ReadScoresInRace_MethodIsInvoked_CorrectValue()
        {
            // Arrange

            // Act
            var sut = ExcelWorker.ReadScoresInRace(
                namesFromTxt);

            // Assert
            int col = 22;
            for (int i = 0; i < 1; i++)
            {
                int row = 4;
                for (int j = 0; j < countPilots; j++, row++)
                {
                    Assert.AreEqual(ExcelWorker.excel.Cells[row, col].Value.ToString(), sut[j][i]);
                }
            }
        }

        [Test]
        public void ReadScoresInRaceEveryOnEvery_MethodIsInvoked_CorrectValue()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List<string> pilots = null;
            int countInGroup = 0;

            // Act
            var result = ExcelWorker.ReadScoresInRaceEveryOnEvery(
                pilots,
                countInGroup);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ReadTimeInRace_MethodIsInvoked_CorrectValue()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List<string> pilots = null;

            // Act
            var result = ExcelWorker.ReadTimeInRace(
                pilots);

            // Assert
            Assert.Fail();
        }
    }
}