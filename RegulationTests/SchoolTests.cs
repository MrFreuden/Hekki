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
    public class SchoolTests
    {
        dynamic correctSheet = ExcelWorker.excel.Sheets["schoolCorrect"];
        private School _school = new();
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
        }

        private void SetCorrectPilots()
        {
            var count = File.ReadAllLines(@"../../../TestData/TestNames.txt").Length - 1;
            correctSheet.Visible = true;
            ExcelWorker.excel.ActiveWorkbook.Sheets["schoolCorrect"].Select();
            correctPilots = Race.MakePilotsFromTotalBoard(count).OrderBy(o => o.Name).ToList();
            ExcelWorker.excel.ActiveWorkbook.Sheets["school"].Select();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            correctSheet.Visible = false;
        }

        public void PilotsTime()
        {
            _school.ReadTime();
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
            Race.RedefineRandomWithSeed();
            Combination.RedefineRandomWithSeed();
            _school.DoRace(numbers);
            _school.WriteUsedKarts();
            ExcelWorker.WriteTestData(@"../../../TestData/School/TestTime.txt", "Время", ExcelWorker.excel.get_Range("O1", "O10"));
            PilotsTime();
            _school.SortTimeInTB();
            _school.SortTimeInRace();

            int col = ExcelWorker.excel.Range["O1", "O1"].Column;

            for (int i = col; i < 3 + col; i++)
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
        public void AssignmentRace1()
        {
            Race.RedefineRandomWithSeed();
            Combination.RedefineRandomWithSeed();
            _school.DoRace(numbers);
            _school.WriteUsedKarts();
            ExcelWorker.WriteTestData(@"../../../TestData/School/TestTime.txt", "Время", ExcelWorker.excel.get_Range("U1", "U10"));
            PilotsTime();
            _school.SortTimeInTB();
            _school.SortTimeInRace();

            int col = ExcelWorker.excel.Range["U1", "U1"].Column;

            for (int i = col; i < 3 + col; i++)
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
        public void AssignmentRace2()
        {
            Race.RedefineRandomWithSeed();
            Combination.RedefineRandomWithSeed();
            _school.DoRace(numbers);
            _school.WriteUsedKarts();
            ExcelWorker.WriteTestData(@"../../../TestData/School/TestTime.txt", "Время", ExcelWorker.excel.get_Range("AA1", "AA10"));
            PilotsTime();
            _school.SortTimeInTB();
            _school.SortTimeInRace();

            int col = ExcelWorker.excel.Range["AA1", "AA1"].Column;

            for (int i = col; i < 3 + col; i++)
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
        public void IdenticalWithTestData()
        {
            for (int i = 1; i < 26; i++)
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
