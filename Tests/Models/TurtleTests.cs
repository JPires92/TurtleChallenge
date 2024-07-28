using TurtleChallenge.Models;
using TurtleChallenge.Enums;
using Xunit;

namespace TurtleChallenge.Tests.Models
{
    public class TurtleTests
    {
        [Fact]
        public void Turtle_ShouldInitializeCorrectly_WhenParametersAreValid()
        {
            // Arrange
            var boardDimensions = new Position { X = 5, Y = 5 };
            var startPosition = new Position { X = 2, Y = 2 };
            var startDirection = new Direction { CurrentDirection = DirectionEnum.North };

            // Act
            var turtle = new Turtle(boardDimensions, startPosition, startDirection);

            // Assert
            Assert.Equal(startPosition, turtle.Position);
            Assert.Equal(startDirection, turtle.Direction);
        }

        [Fact]
        public void Turtle_ShouldThrowException_WhenStartPositionXIsInvalid()
        {
            // Arrange
            var boardDimensions = new Position { X = 5, Y = 5 };
            var startPosition = new Position { X = -1, Y = 2 }; // Invalid X position
            var startDirection = new Direction { CurrentDirection = DirectionEnum.North };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Turtle(boardDimensions, startPosition, startDirection));
            Assert.Equal("Invalid turtle starting position X value.", exception.Message);
        }

        [Fact]
        public void Turtle_ShouldThrowException_WhenStartPositionYIsInvalid()
        {
            // Arrange
            var boardDimensions = new Position { X = 5, Y = 5 };
            var startPosition = new Position { X = 2, Y = -1 }; // Invalid Y position
            var startDirection = new Direction { CurrentDirection = DirectionEnum.North };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Turtle(boardDimensions, startPosition, startDirection));
            Assert.Equal("Invalid turtle starting position Y value.", exception.Message);
        }

        [Fact]
        public void Turtle_ShouldThrowException_WhenStartDirectionIsInvalid()
        {
            // Arrange
            var boardDimensions = new Position { X = 5, Y = 5 };
            var startPosition = new Position { X = 2, Y = 2 };
            var startDirection = new Direction { CurrentDirection = (DirectionEnum)5 }; // Invalid direction

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Turtle(boardDimensions, startPosition, startDirection));
            Assert.Equal("The turtle's starting direction in the game settings file should be 0 if North, 1 if East, 2 if South, or 3 if West.", exception.Message);
        }

        [Fact]
        public void Turtle_ShouldMoveNorth_WhenDirectionIsNorth()
        {
            // Arrange
            var boardDimensions = new Position { X = 5, Y = 5 };
            var startPosition = new Position { X = 2, Y = 2 };
            var startDirection = new Direction { CurrentDirection = DirectionEnum.North };
            var turtle = new Turtle(boardDimensions, startPosition, startDirection);

            // Act
            turtle.Move();

            // Assert
            Assert.Equal(1, turtle.Position.Y);
        }

        [Fact]
        public void Turtle_ShouldMoveEast_WhenDirectionIsEast()
        {
            // Arrange
            var boardDimensions = new Position { X = 5, Y = 5 };
            var startPosition = new Position { X = 2, Y = 2 };
            var startDirection = new Direction { CurrentDirection = DirectionEnum.East };
            var turtle = new Turtle(boardDimensions, startPosition, startDirection);

            // Act
            turtle.Move();

            // Assert
            Assert.Equal(3, turtle.Position.X);
        }

        [Fact]
        public void Turtle_ShouldMoveSouth_WhenDirectionIsSouth()
        {
            // Arrange
            var boardDimensions = new Position { X = 5, Y = 5 };
            var startPosition = new Position { X = 2, Y = 2 };
            var startDirection = new Direction { CurrentDirection = DirectionEnum.South };
            var turtle = new Turtle(boardDimensions, startPosition, startDirection);

            // Act
            turtle.Move();

            // Assert
            Assert.Equal(3, turtle.Position.Y);
        }

        [Fact]
        public void Turtle_ShouldMoveWest_WhenDirectionIsWest()
        {
            // Arrange
            var boardDimensions = new Position { X = 5, Y = 5 };
            var startPosition = new Position { X = 2, Y = 2 };
            var startDirection = new Direction { CurrentDirection = DirectionEnum.West };
            var turtle = new Turtle(boardDimensions, startPosition, startDirection);

            // Act
            turtle.Move();

            // Assert
            Assert.Equal(1, turtle.Position.X);
        }

        [Fact]
        public void Turtle_ShouldRotateFromNorthToEast_WhenRotateIsCalled()
        {
            // Arrange
            var boardDimensions = new Position { X = 5, Y = 5 };
            var startPosition = new Position { X = 2, Y = 2 };
            var startDirection = new Direction { CurrentDirection = DirectionEnum.North };
            var turtle = new Turtle(boardDimensions, startPosition, startDirection);

            // Act
            turtle.Rotate();

            // Assert
            Assert.Equal(DirectionEnum.East, turtle.Direction.CurrentDirection);
        }

        [Fact]
        public void Turtle_ShouldRotateFromEastToSouth_WhenRotateIsCalled()
        {
            // Arrange
            var boardDimensions = new Position { X = 5, Y = 5 };
            var startPosition = new Position { X = 2, Y = 2 };
            var startDirection = new Direction { CurrentDirection = DirectionEnum.East };
            var turtle = new Turtle(boardDimensions, startPosition, startDirection);

            // Act
            turtle.Rotate();

            // Assert
            Assert.Equal(DirectionEnum.South, turtle.Direction.CurrentDirection);
        }

        [Fact]
        public void Turtle_ShouldRotateFromSouthToWest_WhenRotateIsCalled()
        {
            // Arrange
            var boardDimensions = new Position { X = 5, Y = 5 };
            var startPosition = new Position { X = 2, Y = 2 };
            var startDirection = new Direction { CurrentDirection = DirectionEnum.South };
            var turtle = new Turtle(boardDimensions, startPosition, startDirection);

            // Act
            turtle.Rotate();

            // Assert
            Assert.Equal(DirectionEnum.West, turtle.Direction.CurrentDirection);
        }

        [Fact]
        public void Turtle_ShouldRotateFromWestToNorth_WhenRotateIsCalled()
        {
            // Arrange
            var boardDimensions = new Position { X = 5, Y = 5 };
            var startPosition = new Position { X = 2, Y = 2 };
            var startDirection = new Direction { CurrentDirection = DirectionEnum.West };
            var turtle = new Turtle(boardDimensions, startPosition, startDirection);

            // Act
            turtle.Rotate();

            // Assert
            Assert.Equal(DirectionEnum.North, turtle.Direction.CurrentDirection);
        }
    }
}
