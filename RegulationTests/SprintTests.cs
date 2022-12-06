using NUnit.Framework;
using Hekki;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace RegulationTests
{
    public class SprintTests
    {
        dynamic correctSheet = ExcelWorker.excel.Sheets["sprintCorrect"];
        private Sprint _sprint = new();
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

        [OneTimeTearDown]
        public void Cleanup()
        {
            correctSheet.Visible = false;
        }

        private void WriteTestData()
        {
            ExcelWorker.CleanData();
            ExcelWorker.WriteTestData(@"../../../TestData/TestNames.txt", "Имя");
            ExcelWorker.WriteTestData(@"../../../TestData/Sprint/TestLiques.txt", "Лига");
            ExcelWorker.WriteTestData(@"../../../TestData/Sprint/SprintTestScore.txt", "Очки за место");
        }

        private void SetCorrectPilots()
        {
            var count = File.ReadAllLines(@"../../../TestData/TestNames.txt").Length - 1;
            correctSheet.Visible = true;
            ExcelWorker.excel.ActiveWorkbook.Sheets["sprintCorrect"].Select();
            correctPilots = Race.MakePilotsFromTotalBoard(count).OrderBy(o => o.Name).ToList();
            ExcelWorker.excel.ActiveWorkbook.Sheets["sprint"].Select();
        }

        [Test, Order(1)]
        public void AssignmentThreeHeats()
        {
            _sprint.DoThreeRaces(numbers);
            _sprint.WriteUsedKarts();

            for (int i = 13; i < 23 + 13; i++)
            {
                for (int j = 4; j < 40 + 4; j++)
                {
                    var sut = Convert.ToString(ExcelWorker.excel.Cells[j, i].Value);
                    var correct = Convert.ToString(correctSheet.Cells[j, i].Value);
                    Assert.AreEqual(correct, sut);
                }
            }
        }

        [Test, Order(2)]
        public void AssignmentSemiFinal()
        {
            _sprint.ReadScor();
            _sprint.SortScores();
            _sprint.DoNextRace(numbers, 3);
            _sprint.WriteUsedKarts();

            for (int i = 37; i < 7 + 37; i++)
            {
                for (int j = 4; j < 16 + 4; j++)
                {
                    var sut = Convert.ToString(ExcelWorker.excel.Cells[j, i].Value);
                    var correct = Convert.ToString(correctSheet.Cells[j, i].Value);
                    Assert.AreEqual(correct, sut);
                }
            }
        }

        [Test, Order(3)]
        public void AssignmentFinalPro()
        {
            _sprint.ReadScor();
            _sprint.SortTwoLiques(numbers);
            _sprint.DoNextRace(numbers, 4);
            _sprint.WriteUsedKarts();

            for (int i = 39; i < 7 + 39; i++)
            {
                for (int j = 4; j < 8 + 4; j++)
                {
                    var sut = Convert.ToString(ExcelWorker.excel.Cells[j, i].Value);
                    var correct = Convert.ToString(correctSheet.Cells[j, i].Value);
                    Assert.AreEqual(correct, sut);
                }
            }
        }

        [Test, Order(4)]
        public void AssignmentFinalAmators()
        {
            _sprint.DoFinalAmators(numbers, 4);
            _sprint.WriteUsedKartsAmators();

            for (int i = 47; i < 7 + 47; i++)
            {
                for (int j = 4; j < 8 + 4; j++)
                {
                    var sut = Convert.ToString(ExcelWorker.excel.Cells[j, i].Value);
                    var correct = Convert.ToString(correctSheet.Cells[j, i].Value);
                    Assert.AreEqual(correct, sut);
                }
            }
        }

        [Test, Order(5)]
        public void IdenticalWithTestData()
        {
            _sprint.ReadScor();
            _sprint.SortTwoLiques(numbers);


            for (int i = 1; i < 7 + 47; i++)
            {
                for (int j = 4; j < 40 + 4; j++)
                {
                    var sut = Convert.ToString(ExcelWorker.excel.Cells[j, i].Value);
                    var correct = Convert.ToString(correctSheet.Cells[j, i].Value);
                    Assert.AreEqual(correct, sut);
                }
            }
        }
    }
}