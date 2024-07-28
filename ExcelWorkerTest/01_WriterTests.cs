using AutoFixture;
using ExcelController;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelWorkerTest
{
    [TestFixture]
    public class WriterTests
    {
        private static readonly Fixture _fixture = new();
        private ExcelWorker _excelWorker;
        private List<string> _namesFromTxt;
        private int _countValues;

        [OneTimeSetUp]
        public void Setup()
        {
            _excelWorker = new ExcelWorker();
            _countValues = GetCountOfPilosValues();
            _namesFromTxt = ExcelRead.ReadTestNamesFromTxt().Take(_countValues).ToList();

            ExcelWorker.excel.ActiveWorkbook.Sheets["ExcelTests"].Select();
            ExcelWrite.CleanData();
        }

        private int GetCountOfPilosValues()
        {
            var fixtureForCountValues = new Fixture();
            fixtureForCountValues.Customizations.Add(new RandomNumericSequenceGenerator(8, 40));
            return fixtureForCountValues.Create<int>();
        }

        [Test]
        public void WriteLique_MethodIsInvoked_ExcelCorrectValue()
        {
            // Arrange
            var liqueLabels = new List<string> { "Am", "Pro" };
            var pilotsLiques = Enumerable.Range(0, _countValues)
                                         .Select(_ => liqueLabels[_fixture.Create<int>() % 2])
                                         .ToList();

            // Act
            ExcelWrite.WriteDataInCol("Ліга", pilotsLiques);

            // Assert
            AssertColumnValues("Ліга", pilotsLiques);
        }

        [Test]
        public void WriteNamesInRace_MethodIsInvoked_ExcelCorrectValue()
        {
            // Arrange
            var pilotsNamesByGroup = GroupValues(_namesFromTxt, ExcelWorker.MAXkarts);

            // Act
            ExcelWrite.WriteInfoDataInRace("Пілоти", pilotsNamesByGroup);

            // Assert
            AssertGroupedValues("Пілоти", pilotsNamesByGroup);
        }

        [Test]
        public void WriteKartsInRace_MethodIsInvoked_ExcelCorrectValue()
        {
            // Arrange
            var pilotsKartsByGroup = GroupValues(GenerateRandomValues(_countValues, 1, 8), ExcelWorker.MAXkarts);

            // Act
            ExcelWrite.WriteInfoDataInRace("Карт", pilotsKartsByGroup);

            // Assert
            AssertGroupedValues("Карт", pilotsKartsByGroup);
        }

        [Test]
        public void WriteUsedKarts_MethodIsInvoked_ExcelCorrectValue()
        {
            // Arrange
            var pilotsKarts = GenerateRandomValues(_countValues, 1, 8);

            // Act
            ExcelWrite.WriteDataInCol("Номера", pilotsKarts);

            // Assert
            AssertColumnValues("Номера", pilotsKarts);
        }

        [Test, Order(1)]
        public void WriteUsedKartsAmators_MethodIsInvoked_ExcelCorrectValue()
        {
            // Arrange
            var pilotsKarts = GenerateRandomValues(_countValues, 1, 8);

            // Act
            ExcelWrite.WriteDataInCol("Номера", pilotsKarts);

            // Assert
            AssertColumnValues("Номера", pilotsKarts);
        }

        [Test]
        public void WriteScoreInTotalBoard_MethodIsInvoked_CorrectValue()
        {
            // Arrange
            var pilotsScores = GenerateRandomMatrix(_countValues, 4);

            // Act
            ExcelWrite.WriteResultsInTB("Хіт", pilotsScores);

            // Assert
            AssertMatrixValues("Хіт", pilotsScores);
        }

        [Test]
        public void WriteTimeInTotalBoard_MethodIsInvoked_CorrectValue()
        {
            // Arrange
            var pilotsTimes = GenerateRandomMatrix(_countValues, 2);

            // Act
            ExcelWrite.WriteResultsInTB("Best Lap", pilotsTimes);

            // Assert
            AssertMatrixValues("Best Lap", pilotsTimes);
        }

        [Test]
        public void WriteNamesInTotalBoard_MethodIsInvoked_ExcelCorrectValue()
        {
            // Arrange
            var names = _namesFromTxt;

            // Act
            ExcelWrite.WriteDataInCol("Ім'я", names);

            // Assert
            AssertColumnValues("Ім'я", names);
        }

        [Test]
        public void WriteUsedKartsInTotalBoard_MethodIsInvoked_ExcelCorrectValue()
        {
            // Arrange
            var numberKarts = GenerateRandomIntMatrix(_countValues, 1);

            // Act
            ExcelWrite.WriteUsedKartsInTotalBoard(numberKarts);

            // Assert
            AssertMatrixValues("Номера", numberKarts);
        }

        private void AssertColumnValues(string columnName, List<string> expectedValues, int startRow = 4)
        {
            int column = GetColumnIndexByName(columnName);
            for (int i = 0; i < expectedValues.Count; i++)
            {
                Assert.AreEqual(expectedValues[i], ExcelWorker.excel.Cells[startRow + i, column].Value.ToString());
            }
        }

        private void AssertGroupedValues(string columnName, List<List<string>> groupedValues, int startRow = 4)
        {
            int column = GetColumnIndexByName(columnName);
            int row = startRow;
            foreach (var group in groupedValues)
            {
                foreach (var value in group)
                {
                    Assert.AreEqual(value, ExcelWorker.excel.Cells[row++, column].Value.ToString());
                }
            }
        }

        private void AssertMatrixValues(string columnName, List<List<int>> matrixValues, int startRow = 4)
        {
            int startColumn = GetColumnIndexByName(columnName);
            for (int i = 0; i < matrixValues.Count; i++)
            {
                for (int j = 0; j < matrixValues[i].Count; j++)
                {
                    Assert.AreEqual(matrixValues[i][j].ToString(), ExcelWorker.excel.Cells[startRow + i, startColumn + j].Value.ToString());
                }
            }
        }

        private void AssertMatrixValues(string columnName, List<List<string>> matrixValues, int startRow = 4)
        {
            int startColumn = GetColumnIndexByName(columnName);
            for (int i = 0; i < matrixValues.Count; i++)
            {
                for (int j = 0; j < matrixValues[i].Count; j++)
                {
                    Assert.AreEqual(matrixValues[i][j], ExcelWorker.excel.Cells[startRow + i, startColumn + j].Value.ToString());
                }
            }
        }

        private int GetColumnIndexByName(string columnName)
        {
            var columnIndices = new Dictionary<string, int>
            {
                { "Ліга", 3 },
                { "Пілоти", 18 },
                { "Карт", 17 },
                { "Номера", 4 },
                { "Ім'я", 5 },
                { "Хіт", 9 },
                { "Best Lap", 6 }
            };

            return columnIndices[columnName];
        }

        private List<List<string>> GenerateRandomMatrix(int rows, int cols)
        {
            return Enumerable.Range(0, rows)
                             .Select(_ => GenerateRandomValues(cols, 1, 100))
                             .ToList();
        }

        private List<string> GenerateRandomValues(int count, int minValue, int maxValue)
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(minValue, maxValue));
            return Enumerable.Range(0, count).Select(_ => fixture.Create<int>().ToString()).ToList();
        }

        private List<List<int>> GenerateRandomIntMatrix(int rows, int cols)
        {
            return Enumerable.Range(0, rows)
                             .Select(_ => GenerateRandomIntValues(cols, 1, 100))
                             .ToList();
        }

        private List<int> GenerateRandomIntValues(int count, int minValue, int maxValue)
        {
            var fixture = new Fixture();
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(minValue, maxValue));
            return Enumerable.Range(0, count).Select(_ => fixture.Create<int>()).ToList();
        }

        private List<List<string>> GroupValues(List<string> values, int groupSize)
        {
            return values.Select((value, index) => new { value, index })
                         .GroupBy(x => x.index / groupSize)
                         .Select(g => g.Select(x => x.value).ToList())
                         .ToList();
        }
    }
}