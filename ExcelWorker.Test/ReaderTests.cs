namespace ExcelWorker.Test
{
    using Hekki;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ReaderTests
    {
        private List<string> namesOriginal;
        private List<string> testNames;
        private List<Pilot> pilots = new();

        [OneTimeSetUp]
        public void Setup()
        {
            namesOriginal = ExcelWorker.ReadNamesInTotalBoard();
            testNames = ExcelWorker.ReadTestNamesFromTxt();
            ExcelWorker.WriteNamesInTotalBoard(testNames);
            for (int i = 0; i < testNames.Count; i++)
            {
                pilots.Add(new Pilot(testNames[i]));
            }
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            // ExcelWorker.WriteNamesInTotalBoard(namesOriginal);
        }

        [Test]
        public void CorrectReadNamesFromTxt()
        {
            var sut = ExcelWorker.ReadTestNamesFromTxt();
            var names = new string[]
            {
                "MARTOLOG",
                "OLIFIRENKO",
                "ILLYAS",
                "KARLENKO",
                "KOPTYEV",
                "MARTYNENKO",
                "LAGODZYA",
                "BARANIUK",
                "BRAZHNIKOV",
                "VOLOSHYN",
                "KOVALCHUK",
                "YATSENKO",
                "SEMENEC",
                "RUDENKO",
                "FEDORCHUK M.",
                "KORDIK",
                "PORTYANKO",
                "DODONOV",
                "SHARAPOV",
                "MANAIENKO"
            };

            for (int i = 0; i < names.Length; i++)
            {
                Assert.AreEqual(names[i], sut[i]);
            }
        }

        [Test]
        public void ReadNamesInTotalBoardTest()
        {
            var sut = ExcelWorker.ReadNamesInTotalBoard();

            for (int i = 0; i < sut.Count; i++)
            {
                Assert.AreEqual(sut[i], testNames[i]);
            }
        }

        [Test]
        public void ReadLiquesTest()
        {
            var sut = ExcelWorker.ReadLique(testNames.Count);
            var liques = new string[]
            {
                "Pro",
                "Pro",
                "Pro",
                "Pro",
                "Pro",
                "Pro",
                "Am",
                "Am",
                "Am",
                "Am",
                "Am",
                "Am",
                "Am",
                "Am",
                "Am",
                "Am",
                "Am",
                "Am",
                "Am",
                "Am"
            };

            for (int i = 0; i < liques.Length; i++)
            {
                Assert.AreEqual(liques[i], sut[i]);
            }
        }

        [Test]
        public void ReadUsedKartsInTB()
        {
            var sut = ExcelWorker.ReadUsedKartsInTotalBoard();
            List<List<int>> numbers = new()
            {
                new List<int>() { 4, 3, 6 },
                new List<int>() { 4, 5, 3 },
                new List<int>() { 8, 6, 3 },
                new List<int>() { 7, 2, 1 },
                new List<int>() { 7, 5, 3 },
                new List<int>() { 5, 1, 4 },
                new List<int>() { 5, 1, 2 },
                new List<int>() { 6, 4, 8 },
                new List<int>() { 8, 7, 4 },
                new List<int>() { 6, 3, 2 },
                new List<int>() { 4, 8, 5 },
                new List<int>() { 8, 5, 7 },
                new List<int>() { 3, 2, 8 },
                new List<int>() { 2, 3, 8 },
                new List<int>() { 1, 7, 5 },
                new List<int>() { 7, 8, 6 },
                new List<int>() { 1, 4, 6 },
                new List<int>() { 5, 1, 4 },
                new List<int>() { 3, 8, 1 },
                new List<int>() { 1, 4, 5 }
            };
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < numbers[i].Count; j++)
                {
                    Assert.AreEqual(numbers[i][j], sut[i][j]);
                }
            }
        }
                
        [Test]
        public void ReadTimesRace()
        {
            var sut = ExcelWorker.ReadTimeInRace(pilots);
            List<List<string>> times = new()
            {
                new List<string>() { "34.997", "34.996", "34.981" },
                new List<string>() { "34.999", "34.991", "34.984" },
                new List<string>() { "34.931", "34.980", "34.996" },
                new List<string>() { "34.998", "34.993", "34.932" },
                new List<string>() { "34.984", "34.999", "34.998" },
                new List<string>() { "34.982", "34.932", "34.978" },
                new List<string>() { "34.991", "34.998", "34.983" },
                new List<string>() { "34.991", "28.017", "34.982" },
                new List<string>() { "34.932", "34.978", "28.017" },
                new List<string>() { "34.996", "34.991", "34.991" },
                new List<string>() { "34.983", "34.999", "34.980" },
                new List<string>() { "34.993", "34.992", "34.931" },
                new List<string>() { "34.992", "34.997", "34.997" },
                new List<string>() { "28.017", "34.984", "34.989" },
                new List<string>() { "34.980", "34.981", "28.796" },
                new List<string>() { "28.796", "34.982", "34.991" },
                new List<string>() { "34.981", "34.983", "34.992" },
                new List<string>() { "34.999", "28.796", "34.999" },
                new List<string>() { "34.989", "34.931", "34.993" },
                new List<string>() { "34.978", "34.989", "34.999" }
            };

            for (int i = 0; i < times.Count; i++)
            {
                for (int j = 0; j < times[i].Count; j++)
                {
                    Assert.AreEqual(times[i][j].ToString(), sut[i].GetTimeByIndex(j));
                }
            }
           
        }

        [Test]
        public void ReadTimesTB()
        {
            var sut = ExcelWorker.ReadTimesInTotalBoard(testNames.Count);
            List<List<string>> times = new()
            {
                new List<string>() { "34,997", "34,996", "34,981" },
                new List<string>() { "34,999", "34,991", "34,984" },
                new List<string>() { "34,931", "34,98", "34,996" },
                new List<string>() { "34,998", "34,993", "34,932" },
                new List<string>() { "34,984", "34,999", "34,998" },
                new List<string>() { "34,982", "34,932", "34,978" },
                new List<string>() { "34,991", "34,998", "34,983" },
                new List<string>() { "34,991", "28,017", "34,982" },
                new List<string>() { "34,932", "34,978", "28,017" },
                new List<string>() { "34,996", "34,991", "34,991" },
                new List<string>() { "34,983", "34,999", "34,98" },
                new List<string>() { "34,993", "34,992", "34,931" },
                new List<string>() { "34,992", "34,997", "34,997" },
                new List<string>() { "28,017", "34,984", "34,989" },
                new List<string>() { "34,98", "34,981", "28,796" },
                new List<string>() { "28,796", "34,982", "34,991" },
                new List<string>() { "34,981", "34,983", "34,992" },
                new List<string>() { "34,999", "28,796", "34,999" },
                new List<string>() { "34,989", "34,931", "34,993" },
                new List<string>() { "34,978", "34,989", "34,999" }
            };

            for (int i = 0; i < times.Count; i++)
            {
                for (int j = 0; j < times[i].Count; j++)
                {
                    Assert.AreEqual(times[i][j].ToString(), sut[i][j]);
                }
            }
        }

        [Test]
        public void ReadScoreRace()
        {
            var sut = ExcelWorker.ReadScoresInRace(pilots);
            List<List<int>> scores = new() 
            {
                new List<int>() {6,10,6 },
                new List<int>() {3,5,3 },
                new List<int>() {11,4,4 },
                new List<int>() {5,9,5 },
                new List<int>() {8,5,3 },
                new List<int>() {7,4,2 },
                new List<int>() {4,8,5 },
                new List<int>() {3,3,8 },
                new List<int>() {5,3,10 },
                new List<int>() {2,10,5 },
                new List<int>() {8,6,7 },
                new List<int>() {5,7,9 },
                new List<int>() {7,8,4 },
                new List<int>() {8,8,4 },
                new List<int>() {7,11,6 },
                new List<int>() {4,2,6 },
                new List<int>() {11,6,7 },
                new List<int>() {7,4,11 },
                new List<int>() {6,6,11 },
                new List<int>() {10,3,7 }
            };

            for (int i = 0; i < scores.Count; i++)
            {
                for (int j = 0; j < scores[i].Count; j++)
                {
                    Assert.AreEqual(scores[i][j].ToString(), sut[i].GetScoreByNumberRace(j).ToString());
                }
            }

        }

        [Test]
        public void ReadScoreTB()
        {
            var sut = ExcelWorker.ReadScoresInTotalBoard(testNames.Count);
            List<List<int>> scores = new()
            {
                new List<int>() { 6, 10, 6 },
                new List<int>() { 3, 5, 3 },
                new List<int>() { 11, 4, 4 },
                new List<int>() { 5, 9, 5 },
                new List<int>() { 8, 5, 3 },
                new List<int>() { 7, 4, 2 },
                new List<int>() { 4, 8, 5 },
                new List<int>() { 3, 3, 8 },
                new List<int>() { 5, 3, 10 },
                new List<int>() { 2, 10, 5 },
                new List<int>() { 8, 6, 7 },
                new List<int>() { 5, 7, 9 },
                new List<int>() { 7, 8, 4 },
                new List<int>() { 8, 8, 4 },
                new List<int>() { 7, 11, 6 },
                new List<int>() { 4, 2, 6 },
                new List<int>() { 11, 6, 7 },
                new List<int>() { 7, 4, 11 },
                new List<int>() { 6, 6, 11 },
                new List<int>() { 10, 3, 7 }
            };

            for (int i = 0; i < scores.Count; i++)
            {
                for (int j = 0; j < scores[i].Count; j++)
                {
                    Assert.AreEqual(scores[i][j].ToString(), sut[i][j].ToString());
                }
            }
        }
    }
}