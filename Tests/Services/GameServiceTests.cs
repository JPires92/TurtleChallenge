using TurtleChallenge.Enums;
using TurtleChallenge.Exceptions;
using TurtleChallenge.Models;
using TurtleChallenge.Services;
using Xunit;

namespace TurtleChallenge.Tests.Services
{
    public class GameServiceTests
    {
        
        private readonly GameService _gameService;

        public GameServiceTests()
        {
            _gameService = new GameService();
        }

        [Fact]
        public void PlayGame_ShouldReturnSuccess_WhenTurtleReachesExit()
        {
            // Arrange
            var settings = new GameSettings
            {
                board = new Board
                {
                    Width = 5,
                    Height = 5,
                    ExitPoint = new Position { X = 1, Y = 1 },
                    Mines = new List<Position>()
                },
                turtle = new Turtle
                {
                    Position = new Position { X = 0, Y = 0 },
                    Direction = new Direction { CurrentDirection = DirectionEnum.East }
                }
            };

            var sequence = new MoveSequence
            {
                Moves = new List<char> { 'm','r','m' }
            };

            // Act
            var result = _gameService.PlayGame(settings, sequence);

            // Assert
            Assert.Equal("Success!", result);
        }

        [Fact]
        public void PlayGame_ShouldReturnMineHit_WhenTurtleHitsMine()
        {
            // Arrange
            var settings = new GameSettings
            {
                board = new Board
                {
                    Width = 5,
                    Height = 5,
                    ExitPoint = new Position { X = 4, Y = 4 },
                    Mines = new List<Position> { new Position { X = 2, Y = 0 } }
                },
                turtle = new Turtle
                {
                    Position = new Position { X = 0, Y = 0 },
                    Direction = new Direction { CurrentDirection = DirectionEnum.East }
                }
            };

            var sequence = new MoveSequence
            {
                Moves = new List<char> { 'm', 'm' }
            };

            // Act
            var result = _gameService.PlayGame(settings, sequence);

            // Assert
            Assert.Equal("Mine hit!", result);
        }

        [Fact]
        public void PlayGame_ShouldReturnOutOfBounds_WhenTurtleMovesOutOfBounds()
        {
            // Arrange
            var settings = new GameSettings
            {
                board = new Board
                {
                    Width = 5,
                    Height = 5,
                    ExitPoint = new Position { X = 4, Y = 4 },
                    Mines = new List<Position> ()
                },
                turtle = new Turtle
                {
                    Position = new Position { X = 0, Y = 0 },
                    Direction = new Direction { CurrentDirection = DirectionEnum.West }
                }
            };

            var sequence = new MoveSequence
            {
                Moves = new List<char> { 'm' }
            };

            // Act & Assert
            var exception = Assert.Throws<ChallengeGameException>(() => _gameService.PlayGame(settings, sequence));
            Assert.Equal("Turtle moved out of bounds.", exception.Message);
        }

        [Fact]
        public void PlayGame_ShouldReturnStillInDanger_WhenTurtleDoesNotReachExitOrMine()
        {
            // Arrange
            var settings = new GameSettings
            {
                board = new Board
                {
                    Width = 5,
                    Height = 5,
                    ExitPoint = new Position { X = 4, Y = 4 },
                    Mines = new List<Position>{ new Position { X = 2, Y = 0 } }
                },
                turtle = new Turtle
                {
                    Position = new Position { X = 0, Y = 0 },
                    Direction = new Direction { CurrentDirection = DirectionEnum.East }
                }
            };

            var sequence = new MoveSequence
            {
                Moves = new List<char> { 'm', 'r', 'm' }
            };

            // Act
            var result = _gameService.PlayGame(settings, sequence);

            // Assert
            Assert.Equal("Still in danger!", result);
        }

        [Fact]
        public void PlayGame_ShouldReturnInvalidMove_WhenSequenceContainsInvalidCharacter()
        {
            // Arrange
            var settings = new GameSettings
            {
                board = new Board
                {
                    Width = 5,
                    Height = 5,
                    ExitPoint = new Position { X = 4, Y = 4 },
                    Mines = new List<Position>{ new Position { X = 2, Y = 0 } }
                },
                turtle = new Turtle
                {
                    Position = new Position { X = 0, Y = 0 },
                    Direction = new Direction { CurrentDirection = DirectionEnum.East }
                }
            };


            var sequence = new MoveSequence
            {
                Moves = new List<char> { 'm', 'x' }
            };
            
            // Act & Assert
            var exception = Assert.Throws<ChallengeGameException>(() => _gameService.PlayGame(settings, sequence));
            Assert.Equal("Invalid value in move sequence-'x'.", exception.Message);
        }
    }
}
