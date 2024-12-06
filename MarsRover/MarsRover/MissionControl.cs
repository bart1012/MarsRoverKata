namespace MarsRover
{
    public class MissionControl
    {
        public List<Position> RoverPositions { get; private set; }
        public Plateau plateau { get; private set; }

        public MissionControl(Plateau plateau)
        {
            RoverPositions = new();
            this.plateau = plateau;
        }

        public Rover? InitaliseNewRover(Position position)
        {
            if (position.X >= plateau.X / 2 || position.Y >= plateau.Y / 2)
            {
                Console.WriteLine("Invalid Input");
                return null;
            }
            RoverPositions.Add(position);
            return new Rover(position, this.plateau);
        }

        public void SetTerrain(Plateau plateau)
        {
            this.plateau = plateau;
        }
    }
}
