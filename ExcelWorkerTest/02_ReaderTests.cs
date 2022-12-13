﻿using AutoFixture;
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
                countPilots, out int[] cols);

            // Assert
            int col = 23;
            for (int i = 0; i < 1; i++)
            {
                int row = 4;
                for (int j = 0; j < countPilots; row++)
                {
                    if (ExcelWorker.excel.Cells[row, col].Value.ToString() == "0")
                    {
                        continue;
                    }
                    Assert.AreEqual(ExcelWorker.excel.Cells[row, col].Value.ToString(), sut[i][j]);
                    j++;
                }
            }
        }

        [Test]
        public void ReadScoresInRaceEveryOnEvery_MethodIsInvoked_CorrectValue()
        {
            // Arrange
            ExcelWorker.excel.ActiveWorkbook.Sheets["every"].Select();
            int countInGroup = 8;

            // Act
            var sut = ExcelWorker.ReadScoresInRaceEveryOnEvery(
                countPilots,
                countInGroup,
                out int[] cols);
            for (int i = 0; i < cols.Length; i++)
                cols[i] += 4;

            // Assert
            int row = -1;
            for (int i = 0; i < countPilots; i++)
            {
                row += 5;
                for (int j = 0; j < countInGroup; row++)
                {
                    if (ExcelWorker.excel.Cells[row, cols[i]].Value.ToString() == "0")
                    {
                        continue;
                    }
                    Assert.AreEqual(ExcelWorker.excel.Cells[row, cols[i]].Value.ToString(), sut[i][j]);
                    j++;
                }
            }

            ExcelWorker.excel.ActiveWorkbook.Sheets["ExcelTests"].Select();
        }

        [Test]
        public void ReadTimeInRace_MethodIsInvoked_CorrectValue()
        {
            // Arrange

            // Act
            var sut = ExcelWorker.ReadTimesInRace(
                countPilots, out int[] cols);

            // Assert
            int col = 20;
            for (int i = 0; i < 1; i++)
            {
                int row = 4;
                for (int j = 0; j < countPilots; row++)
                {
                    if (Convert.ToString(ExcelWorker.excel.Cells[row, col].Value) == null)
                    {
                        continue;
                    }
                    Assert.AreEqual(ExcelWorker.excel.Cells[row, col].Value.ToString(), sut[i][j]);
                    j++;
                }
            }
        }
    }
}