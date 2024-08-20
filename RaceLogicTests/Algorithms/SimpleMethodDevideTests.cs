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
    internal class SimpleMethodDevideTests
    {
        private IDevideMethod _devideMethod;

        [SetUp]
        public void Setup()
        {
            _devideMethod = new SimpleMethodDevide(3, 8);
        }

        [Test]
        public void Devide_ShouldDivideListIntoEqualParts()
        {
            // Arrange
            var inputList = new List<int> { 1, 2, 3, 4, 5, 6 };
            int parts = 2;
            var expected = new List<List<int>>
            {
                new() { 1, 2, 3 },
                new() { 4, 5, 6 }
            };
            // Act
            var result = _devideMethod.Devide(inputList, parts);

            // Assert
            Assert.That(result, Has.Count.EqualTo(parts));
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void Devide_ShouldDivideListWithUnequalParts()
        {
            // Arrange
            var inputList = new List<int> { 1, 2, 3, 4, 5 };
            int parts = 2;
            var expected = new List<List<int>>
            {
                new() { 1, 2, 3 },
                new() { 4, 5 },
            };
            // Act
            var result = _devideMethod.Devide(inputList, parts);

            // Assert
            Assert.That(result, Has.Count.EqualTo(parts));
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void Devide_ShouldThrowException_WhenPartsIsZero()
        {
            // Arrange
            var inputList = new List<int> { 1, 2, 3, 4, 5, 6 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _devideMethod.Devide(inputList, 0));
        }

        [Test]
        public void Devide_ShouldThrowException_WhenInputListIsEmpty()
        {
            // Arrange
            var inputList = new List<int>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _devideMethod.Devide(inputList, 3));
        }
    }
}
