namespace TurtleChallenge.Models{
    public class Position{
        /// <summary>
        /// X
        /// </summary>
        public int X {get; set;}

        /// <summary>
        /// Y
        /// </summary>
        public int Y {get; set;}

        #region Constructors
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public Position(){
            X = 0;
            Y = 0;
        }
        /// <summary>
        /// Constructor with parameters
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Position(int x, int y){
            X = x;
            Y = y;
        }
        #endregion
    }
}