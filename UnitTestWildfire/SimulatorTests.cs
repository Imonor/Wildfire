using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Wildfire;
using Wildfire.Entities;

namespace UnitTestWildfire
{
    [TestClass]
    public class SimulatorTests
    {
        [TestMethod]
        public void FireCoords_WithMaxProbaAndTree_ReturnsTrue()
        {
            // Arrange
            Forest forest = new Forest(2, 2, new List<Coords>());
            Simulator simu = new Simulator(forest, 1.0, new List<Coords>());
            bool expected = true;

            // Act
            bool actual = simu.FireCoords(new Coords { H = 0, L = 0 });

            // Assert
            Assert.AreEqual(expected, actual, "Should return true");
        }


        [TestMethod]
        public void FireCoords_WithMaxProbaAndFire_ReturnsFalse()
        {
            // Arrange
            Forest forest = new Forest(2, 2, new List<Coords>());
            forest.Cells[0, 0].CurrentState = State.Fire;
            Simulator simu = new Simulator(forest, 1.0, new List<Coords>());
            bool expected = false;

            // Act
            bool actual = simu.FireCoords(new Coords { H = 0, L = 0 });

            // Assert
            Assert.AreEqual(expected, actual, "Should return false");
        }


        [TestMethod]
        public void FireCoords_WithMaxProbaAndAsh_ReturnsFalse()
        {
            // Arrange
            Forest forest = new Forest(2, 2, new List<Coords>());
            forest.Cells[0, 0].CurrentState = State.Ash;
            Simulator simu = new Simulator(forest, 1.0, new List<Coords>());
            bool expected = false;

            // Act
            bool actual = simu.FireCoords(new Coords { H = 0, L = 0 });

            // Assert
            Assert.AreEqual(expected, actual, "Should return false");
        }


        [TestMethod]
        public void FireCoords_WithMinProbaAndTree_ReturnsFalse()
        {
            // Arrange
            Forest forest = new Forest(2, 2, new List<Coords>());
            Simulator simu = new Simulator(forest, 0.0, new List<Coords>());
            bool expected = false;

            // Act
            bool actual = simu.FireCoords(new Coords { H = 0, L = 0 });

            // Assert
            Assert.AreEqual(expected, actual, "Should return false");
        }

        [TestMethod]
        public void FireCoords_WithMinProbaAndFire_ReturnsFalse()
        {
            // Arrange
            Forest forest = new Forest(2, 2, new List<Coords>());
            forest.Cells[0, 0].CurrentState = State.Fire;
            Simulator simu = new Simulator(forest, 0.0, new List<Coords>());
            bool expected = false;

            // Act
            bool actual = simu.FireCoords(new Coords { H = 0, L = 0 });

            // Assert
            Assert.AreEqual(expected, actual, "Should return false");
        }

        [TestMethod]
        public void FireCoords_WithMinProbaAndAsh_ReturnsFalse()
        {
            // Arrange
            Forest forest = new Forest(2, 2, new List<Coords>());
            forest.Cells[0, 0].CurrentState = State.Ash;
            Simulator simu = new Simulator(forest, 0.0, new List<Coords>());
            bool expected = false;

            // Act
            bool actual = simu.FireCoords(new Coords { H = 0, L = 0 });

            // Assert
            Assert.AreEqual(expected, actual, "Should return false");
        }
    }
}
