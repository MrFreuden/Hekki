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
            namesOriginal = ExcelWorker.ReadNamesInTotalBoard();
            testNames = ExcelWorker.ReadTestNamesFromTxt();
            ExcelWorker.WriteNamesInTotalBoard(testNames);
            pilots = Race.MakePilotsFromTotalBoard(testNames.Count);
            Race.RedefineRandomWithSeed();
            ExcelWorker.CleanData();

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