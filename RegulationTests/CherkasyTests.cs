﻿using NUnit.Framework;
using RaceLogic;
using ExcelController;
using RaceLogic.Regulations;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace RegulationTests
{
    public class CherkasyTests
    {
        dynamic correctSheet = ExcelWorker.excel.Sheets["cherkasyCorrect"];
        private Cherkasy _cherkasy = new();
        private List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8 };
        private List<Pilot> correctPilots;

        [OneTimeSetUp]
        public void Setup()
        {   
            SetCorrectPilots();
            WriteTestData();
        }

        private void WriteTestData()
        {
            ExcelWorker.CleanData();
            ExcelWorker.WriteTestData(@"../../../TestData/TestNames.txt", "Имя");
            ExcelWorker.WriteTestData(@"../../../TestData/Cherkasy/TestTime.txt", "Время", ExcelWorker.excel.get_Range("L1", "P100"));
            ExcelWorker.WriteTestData(@"../../../TestData/Cherkasy/TestScore.txt", "Очки за место");
        }

        private void SetCorrectPilots()
        {
            var count = File.ReadAllLines(@"../../../TestData/TestNames.txt").Length - 1;
            correctSheet.Visible = true;
            ExcelWorker.excel.ActiveWorkbook.Sheets["cherkasyCorrect"].Select();
            correctPilots = Race.MakePilotsFromTotalBoard(count).OrderBy(o => o.Name).ToList();
            ExcelWorker.excel.ActiveWorkbook.Sheets["cherkasy"].Select();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            correctSheet.Visible = false;
        }

        public void PilotsTime()
        {
            var times = _cherkasy.GetTimes();
            _cherkasy.WriteTimes(times);
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
        public void AssignmentQual1()
        {
            Race.RedefineRandomWithSeed();
            Combination.RedefineRandomWithSeed();
            _cherkasy.DoQualRace(numbers);
            _cherkasy.WriteUsedKarts();
            PilotsTime();
            _cherkasy.SortTimeInTB();
            _cherkasy.SortTimeInRace();

            int col = ExcelWorker.excel.Range["L1", "L1"].Column;

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
            _cherkasy.DoOneRace(numbers);
            _cherkasy.WriteUsedKarts();
            var scores = _cherkasy.GetScores();
            _cherkasy.WriteScores(scores);


            int col = ExcelWorker.excel.Range["R1", "R1"].Column;

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

        [Test, Order(3)]
        public void AssignmentQual2()
        {
            ExcelWorker.WriteTestData(@"../../../TestData/Cherkasy/TestTime.txt", "Время", ExcelWorker.excel.get_Range("Z1", "AD100"));
            Race.RedefineRandomWithSeed();
            Combination.RedefineRandomWithSeed();
            _cherkasy.DoQualRace(numbers);
            _cherkasy.WriteUsedKarts();
            PilotsTime();
            _cherkasy.SortTimeInTB();
            _cherkasy.SortTimeInRace();


            int col = ExcelWorker.excel.Range["Z1", "Z1"].Column;

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
        public void AssignmentHeat2()
        {
            _cherkasy.DoOneRace(numbers);
            _cherkasy.WriteUsedKarts();
            var scores = _cherkasy.GetScores();
            _cherkasy.WriteScores(scores);

            int col = ExcelWorker.excel.Range["AF1", "AF1"].Column;

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
        public void AssignmentFinal()
        {
            _cherkasy.SortScores();
            _cherkasy.DoFinal(numbers);
            _cherkasy.WriteUsedKarts();
            var scores = _cherkasy.GetScores();
            _cherkasy.WriteScores(scores);

            int col = ExcelWorker.excel.Range["AN1", "AN1"].Column;

            for (int i = col; i < 46 + col; i++)
            {
                for (int j = 4; j < 8 + 4; j++)
                {
                    var sut = Convert.ToString(ExcelWorker.excel.Cells[j, i].Value);
                    var correct = Convert.ToString(correctSheet.Cells[j, i].Value);
                    Assert.AreEqual(correct, sut);
                }
            }
        }

        [Test, Order(6)]
        public void IdenticalWithTestData()
        {
            _cherkasy.SortScores();

            for (int i = 1; i < 46; i++)
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
