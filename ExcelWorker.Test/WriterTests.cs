using RaceLogic;
namespace ExcelWorker.Test
{
    using Hekki;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class WriterTests
    {
        private List<string> namesOriginal;
        private List<string> testNames;
        private List<Pilot> pilots = new();
        private List<List<Pilot>> groups = new();
        private List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8 };

        [OneTimeSetUp]
        public void Setup()
        {
            namesOriginal = ExcelController.ExcelWorker.ReadNamesInTotalBoard();
            testNames = ExcelController.ExcelWorker.ReadTestNamesFromTxt();
            ExcelController.ExcelWorker.WriteNamesInTotalBoard(testNames);
            pilots = Race.MakePilotsFromTotalBoard(testNames.Count);
            Race.RedefineRandomWithSeed();
            ExcelController.ExcelWorker.CleanData();

        }

        [OneTimeTearDown]
        public void Cleanup()
        {
           // ExcelWorker.WriteNamesInTotalBoard(namesOriginal);
        }

        [Test]
        public void WriteNamesRace()
        {
            
        }

        //[Test]
        //public void ReadNamesInTotalBoardTest()
        //{

        //}

        //[Test]
        //public void ReadNamesInTotalBoardTest()
        //{

        //}

        //[Test]
        //public void ReadNamesInTotalBoardTest()
        //{

        //}

        //[Test]
        //public void ReadNamesInTotalBoardTest()
        //{

        //}

        //[Test]
        //public void ReadNamesInTotalBoardTest()
        //{

        //}

        //[Test]
        //public void ReadNamesInTotalBoardTest()
        //{

        //}
    }
}