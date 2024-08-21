using Moq;
using RaceLogic.Interfaces;
using RaceLogic.Services;

namespace RaceLogicTests.Services
{
    [TestFixture]
    internal class RegulationTests
    {
        private Mock<IDevideMethod> _mockDevideMethod;
        private Mock<ISortMethod> _mockSortMethod;
        private Mock<ICombination> _mockCombination;
        private IRegulation _regulation;

        [SetUp]
        public void Setup()
        {
            _mockDevideMethod = new Mock<IDevideMethod>();
            _mockSortMethod = new Mock<ISortMethod>();
            _mockCombination = new Mock<ICombination>();
            _regulation = new Regulation(_mockDevideMethod.Object, _mockSortMethod.Object, _mockCombination.Object);
        }

        [Test]
        public void GetCombos_ShouldReturnCorrectCombos()
        {
            // Arrange
            var pilots = new List<IPilot> { new Mock<IPilot>().Object, new Mock<IPilot>().Object };
            var groupsPilots = new List<List<IPilot>> { pilots };
            var numbersOfKarts = new List<int> { 1, 2, 3 };
            var usedKarts = new List<List<int>> { new() { 1, 2 }, new() { 1 } };
            var expectedCombo = new List<int> { 3, 2 };

            _mockCombination.Setup(m => m.GetCombo(It.IsAny<List<List<int>>>(), numbersOfKarts)).Returns(expectedCombo);

            // Act
            var result = _regulation.GetCombos(groupsPilots, numbersOfKarts);

            // Assert
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(expectedCombo));
        }

        [Test]
        public void GetCombos_ShouldCorrectUsedKarts()
        {
            // Arrange
            var p1 = new Mock<IPilot>();
            p1.Setup(x => x.GetNumbersKarts()).Returns(new List<int> { 1, 2 });
            var p2 = new Mock<IPilot>();
            p2.Setup(x => x.GetNumbersKarts()).Returns(new List<int> { 1 });
            var pilots = new List<IPilot> { p1.Object, p2.Object };
            var groupsPilots = new List<List<IPilot>> { pilots };
            var numbersOfKarts = new List<int> { 1, 2, 3 };
            var expectedUsedKarts = new List<List<int>> { new() { 1, 2 }, new() { 1 } };

            // Act
            _regulation.GetCombos(groupsPilots, numbersOfKarts);

            // Assert
            _mockCombination.Verify(x => x.GetCombo(It.Is<List<List<int>>>(y => AreEqual(y, expectedUsedKarts)), numbersOfKarts), Times.Once);
        }

        private bool AreEqual(List<List<int>> a, List<List<int>> b)
        {
            if (a.Count != b.Count) return false;
            for (int i = 0; i < a.Count; i++)
            {
                if (!a[i].SequenceEqual(b[i])) return false;
            }
            return true;
        }

        //[Test]
        //public void Devide_ShouldCallDevideMethod()
        //{
        //    // Arrange
        //    var pilots = new List<IPilot> { new Mock<IPilot>().Object, new Mock<IPilot>().Object };
        //    int groupAmount = 2;
        //    var expectedGroups = new List<List<IPilot>> { new List<IPilot> { pilots[0] }, new List<IPilot> { pilots[1] } };
        //    _mockDevideMethod.Setup(m => m.Devide(pilots, groupAmount)).Returns(expectedGroups.Cast<IList<IPilot>>().ToList());

        //    // Act
        //    var result = _regulation.Devide(pilots, groupAmount);

        //    // Assert
        //    Assert.That(result, Is.EqualTo(expectedGroups.Cast<IList<IPilot>>().ToList()));
        //    _mockDevideMethod.Verify(m => m.Devide(pilots, groupAmount), Times.Once);
        //}
    }
}
