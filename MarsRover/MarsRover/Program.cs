namespace MarsRover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Plateau plateau = (Plateau)InputParser.ParsePlateauSize("15 15");
            Position? startPosition = InputParser.ParsePosition("0 0 N");
            if (startPosition is null)
            {
                Console.WriteLine("Invalid input detected");
            }

            MissionControl missionControl = new(plateau);
            Rover newRover = missionControl.InitaliseNewRover(startPosition);
            plateau.Rocks.ForEach(x => Console.WriteLine(x.x + " " + x.y));
            newRover.Move();
            newRover.Move();
            newRover.Move();


            //Rover rover1 = missionControl.InitaliseNewRover(rover1Pos);
            //int f = 2;
            //Console.WriteLine(10 / 2);
            //Console.WriteLine(-2 == -(f));
        }
    }
}
