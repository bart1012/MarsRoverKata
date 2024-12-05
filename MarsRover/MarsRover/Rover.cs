using MarsRover.Enums;

namespace MarsRover
{
    public class Rover
    {
        public Position Position { get; private set; }

        public Rover(Position position)
        {
            Position = position;
        }

        public void Rotate(Instructions instruction)
        {
            CompassDirections newComDir = Position.Direction;

            if (instruction == Instructions.L)
            {
                if (Position.Direction == 0)
                {
                    newComDir = (CompassDirections)3;
                }
                else
                {
                    newComDir = Position.Direction - 1;
                }


            }
            else if (instruction == Instructions.R)
            {

                if (Position.Direction == (CompassDirections)3)
                {
                    newComDir = (CompassDirections)0;
                }
                else
                {
                    newComDir = Position.Direction + 1;
                }
            }

            Position.UpdateDirection(newComDir);
        }
    }
}
