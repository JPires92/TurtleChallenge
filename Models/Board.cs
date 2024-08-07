using TurtleChallenge.Exceptions;

namespace TurtleChallenge.Models{
    public class Board{
        /// <summary>
        /// Value of X
        /// </summary>
        public int Width { get; set; }     
        /// <summary>
        /// Value of Y
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// ExitPoint(X,Y)
        /// </summary>
        public Position ExitPoint { get; set; } = new Position();
        /// <summary>
        /// List of mines positions
        /// </summary>
        public List<Position> Mines { get; set; } = new List<Position>();

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public Board() { }

        /// <summary>
        /// Constructor with parameters and validations
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="exitPoint"></param>
        /// <param name="mines"></param>
        /// <exception cref="Exception"></exception>
        public Board(int width, int height, Position exitPoint, List<Position> mines) {
            if(width <= 0)
                throw new ChallengeDataException("Board width must be greater then 0.");
            
            if(height <= 0)
                throw new ChallengeDataException("Board height must be greater then 0.");
            
            foreach(var position in mines) {
                if((width-1)<position.X || (height-1) < position.Y)
                {
                    throw new ChallengeDataException($"Mine({position.X},{position.Y}) value out of the board."); 
                }
                Mines.Add(position);
            }

            Width = width;
            Height = height;
            ExitPoint = exitPoint;
        }
    }
}