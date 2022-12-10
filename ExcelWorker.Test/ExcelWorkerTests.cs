using ExcelController;
using NUnit.Framework;
using System;

namespace ExcelWorker.Test
{
    [TestFixture]
    public class ExcelWorkerTests
    {
        [Test]
        public void GetExcel_StateUnderTest_ExpectedBehavior()
        {
            
            // Arrange
            var excelWorker = new ExcelWorker();

            // Act
            var result = excelWorker.GetExcel();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void FindKeyCellByValue_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            string value = null;
            bool needEmpty = false;
            Range searchedRange = null;

            // Act
            var result = excelWorker.FindKeyCellByValue(
                value,
                needEmpty,
                searchedRange);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void FindKeyCellByValue_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            string value = null;
            Range searchedRange = null;

            // Act
            var result = excelWorker.FindKeyCellByValue(
                value,
                searchedRange);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void CleanData_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            Range rangeToClean = null;
            int countBellow = 0;
            bool debugMode = false;

            // Act
            excelWorker.CleanData(
                rangeToClean,
                countBellow,
                debugMode);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void GetTotalBoardRange_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            int countPilots = 0;

            // Act
            var result = excelWorker.GetTotalBoardRange(
                countPilots);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void CleanColumnAfterKey_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            Range keyCell = null;

            // Act
            excelWorker.CleanColumnAfterKey(
                keyCell);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void DeleteLastUsedKartsInTotalBoard_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();

            // Act
            excelWorker.DeleteLastUsedKartsInTotalBoard();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ReadTestNamesFromTxt_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();

            // Act
            var result = excelWorker.ReadTestNamesFromTxt();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ReadNamesInTotalBoard_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();

            // Act
            var result = excelWorker.ReadNamesInTotalBoard();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ReadUsedKartsInTotalBoard_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();

            // Act
            var result = excelWorker.ReadUsedKartsInTotalBoard();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ReadScoresInTotalBoard_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            int countPilots = 0;

            // Act
            var result = excelWorker.ReadScoresInTotalBoard(
                countPilots);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ReadTimesInTotalBoard_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            int countPilots = 0;

            // Act
            var result = excelWorker.ReadTimesInTotalBoard(
                countPilots);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ReadLique_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            int countPilots = 0;

            // Act
            var result = excelWorker.ReadLique(
                countPilots);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ReadScoresInRace_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List pilots = null;

            // Act
            var result = excelWorker.ReadScoresInRace(
                pilots);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ReadScoresInRaceEveryOnEvery_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List pilots = null;
            int countInGroup = 0;

            // Act
            var result = excelWorker.ReadScoresInRaceEveryOnEvery(
                pilots,
                countInGroup);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ReadTimeInRace_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List pilots = null;

            // Act
            var result = excelWorker.ReadTimeInRace(
                pilots);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void WriteLique_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List pilotsLiques = null;

            // Act
            excelWorker.WriteLique(
                pilotsLiques);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void WriteNamesInRace_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List pilotsNamesByGroup = null;
            int numberRace = 0;

            // Act
            excelWorker.WriteNamesInRace(
                pilotsNamesByGroup,
                numberRace);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void WriteKartsInRace_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List pilotsKartsByGroup = null;
            int numberRace = 0;

            // Act
            excelWorker.WriteKartsInRace(
                pilotsKartsByGroup,
                numberRace);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void WriteUsedKarts_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List pilotsKarts = null;

            // Act
            excelWorker.WriteUsedKarts(
                pilotsKarts);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void WriteUsedKartsAmators_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List pilotsKarts = null;
            int countMargin = 0;

            // Act
            excelWorker.WriteUsedKartsAmators(
                pilotsKarts,
                countMargin);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void WriteScoreInTotalBoard_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List pilotsScores = null;

            // Act
            excelWorker.WriteScoreInTotalBoard(
                pilotsScores);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void WriteTimeInTotalBoard_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List pilotsTimes = null;

            // Act
            excelWorker.WriteTimeInTotalBoard(
                pilotsTimes);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void WriteNamesInTotalBoard_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List names = null;

            // Act
            excelWorker.WriteNamesInTotalBoard(
                names);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void WriteUsedKartsInTotalBoard_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List numberKarts = null;

            // Act
            excelWorker.WriteUsedKartsInTotalBoard(
                numberKarts);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void WriteTestData_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            string path = null;
            string keyWord = null;
            Range range = null;

            // Act
            excelWorker.WriteTestData(
                path,
                keyWord,
                range);

            // Assert
            Assert.Fail();
        }
    }
}
