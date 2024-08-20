using RaceLogic.Algorithms;

namespace RaceLogicTests.Algorithms
{
    [TestFixture]
    internal class CombinationTests
    {
        private Combination _combination; 

        [SetUp]
        public void Setup()
        {
            _combination = new Combination();
        }

        [Test]
        public void GetCombo_ShouldReturnValidCombination()
        {
            // Arrange
            var usedKarts = new List<List<int>>();
            var numberKarts = new List<int> { 1, 2, 3 };

            // Act
            var result = _combination.GetCombo(usedKarts, numberKarts);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(numberKarts.Count));
            Assert.That(result, Is.All.InRange(1, 3));
        }

        [Test]
        public void GetCombo_ShouldThrowException_WhenNoAvailableCombination()
        {
            // Arrange
            var usedKarts = new List<List<int>>
            {
                new() { 1, 2, 3 },
                new() { 1, 2, 3 },
                new() { 1, 2 }
            };
            var numberKarts = new List<int> { 1, 2, 3 };

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _combination.GetCombo(usedKarts, numberKarts));
            Assert.That(ex.Message, Is.EqualTo("No available combinations."));
        }

        [Test]
        public void GetCombo_ShouldExcludeUsedKarts()
        {
            // Arrange
            var usedKarts = new List<List<int>> { new() { 1, 2 } };
            var numberKarts = new List<int> { 1, 2, 3 };

            // Act
            var result = _combination.GetCombo(usedKarts, numberKarts);

            // Assert
            Assert.That(result.First(), Is.EqualTo(3));
        }

        [Test]
        public void RedefineRandomWithSeed_ShouldProduceDeterministicResults()
        {
            // Arrange
            _combination.RedefineRandomWithSeed();
            var usedKarts = new List<List<int>>();
            var numberKarts = new List<int> { 1, 2, 3 };

            // Act
            var result1 = _combination.GetCombo(usedKarts, numberKarts);
            var result2 = _combination.GetCombo(usedKarts, numberKarts);

            // Assert
            Assert.That(result1, Is.EqualTo(result2));
        }
    }
}
