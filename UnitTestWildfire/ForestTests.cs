using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Wildfire;
using Wildfire.Entities;

namespace UnitTestWildfire
{
    [TestClass]
    public class ForestTests
    {
        [TestMethod]
        public void CheckCellState_WithTree_ReturnsTree()
        {
            // Arrange
            Forest forest = new Forest(2, 2, new List<Coords>());
            State expected = State.Tree;

            // Act
            State state = forest.CheckCellState(new Coords { H = 0, L = 0 });

            // Assert
            Assert.AreEqual(expected, state, "State not good");
        }

        [TestMethod]
        public void CheckCellState_WithIncorrectCoords_ReturnsNull()
        {
            // Arrange
            Forest forest = new Forest(2, 2, new List<Coords>());
            State expected = State.NULL;

            // Act
            State state = forest.CheckCellState(new Coords { H = 4, L = 2 });

            // Assert
            Assert.AreEqual(expected, state, "State not good");
        }



        [TestMethod]
        public void FireCell_WithTreeCell_ReturnsFire()
        {
            // Arrange
            Forest forest = new Forest(2, 2, new List<Coords>());
            State expected = State.Fire;

            // Act
            forest.FireCell(new Coords { H = 0, L = 0 });
            State state = forest.CheckCellState(new Coords { H = 0, L = 0 });

            // Assert
            Assert.AreEqual(expected, state, "State not good");
        }


        [TestMethod]
        public void FireCell_WithAshCell_ReturnsAsh()
        {
            // Arrange
            Forest forest = new Forest(2, 2, new List<Coords>());
            forest.Cells[0, 0].CurrentState = State.Ash;
            State expected = State.Ash;

            // Act
            forest.FireCell(new Coords { H = 0, L = 0 });
            State state = forest.CheckCellState(new Coords { H = 0, L = 0 });

            // Assert
            Assert.AreEqual(expected, state, "State not good");
        }


        [TestMethod]
        public void AshCell_WithFireCell_ReturnsAsh()
        {
            // Arrange
            Forest forest = new Forest(2, 2, new List<Coords>());
            forest.Cells[0, 0].CurrentState = State.Fire;
            State expected = State.Ash;

            // Act
            forest.AshCell(new Coords { H = 0, L = 0 });
            State state = forest.CheckCellState(new Coords { H = 0, L = 0 });

            // Assert
            Assert.AreEqual(expected, state, "State not good");
        }


        [TestMethod]
        public void AshCell_WithTreeCell_ReturnsTree()
        {
            // Arrange
            Forest forest = new Forest(2, 2, new List<Coords>());
            State expected = State.Tree;

            // Act
            forest.AshCell(new Coords { H = 0, L = 0 });
            State state = forest.CheckCellState(new Coords { H = 0, L = 0 });

            // Assert
            Assert.AreEqual(expected, state, "State not good");
        }
    }
}
