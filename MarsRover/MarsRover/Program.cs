namespace MarsRover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MissionControl missionControl = new();
            Position rover1Pos = new Position(5, 5, Enums.CompassDirections.N);
            Rover rover1 = missionControl.InitaliseNewRover(rover1Pos);
            Console.WriteLine(rover1Pos.ToString());

        }
    }
}
