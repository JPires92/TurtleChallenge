using TurtleChallenge.Enums;
using TurtleChallenge.Exceptions;

namespace TurtleChallenge.Models{
    public class Turtle
    {
        /// <summary>
        /// Turtle position(x,y)
        /// </summary>
        public Position Position { get; set; } = new Position();
        /// <summary>
        /// Turtle direction
        /// Ex.: 1 == East
        /// </summary>
        public Direction Direction { get; set; } = new Direction();

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public Turtle(){}

       /// <summary>
       /// Constructor with parameters.
       /// </summary>
       /// <param name="boardDimensions">For validate turtle starting position</param>
       /// <param name="startPosition"></param>
       /// <param name="startDirection"></param>
        public Turtle(Position boardDimensions,Position startPosition, Direction startDirection)
        {
            //Validates the position X
            if(startPosition.X < 0 || ((startPosition.X > boardDimensions.X-1) && boardDimensions.X >0))
            {
                throw new ChallengeDataException("Invalid turtle starting position X value.");
            }

            //Validates the position Y
            if(startPosition.Y <0 || ((startPosition.Y > boardDimensions.Y-1) && boardDimensions.Y > 0))
            {
                throw new ChallengeDataException("Invalid turtle starting position Y value.");
            }

            DirectionEnum _direction = startDirection.CurrentDirection;
            if(_direction != DirectionEnum.North && _direction != DirectionEnum.South 
            && _direction != DirectionEnum.West && _direction != DirectionEnum.East){
                throw new ChallengeDataException("The turtle's starting direction in the game settings file should be 0 if North, 1 if East, 2 if South, or 3 if West.");
            }


            Position = new Position(startPosition.X, startPosition.Y);
            Direction = new Direction(startDirection.CurrentDirection);
        }

        #region Methods
        /// <summary>
        /// Method to move the turtle one tile forward
        /// </summary>
        public void Move()
        {
            switch (Direction.CurrentDirection)
            {
                case DirectionEnum.North:
                    Position.Y -= 1;
                    break;
                case DirectionEnum.East:
                    Position.X += 1;
                    break;
                case DirectionEnum.South:
                    Position.Y += 1;
                    break;
                case DirectionEnum.West:
                    Position.X -= 1;
                    break;
            }
        }

        /// <summary>
        /// Method to change the turtle direction
        /// </summary>
        public void Rotate()
        {
            Direction.Rotate();
        }
        #endregion
    }
}
