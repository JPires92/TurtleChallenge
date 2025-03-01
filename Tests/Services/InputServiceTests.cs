using Moq;
using Newtonsoft.Json;
using TurtleChallenge.Enums;
using TurtleChallenge.Services;
using TurtleChallenge.Utilities;
using Xunit;

namespace TurtleChallenge.Tests.Services
{
    public class InputServiceTests
    {
        private readonly Mock<IFileReader> _mockFileReader;
        private readonly InputService _inputService;

        public InputServiceTests()
        {
            _mockFileReader = new Mock<IFileReader>();
            _inputService = new InputService(_mockFileReader.Object);
        }

        [Fact]
        public void ReadGameSettings_ShouldReturnSettings_WhenFileIsValid()
        {
            // Arrange
            var filePath = "game-settings";
            var fileContent = @"{
                ""Board"": {
                    ""Width"": 5,
                    ""Height"": 4,
                    ""ExitPoint"": {
                        ""X"": 4,
                        ""Y"": 2
                    },
                    ""Mines"": [
                        {
                            ""X"": 1,
                            ""Y"": 2
                        },
                        {
                            ""X"": 3,
                            ""Y"": 1
                        }
                    ]
                },
                ""Turtle"": {
                    ""Position"": {
                        ""X"": 0,
                        ""Y"": 1
                    },
                    ""Direction"": {
                        ""CurrentDirection"": 0
                    }
                }
            }";
            _mockFileReader.Setup(fr => fr.ReadFile("Data\\game-settings.json")).Returns(fileContent);

            // Act
            var settings = _inputService.ReadGameSettings(filePath);

            // Assert
            Assert.NotNull(settings);
            Assert.Equal(5, settings.board.Width);
            Assert.Equal(4, settings.board.Height);
            Assert.Equal(0, settings.turtle.Position.X);
            Assert.Equal(1, settings.turtle.Position.Y);
            Assert.Equal(DirectionEnum.North, settings.turtle.Direction.CurrentDirection);
            Assert.Equal(4, settings.board.ExitPoint.X);
            Assert.Equal(2, settings.board.ExitPoint.Y);
            Assert.Collection(settings.board.Mines,
                mine => { Assert.Equal(1, mine.X); Assert.Equal(2, mine.Y); },
                mine => { Assert.Equal(3, mine.X); Assert.Equal(1, mine.Y); }
            );
        }

        [Fact]
        public void ReadGameSettings_ShouldThrowJsonReaderException_WhenFileIsInvalid()
        {
            // Arrange
            _mockFileReader.Setup(fr => fr.ReadFile(It.IsAny<string>())).Returns("Invalid JSON");

            // Act & Assert
            Assert.Throws<JsonReaderException>(() => _inputService.ReadGameSettings("invalid-path"));
        }

        [Fact]
        public void ReadMoveSequences_ShouldReturnSequences_WhenFileIsValid()
        {
            // Arrange
            var filePath = "moves";
            var fileContent = @"[
                {
                    ""Moves"": [""m"", ""r"", ""m"", ""m"", ""r"", ""m"", ""m"", ""r"", ""r"", ""r"", ""m"", ""m""]
                },
                {
                    ""Moves"": [""m"", ""r"", ""m"", ""r"", ""m"", ""m"", ""r"", ""r"", ""m"", ""m""]
                }
            ]";
            _mockFileReader.Setup(fr => fr.ReadFile("Data\\moves.json")).Returns(fileContent);

            // Act
            var moveSequences = _inputService.ReadMoveSequences(filePath);

            // Assert
            Assert.NotNull(moveSequences);
            Assert.Equal(2, moveSequences.Count);
        }


        [Fact]
        public void ReadMoveSequences_ShouldThrowJsonReaderException_WhenFileIsInvalid()
        {
            // Arrange
            _mockFileReader.Setup(fr => fr.ReadFile(It.IsAny<string>())).Returns("Invalid JSON");

            // Act & Assert
            Assert.Throws<JsonReaderException>(() => _inputService.ReadMoveSequences("invalid-path"));
        }
    }
}
