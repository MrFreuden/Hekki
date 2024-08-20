using RaceLogic.Algorithms;
using RaceLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogicTests.Algorithms
{
    [TestFixture]
    internal class CardMethodDevideTests
    {
        private IDevideMethod _devideMethod;

        [SetUp]
        public void Setup()
        {
            _devideMethod = new CardMethodDevide();
        }

        [Test]
        public void CardMethod_ShouldDivideListIntoEqualParts()
        {
            // Arrange
            var inputList = new List<int> { 1, 2, 3, 4, 5, 6 };
            int parts = 3;
            var expected = new List<List<int>>
            {
                new() { 1, 4 },
                new() { 2, 5 },
                new() { 3, 6 }
            };

            // Act
            var result = _devideMethod.Devide(inputList, parts);

            // Assert
            Assert.That(result, Has.Count.EqualTo(parts));
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void CardMethod_ShouldDivideListWithUnequalParts()
        {
            // Arrange
            var inputList = new List<int> { 1, 2, 3, 4, 5 };
            int parts = 3;
            var expected = new List<List<int>>
            {
                new() { 1, 4 },
                new() { 2, 5 },
                new() { 3 }
            };

            // Act
            var result = _devideMethod.Devide(inputList, parts);

            // Assert
            Assert.That(result, Has.Count.EqualTo(parts));
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void CardMethod_ShouldThrowException_WhenPartsIsZero()
        {
            // Arrange
            var inputList = new List<int> { 1, 2, 3, 4, 5, 6 };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _devideMethod.Devide(inputList, 0));
            Assert.That(ex.Message, Is.EqualTo("Parts must be greater than zero."));
        }

        [Test]
        public void CardMethod_ShouldThrowException_WhenInputListIsEmpty()
        {
            // Arrange
            var inputList = new List<int>();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _devideMethod.Devide(inputList, 3));
            Assert.That(ex.Message, Is.EqualTo("Input list cannot be empty."));
        }
    }
}
