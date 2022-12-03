using NUnit.Framework;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using RaceLogic;
using Pilot = RaceLogic.Pilot;
using ExcelController;
namespace RegulationTests
{
    public class SprintTests
    {
        dynamic correctSheet = ExcelWorker.excel.Sheets["sprintCorrect"];
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
            Sprint.DoThreeRaces(numbers);
            
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
            Sprint.ReadScor(numbers);
            Sprint.Sort();
            Sprint.DoNextRace(numbers, 3);

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
            Sprint.ReadScor(numbers);
            Sprint.SortTwoLiques(numbers);
            Sprint.DoNextRace(numbers, 4);

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
            Sprint.DoFinalAmators(numbers, 4);

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
            Sprint.ReadScor(numbers);
            Sprint.SortTwoLiques(numbers);


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