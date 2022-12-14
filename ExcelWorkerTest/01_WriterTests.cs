using AutoFixture;
using ExcelController;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelWorkerTest
{
    [TestFixture]
    public class WriterTests
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
        public void WriteLique_MethodIsInvoked_ExcelCorrectValue()
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
        public void WriteNamesInRace_MethodIsInvoked_ExcelCorrectValue()
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
            ExcelWorker.WriteInfoDataInRace(
                "Пилоты",
                pilotsNamesByGroup);

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
        public void WriteKartsInRace_MethodIsInvoked_ExcelCorrectValue()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(1, 8));
            List<List<string>> pilotsKartsByGroup = new();

            int countGroups = (int)Math.Ceiling((double)countValues / ExcelWorker.MAXkarts);
            for (int i = 0; i < countGroups; i++)
                pilotsKartsByGroup.Add(new List<string>());

            for (int i = 0, j = 0; j < countValues; i++, j++)
            {
                if (i == countGroups)
                    i = 0;
                var val = fixture.Create<int>();
                pilotsKartsByGroup[i].Add(val.ToString());
            }
            int numberRace = 0;

            // Act
            ExcelWorker.WriteInfoDataInRace(
                "Карт",
                pilotsKartsByGroup);

            // Assert
            int row = 4;
            int col = 17;
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
                var val = pilotsKartsByGroup[j][i].ToString();
                Assert.AreEqual(ex, val);
            }
        }

        [Test]
        public void WriteUsedKarts_MethodIsInvoked_ExcelCorrectValue()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(1, 8));
            List<string> pilotsKarts = new();
            for (int i = 0; i < countValues; i++)
            {
                pilotsKarts.Add(Convert.ToString(fixture.Create<int>()));
            }
            // Act
            ExcelWorker.WriteUsedKarts(
                pilotsKarts);

            // Assert
            int row = 4;
            for (int i = 0; i < countValues; i++, row++)
            {
                Assert.AreEqual(ExcelWorker.excel.Cells[row, 4].Value.ToString(), pilotsKarts[i]);
            }
        }

        [Test, Order(1)]
        public void WriteUsedKartsAmators_MethodIsInvoked_ExcelCorrectValue()
        {
            // Arrange
            List<string> pilotsKarts = new();
            int countMargin = 4;
            var fixture = new Fixture();
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(1, 8));
            int count = fixture.Create<int>();
            for (int i = 0; i < count; i++)
            {
                pilotsKarts.Add(Convert.ToString(fixture.Create<int>()));
            }

            // Act
            ExcelWorker.WriteUsedKartsAmators(
                pilotsKarts,
                countMargin);

            // Assert
            int row = 4 + countMargin;
            for (int i = 0; i < count; i++, row++)
            {
                Assert.AreEqual(ExcelWorker.excel.Cells[row, 4].Value.ToString(), pilotsKarts[i]);
            }
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
        public void WriteNamesInTotalBoard_MethodIsInvoked_ExcelCorrectValue()
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
        public void WriteUsedKartsInTotalBoard_MethodIsInvoked_ExcelCorrectValue()
        {
            // Arrange
            List<List<int>> numberKarts = new();
            var fixture = new Fixture();
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(1, 8));
            for (int i = 0; i < countValues; i++)
            {
                numberKarts.Add(new List<int>());
                for (int j = 0; j < 1; j++)
                {
                    numberKarts[i].Add(fixture.Create<int>());
                }
            }


            // Act
            ExcelWorker.WriteUsedKartsInTotalBoard(
                numberKarts);

            // Assert
            int row = 4;
            for (int i = 0; i < countValues; i++, row++)
            {
                Assert.AreEqual(ExcelWorker.excel.Cells[row, 4].Value.ToString(), numberKarts[i][0].ToString());
            }
        }
    }
}