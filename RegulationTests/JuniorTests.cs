using NUnit.Framework;
using RaceLogic;
using ExcelController;
using RaceLogic.Regulations;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace RegulationTests
{
    public class JuniorTests
    {
        dynamic correctSheet = ExcelWorker.excel.Sheets["juniorCorrect"];
        private Junior _junior = new();
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
            ExcelWorker.CleanData();
            ExcelWorker.WriteTestData(@"../../../TestData/TestNames.txt", "Имя");
            ExcelWorker.WriteTestData(@"../../../TestData/Junior/TestScore.txt", "Очки за место");
        }

        private void SetCorrectPilots()
        {
            var count = File.ReadAllLines(@"../../../TestData/TestNames.txt").Length - 1;
            correctSheet.Visible = true;
            ExcelWorker.excel.ActiveWorkbook.Sheets["juniorCorrect"].Select();
            correctPilots = Race.MakePilotsFromTotalBoard(count).OrderBy(o => o.Name).ToList();
            ExcelWorker.excel.ActiveWorkbook.Sheets["junior"].Select();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            correctSheet.Visible = false;
        }

        public void PilotsTime()
        {
            _junior.ReadTime();
            var pilots = Race.MakePilotsFromTotalBoard(correctPilots.Count).OrderBy(o => o.Name).ToList();

            for (int i = 0; i < pilots.Count; i++)
            {
                for (int j = 0; j < pilots[i].TimesCount; j++)
                {
                    Assert.AreEqual(correctPilots[i].GetTimeByIndex(j), pilots[i].GetTimeByIndex(j));
                }
            }
        }

        [Test, Order(1)]
        public void AssignmentQual()
        {
            _junior.DoQualRandom(numbers);
            _junior.WriteUsedKarts();
            ExcelWorker.WriteTestData(@"../../../TestData/Junior/TestTime.txt", "Время", ExcelWorker.excel.get_Range("T1", "T10"));
            PilotsTime();
            _junior.ReadScor();
            _junior.SortTimeInTB();
            _junior.SortTimeInRace();

            int col = ExcelWorker.excel.Range["N1", "N1"].Column;

            for (int i = col; i < 5 + col; i++)
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
        public void AssignmentHeat1()
        {
            _junior.DoRace(numbers);
            _junior.WriteUsedKarts();
            ExcelWorker.WriteTestData(@"../../../TestData/Junior/TestTime.txt", "Время", ExcelWorker.excel.get_Range("AC1", "AC10"));
            PilotsTime();
            _junior.ReadScor();
            _junior.SortTimeInTB();
            _junior.SortTimeInRace();

            int col = ExcelWorker.excel.Range["W1", "W1"].Column;

            for (int i = col; i < 5 + col; i++)
            {
                for (int j = 4; j < 40 + 4; j++)
                {
                    var sut = Convert.ToString(ExcelWorker.excel.Cells[j, i].Value);
                    var correct = Convert.ToString(correctSheet.Cells[j, i].Value);
                    Assert.AreEqual(correct, sut);
                }
            }
        }

        [Test, Order(3)]
        public void AssignmentHeat2()
        {
            _junior.DoRace(numbers);
            _junior.WriteUsedKarts();
            ExcelWorker.WriteTestData(@"../../../TestData/Junior/TestTime.txt", "Время", ExcelWorker.excel.get_Range("AL1", "AL10"));
            PilotsTime();
            _junior.ReadScor();
            _junior.SortTimeInTB();
            _junior.SortTimeInRace();

            int col = ExcelWorker.excel.Range["AF1", "AF1"].Column;

            for (int i = col; i < 5 + col; i++)
            {
                for (int j = 4; j < 40 + 4; j++)
                {
                    var sut = Convert.ToString(ExcelWorker.excel.Cells[j, i].Value);
                    var correct = Convert.ToString(correctSheet.Cells[j, i].Value);
                    Assert.AreEqual(correct, sut);
                }
            }
        }

        [Test, Order(4)]
        public void AssignmentFinal()
        {
            _junior.SortScores();
            _junior.DoFinal(numbers);
            _junior.WriteUsedKarts();
            _junior.ReadScor();

            int col = ExcelWorker.excel.Range["AO1", "AO1"].Column;

            for (int i = col; i < 7 + col; i++)
            {
                for (int j = 4; j < 40 + 4; j++)
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
            _junior.SortScores();

            for (int i = 1; i < 47; i++)
            {
                for (int j = 4; j < 8 + 4; j++)
                {
                    var sut = Convert.ToString(ExcelWorker.excel.Cells[j, i].Value);
                    var correct = Convert.ToString(correctSheet.Cells[j, i].Value);
                    Assert.AreEqual(correct, sut);
                }
            }
        }
    }
}
