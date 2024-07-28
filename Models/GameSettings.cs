namespace TurtleChallenge.Models{
    public class GameSettings{
        /// <summary>
        /// Value of X
        /// </summary>
        public int Width { get; set; }     
        /// <summary>
        /// Value of Y
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Position(X,Y)
        /// </summary>
        public Position StartingPosition { get; set; } = new Position();
        
        /// <summary>
        /// Direction
        /// </summary>
        public Direction StartingDirection { get; set; } = new Direction();
        /// <summary>
        /// ExitPoint(X,Y)
        /// </summary>
        public Position ExitPoint { get; set; } = new Position();
        /// <summary>
        /// List of mines positions
        /// </summary>
        public List<Position> Mines { get; set; } = new List<Position>();
    }
}