namespace MarsRover
{
    public class MissionControl
    {
        public List<Position> RoverPositions { get; private set; }

        public MissionControl()
        {
            RoverPositions = new();
        }

        public Rover InitaliseNewRover(Position position)
        {
            RoverPositions.Add(position);
            return new Rover(position);
        }
    }
}
