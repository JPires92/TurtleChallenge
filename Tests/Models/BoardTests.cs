using Xunit;
using TurtleChallenge.Models;

namespace TurtleChallenge.Tests.Models{
    public class BoardTests
    {
        [Fact]
        public void Board_ShouldInitializeCorrectly_WhenParametersAreValid()
        {
            // Arrange
            int width = 5;
            int height = 5;
            var exitPoint = new Position { X = 3, Y = 3 };
            var mines = new List<Position> 
            { 
                new Position { X = 1, Y = 1 }, 
                new Position { X = 2, Y = 2 } 
            };

            // Act
            var board = new Board(width, height, exitPoint, mines);

            // Assert
            Assert.Equal(width, board.Width);
            Assert.Equal(height, board.Height);
            Assert.Equal(exitPoint, board.ExitPoint);
            Assert.Equal(mines, board.Mines);
        }

        [Fact]
        public void Board_ShouldThrowException_WhenWidthIsZero()
        {
            // Arrange
            int width = 0;
            int height = 5;
            var exitPoint = new Position { X = 3, Y = 3 };
            var mines = new List<Position> 
            { 
                new Position { X = 1, Y = 1 }, 
                new Position { X = 2, Y = 2 } 
            };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => new Board(width, height, exitPoint, mines));
            Assert.Equal("Board width must be greater then 0.", exception.Message);
        }

        [Fact]
        public void Board_ShouldThrowException_WhenHeightIsZero()
        {
            // Arrange
            int width = 5;
            int height = 0;
            var exitPoint = new Position { X = 3, Y = 3 };
            var mines = new List<Position> 
            { 
                new Position { X = 1, Y = 1 }, 
                new Position { X = 2, Y = 2 } 
            };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => new Board(width, height, exitPoint, mines));
            Assert.Equal("Board height must be greater then 0.", exception.Message);
        }

        [Fact]
        public void Board_ShouldThrowException_WhenMineIsOutOfBoardBounds()
        {
            // Arrange
            int width = 5;
            int height = 5;
            var exitPoint = new Position { X = 3, Y = 3 };
            var mines = new List<Position> 
            { 
                new Position { X = 6, Y = 1 } // Invalid mine position
            };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => new Board(width, height, exitPoint, mines));
            Assert.Equal("Mine(6,1) value out of the board.", exception.Message);
        }

        [Fact]
        public void Board_ShouldAddMines_WhenValidPositions()
        {
            // Arrange
            int width = 5;
            int height = 5;
            var exitPoint = new Position { X = 3, Y = 3 };
            var mines = new List<Position> 
            { 
                new Position { X = 1, Y = 1 }, 
                new Position { X = 2, Y = 2 } 
            };

            // Act
            var board = new Board(width, height, exitPoint, mines);

            // Assert
            Assert.Contains(mines[0], board.Mines);
            Assert.Contains(mines[1], board.Mines);
        }
    }
}