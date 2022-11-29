using NUnit.Framework;
using Hekki;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace RegulationTests
{
    public class EveryOnEveryTests
    {
        dynamic correctSheet = ExcelWorker.excel.Sheets["everyCorrect"];
        private List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8 };
        private List<Pilot> correctPilots;

        [OneTimeSetUp]
        public void Setup()
        {
            SetCorrectPilots();
            WriteTestData();
            Race.RedefineRandomWithSeed();
            Combination.RedefineRandomWithSeed();
        }

        private void WriteTestData()
        {
            ExcelWorker.CleanData(null, 11);
            ExcelWorker.CleanData(ExcelWorker.GetTotalBoardRange(45));
            ExcelWorker.WriteTestData(@"../../../TestData/EveryOnEvery/TestNames.txt", "Имя");
            ExcelWorker.WriteTestData(@"../../../TestData/EveryOnEvery/TestScore1.txt", "Очки время");
            ExcelWorker.WriteTestData(@"../../../TestData/EveryOnEvery/TestScore2.txt", "Очки место");
        }

        private void SetCorrectPilots()
        {
            var count = File.ReadAllLines(@"../../../TestData/EveryOnEvery/TestNames.txt").Length - 1;
            correctSheet.Visible = true;
            ExcelWorker.excel.ActiveWorkbook.Sheets["everyCorrect"].Select();
            correctPilots = Race.MakePilotsFromTotalBoard(count).OrderBy(o => o.Name).ToList();
            ExcelWorker.excel.ActiveWorkbook.Sheets["every"].Select();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            correctSheet.Visible = false;
        }

        public void AssignmentTwoRaces(int row)
        {
            int col = ExcelWorker.excel.Range["P1", "P1"].Column;

            for (int i = 1; i < col; i++)
            {
                for (int j = row; j < 11; j++)
                {
                    var sut = Convert.ToString(ExcelWorker.excel.Cells[j, i].Value);
                    var correct = Convert.ToString(correctSheet.Cells[j, i].Value);
                    Assert.AreEqual(correct, sut);
                }
            }
        }

        [Test, Order(1)]
        public void AssignmentRaces()
        {
            Every.DoRaces(numbers);
            int row = 2;
            for (int i = 1; i < 6; i++)
            {
                AssignmentTwoRaces(row);
                row += 12;
            }
        }

        [Test, Order(2)]
        public void IdenticalTBWithTestData()
        {
            Every.ReadScor(numbers);
            Every.SortScores();

            int col = ExcelWorker.excel.Range["T1", "T1"].Column;

            for (int i = col; i < 12; i++)
            {
                for (int j = 92; j < j + 45; j++)
                {
                    var sut = Convert.ToString(ExcelWorker.excel.Cells[j, i].Value);
                    var correct = Convert.ToString(correctSheet.Cells[j, i].Value);
                    Assert.AreEqual(correct, sut);
                }
            }
        }
    }
}
