using MarsRover.Enums;

namespace MarsRover
{
    public class Position(int X, int Y, CompassDirections Direction)
    {
        public int X { get; private set; } = X;
        public int Y { get; private set; } = Y;
        public CompassDirections Direction { get; private set; } = Direction;

        public void UpdateDirection(CompassDirections direction)
        {
            Direction = direction;
        }

        public void UpdatePosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string? ToString()
        {
            return $"x: {X}, y: {Y}, facing: {Direction}";
        }
    }
}
