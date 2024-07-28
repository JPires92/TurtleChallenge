using TurtleChallenge.Models;

namespace TurtleChallenge.Services
{
    public class GameService
    {
        /// <summary>
        /// Starts game
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public string PlayGame(GameSettings settings, MoveSequence sequence)
        {
            Position boardDimensions= new Position(settings.Width, settings.Height);
            Turtle turtle = new Turtle(boardDimensions, settings.StartingPosition, settings.StartingDirection);
            Board board =new Board(settings.Width, settings.Height, settings.ExitPoint, settings.Mines);

            foreach (var move in sequence.Moves)
            {
                if (move == 'm' || move == 'M')
                {
                    turtle.Move();
                }
                else if (move == 'r' || move == 'R')
                {
                    turtle.Rotate();
                }
                else
                {
                    return $"Invalid value in move sequence-'{move}'.";
                }

                if (board.Mines.Any(mine => mine.X == turtle.Position.X && mine.Y == turtle.Position.Y))
                {
                    return "Mine hit!";
                }

                if (turtle.Position.X == board.ExitPoint.X && turtle.Position.Y == board.ExitPoint.Y)
                {
                    return "Success!";
                }

                if (turtle.Position.X < 0 || turtle.Position.X >= board.Width || turtle.Position.Y < 0 || turtle.Position.Y >= board.Height)
                {
                    return "Turtle moved out of bounds.";
                }
            }

            return "Still in danger!";
        }
    }
}
