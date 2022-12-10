using AutoFixture;
using ExcelController;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelWorkerTest
{
    [TestFixture]
    public class ExcelWorkerTests
    {
        private static Fixture _fixture = new();
        private ExcelWorker excelWorker;
        private List<string> namesFromTxt;
        private int countValues;

        [OneTimeSetUp]
        public void Setup()
        {
            excelWorker = new();
            countValues = GetCountOfPilosValues();
            namesFromTxt = ExcelWorker.ReadTestNamesFromTxt();
            namesFromTxt.RemoveRange(0, namesFromTxt.Count - countValues);

            ExcelWorker.excel.ActiveWorkbook.Sheets["ExcelTests"].Select();
            ExcelWorker.CleanData();
        }

        private int GetCountOfPilosValues()
        {
            var fixtureForCountValues = new Fixture();
            fixtureForCountValues.Customizations.Add(
                new RandomNumericSequenceGenerator(8, 40));
            return fixtureForCountValues.Create<int>();
        }

        [Test]
        public void GetExcel_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();

            // Act
            var result = ExcelWorker.GetExcel();

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
            Range searchedRange = (Range)Type.Missing;

            // Act
            var result = ExcelWorker.FindKeyCellByValue(
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
            Range searchedRange = (Range)Type.Missing;

            // Act
            var result = ExcelWorker.FindKeyCellByValue(
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
            Range rangeToClean = (Range)Type.Missing;
            int countBellow = 0;
            bool debugMode = false;

            // Act
            ExcelWorker.CleanData(
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
            var result = ExcelWorker.GetTotalBoardRange(
                countPilots);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void CleanColumnAfterKey_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            Range keyCell = (Range)Type.Missing;

            // Act
            ExcelWorker.CleanColumnAfterKey(
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
            ExcelWorker.DeleteLastUsedKartsInTotalBoard();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ReadTestNamesFromTxt_Names_ListNamesFromTxt()
        {
            // Arrange
            var excpected = new string[]
            {
                "MARTOLOG",
                "OLIFIRENKO",
                "ILLYAS",
                "KARLENKO",
                "KOPTYEV",
                "MARTYNENKO",
                "LAGODZYA",
                "BARANIUK",
                "BRAZHNIKOV",
                "VOLOSHYN",
                "KOVALCHUK",
                "YATSENKO",
                "SEMENEC",
                "RUDENKO",
                "FEDORCHUK M.",
                "KORDIK",
                "PORTYANKO",
                "DODONOV",
                "SHARAPOV",
                "MANAIENKO"
            };

            // Act
            var result = ExcelWorker.ReadTestNamesFromTxt().ToArray();

            // Assert
            for (int i = 0; i < excpected.Length; i++)
            {
                Assert.AreEqual(excpected[i], result[i]);
            }
        }

        [Test]
        public void ReadNamesInTotalBoard_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excpected = new ExcelWorker();

            // Act
            var result = ExcelWorker.ReadNamesInTotalBoard();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ReadUsedKartsInTotalBoard_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();

            // Act
            var result = ExcelWorker.ReadUsedKartsInTotalBoard();

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
            var result = ExcelWorker.ReadScoresInTotalBoard(
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
            var result = ExcelWorker.ReadTimesInTotalBoard(
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
            var result = ExcelWorker.ReadLique(
                countPilots);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ReadScoresInRace_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List<string> pilots = null;

            // Act
            var result = ExcelWorker.ReadScoresInRace(
                pilots);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void ReadScoresInRaceEveryOnEvery_StateUnderTest_ExpectedBehavior()
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
        public void ReadTimeInRace_StateUnderTest_ExpectedBehavior()
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

        [Test]
        public void WriteLique_MethodIsInvoked_CorrectValue()
        {
            // Arrange
            var liqueLabels = new List<string>(2) { "Am", "Pro" };
            Random rnd = new();
            List<string> pilotsLiques = new();
            for (int i = 0; i < countValues; i++)
            {
                pilotsLiques.Add(liqueLabels[rnd.Next(0, 2)]);
            }

            // Act
            ExcelWorker.WriteLique(
                pilotsLiques);

            // Assert
            int row = 4;
            for (int i = 0; i < countValues; i++, row++)
            {
                Assert.AreEqual(ExcelWorker.excel.Cells[row, 3].Value.ToString(), pilotsLiques[i]);
            }
        }

        [Test]
        public void WriteNamesInRace_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            List<List<string>> pilotsNamesByGroup = new();
            int countGroups = (int)Math.Ceiling((double)countValues / ExcelWorker.MAXkarts);
            for (int i = 0; i < countGroups; i++)
                pilotsNamesByGroup.Add(new List<string>());

            for (int i = 0, j = 0; j < countValues; i++, j++)
            {
                if (i == countGroups)
                    i = 0;
                pilotsNamesByGroup[i].Add(namesFromTxt[j]);
            }
            int numberRace = 0;

            // Act
            ExcelWorker.WriteNamesInRace(
                pilotsNamesByGroup,
                numberRace);

            // Assert
            int row = 4;
            int col = 19;
            for (int i = 0, j = 0; row < ExcelWorker.MAXkarts * countGroups + 4; i++, row++)
            {
                if (i % ExcelWorker.MAXkarts == 0 && i != 0)
                {
                    j++;
                    row--;
                    i = -1;
                    continue;
                }
                var ex = Convert.ToString(ExcelWorker.excel.Cells[row, col].Value);
                ex ??= "";
                var val = pilotsNamesByGroup[j][i].ToString();
                Assert.AreEqual(ex, val);   
                
            }
        }

        [Test]
        public void WriteKartsInRace_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List<List<string>> pilotsKartsByGroup = null;
            int numberRace = 0;

            // Act
            ExcelWorker.WriteKartsInRace(
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
            List<string> pilotsKarts = null;

            // Act
            ExcelWorker.WriteUsedKarts(
                pilotsKarts);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void WriteUsedKartsAmators_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var excelWorker = new ExcelWorker();
            List<string> pilotsKarts = null;
            int countMargin = 0;

            // Act
            ExcelWorker.WriteUsedKartsAmators(
                pilotsKarts,
                countMargin);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void WriteScoreInTotalBoard_MethodIsInvoked_CorrectValue()
        {
            // Arrange
            List<List<string>> pilotsScores = new();

            for (int i = 0; i < countValues; i++)
            {
                pilotsScores.Add(new List<string>());
                for (int j = 0; j < 5; j++)
                {
                    pilotsScores[i].Add(_fixture.Create<int>().ToString());
                }
            }

            // Act
            ExcelWorker.WriteScoreInTotalBoard(
                pilotsScores);

            // Assert
            int row = 4;
            for (int i = 0; i < countValues; i++, row++)
            {
                int col = 9;
                for (int j = 0; j < 5; j++, col++)
                {
                    Assert.AreEqual(ExcelWorker.excel.Cells[row, col].Value.ToString(), pilotsScores[i][j]);
                }
            }
        }

        [Test]
        public void WriteTimeInTotalBoard_MethodIsInvoked_CorrectValue()
        {
            // Arrange
            List<List<string>> pilotsTimes = new();

            for (int i = 0; i < countValues; i++)
            {
                pilotsTimes.Add(new List<string>());
                for (int j = 0; j < 3; j++)
                {
                    pilotsTimes[i].Add(_fixture.Create<int>().ToString());
                }
            }

            // Act
            ExcelWorker.WriteTimeInTotalBoard(
                pilotsTimes);

            // Assert
            int row = 4;
            for (int i = 0; i < countValues; i++, row++)
            {
                int col = 6;
                for (int j = 0; j < 3; j++, col++)
                {
                    Assert.AreEqual(ExcelWorker.excel.Cells[row, col].Value.ToString(), pilotsTimes[i][j]);
                }
            }
        }

        [Test]
        public void WriteNamesInTotalBoard_MethodIsInvoked_CorrectValue()
        {
            // Arrange
            List<string> names = namesFromTxt;

            // Act
            ExcelWorker.WriteNamesInTotalBoard(
                names);

            // Assert
            int row = 4;
            for (int i = 0; i < names.Count; i++, row++)
            {
                Assert.AreEqual(ExcelWorker.excel.Cells[row, 5].Value.ToString(), names[i]);
            }
        }

        [Test]
        public void WriteUsedKartsInTotalBoard_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            List<List<int>> numberKarts = new();

            // Act
            ExcelWorker.WriteUsedKartsInTotalBoard(
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
            Range range = (Range)Type.Missing;

            // Act
            ExcelWorker.WriteTestData(
                path,
                keyWord,
                range);

            // Assert
            Assert.Fail();
        }
    }
}
