using TurtleChallenge.Enums;

namespace TurtleChallenge.Models
{
    public class Direction
    {
        /// <summary>
        /// Current direction
        /// </summary>
        public DirectionEnum CurrentDirection { get; set; }

    
        #region Constructors
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public Direction(){
            CurrentDirection = DirectionEnum.North;
        }
        
        /// <summary>
        /// Constructor with parameter
        /// </summary>
        /// <param name="initialDirection"></param>
        public Direction(DirectionEnum initialDirection)
        {
            CurrentDirection = initialDirection;
        }
        #endregion
        
        /// <summary>
        /// Method to change the direction 90 degrees to the right
        /// </summary>
        public void Rotate()
        {
            CurrentDirection = (DirectionEnum)(((int)CurrentDirection + 1) % 4);     
        }
    }
}
