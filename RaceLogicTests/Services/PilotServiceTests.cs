using Moq;
using RaceLogic.Interfaces;
using RaceLogic.Services;

namespace RaceLogicTests.Services
{
    [TestFixture]
    internal class PilotServiceTests
    {
        private IPilotService _pilotService;

        [SetUp]
        public void Setup()
        {
            _pilotService = new PilotService();
        }

        [Test]
        public void AddKarts_SingleList_ShouldAddKartsToPilots()
        {
            // Arrange
            var pilots = new List<IPilot>
            {
                new Mock<IPilot>().Object,
                new Mock<IPilot>().Object
            };
            var karts = new List<int> { 1, 2 };

            // Act
            _pilotService.AddKarts(pilots, karts);

            // Assert
            for (int i = 0; i < pilots.Count; i++)
            {
                Mock.Get(pilots[i]).Verify(p => p.AddNumberKart(karts[i]), Times.Once);
            }
        }

        [Test]
        public void AddKarts_SingleList_ShouldThrowExceptionWhenCountsDoNotMatch()
        {
            // Arrange
            var pilots = new List<IPilot>
            {
                new Mock<IPilot>().Object
            };
            var karts = new List<int> { 1, 2 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _pilotService.AddKarts(pilots, karts));
        }

        [Test]
        public void AddKarts_NestedList_ShouldAddKartsToPilots()
        {
            // Arrange
            var pilots = new List<List<IPilot>>
            {
                new() { new Mock<IPilot>().Object },
                new() { new Mock<IPilot>().Object }
            };
            var karts = new List<List<int>>
            {
                new() { 1 },
                new() { 2 }
            };

            // Act
            _pilotService.AddKarts(pilots, karts);

            // Assert
            for (int i = 0; i < pilots.Count; i++)
            {
                for (int j = 0; j < pilots[i].Count; j++)
                {
                    Mock.Get(pilots[i][j]).Verify(p => p.AddNumberKart(karts[i][j]), Times.Once);
                }
            }
        }

        [Test]
        public void AddKarts_NestedList_ShouldThrowExceptionWhenCountsDoNotMatch()
        {
            // Arrange
            var pilots = new List<List<IPilot>>
            {
                new() { new Mock<IPilot>().Object }
            };
            var karts = new List<List<int>>
            {
                new() { 1 },
                new() { 2 }
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _pilotService.AddKarts(pilots, karts));
        }

        [Test]
        public void AddScores_ShouldAddScoresToPilots()
        {
            // Arrange
            var pilots = new List<IPilot>
            {
                new Mock<IPilot>().Object,
                new Mock<IPilot>().Object
            };
            var scores = new List<int> { 10, 20 };

            // Act
            _pilotService.AddScores(pilots, scores);

            // Assert
            for (int i = 0; i < pilots.Count; i++)
            {
                Mock.Get(pilots[i]).Verify(p => p.AddScore(scores[i]), Times.Once);
            }
        }

        [Test]
        public void AddScores_ShouldThrowExceptionWhenCountsDoNotMatch()
        {
            // Arrange
            var pilots = new List<IPilot>
            {
                new Mock<IPilot>().Object
            };
            var scores = new List<int> { 10, 20 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _pilotService.AddScores(pilots, scores));
        }

        [Test]
        public void AddTimes_ShouldAddTimesToPilots()
        {
            // Arrange
            var pilots = new List<IPilot>
            {
                new Mock<IPilot>().Object,
                new Mock<IPilot>().Object
            };
            var times = new List<int> { 100, 200 };

            // Act
            _pilotService.AddTimes(pilots, times);

            // Assert
            for (int i = 0; i < pilots.Count; i++)
            {
                Mock.Get(pilots[i]).Verify(p => p.AddTime(times[i]), Times.Once);
            }
        }

        [Test]
        public void AddTimes_ShouldThrowExceptionWhenCountsDoNotMatch()
        {
            // Arrange
            var pilots = new List<IPilot>
            {
                new Mock<IPilot>().Object
            };
            var times = new List<int> { 100, 200 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _pilotService.AddTimes(pilots, times));
        }

        [Test]
        public void GetNames_ReturnsNames()
        {
            // Arrange
            var p1 = new Mock<IPilot>();
            var p2 = new Mock<IPilot>();
            p1.Setup(x => x.Name).Returns("Name1");
            p2.Setup(x => x.Name).Returns("Name2");
            var pilots = new List<List<IPilot>>
            {
                new() { p1.Object },
                new() { p2.Object }
            };
            var expected = new List<List<string>> { new() { "Name1" }, new() { "Name2" } };
            
            // Act
            var result = _pilotService.GetNames(pilots);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
