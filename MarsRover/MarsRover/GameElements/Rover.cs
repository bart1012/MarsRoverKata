using MarsRover.Enums;

namespace MarsRover
{
    public class Rover
    {
        private bool _shouldStop = false;
        private Plateau _terrain;
        public Position Position { get; private set; }

        public Rover(Position position, Plateau plateau)
        {
            Position = position;
            _terrain = plateau;
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
            Console.WriteLine(Position.ToString());

        }

        public void Move()
        {

            DetectTerrainBoundry();
            DetectRock();
            if (_shouldStop) { Console.WriteLine("Something is in the way"); return; }
            switch (Position.Direction)
            {
                case CompassDirections.N: Position.UpdateY(Position.Y + 1); break;
                case CompassDirections.S: Position.UpdateY(Position.Y - 1); break;
                case CompassDirections.E: Position.UpdateX(Position.X + 1); break;
                case CompassDirections.W: Position.UpdateX(Position.X - 1); break;
                default: break;
            }
            Console.WriteLine(Position.ToString());

        }

        private void DetectTerrainBoundry()
        {
            if (Position.X == -((_terrain.X / 2) - 1) && Position.Direction == CompassDirections.W) _shouldStop = true;
            else if (Position.X == ((_terrain.X / 2) - 1) && Position.Direction == CompassDirections.E) _shouldStop = true;
            else if (Position.Y == ((_terrain.Y / 2) - 1) && Position.Direction == CompassDirections.N) _shouldStop = true;
            else if (Position.Y == -((_terrain.X / 2) - 1) && Position.Direction == CompassDirections.S) _shouldStop = true;
            else _shouldStop = false;
        }

        private void DetectRock()
        {
            foreach (Rock rock in _terrain.Rocks)
            {
                if (Position.X == (rock.x + 1) && Position.Direction == CompassDirections.W) _shouldStop = true;
                else if (Position.X == (rock.x - 1) && Position.Direction == CompassDirections.E) _shouldStop = true;
                else if (Position.Y == (rock.y - 1) && Position.Direction == CompassDirections.N) _shouldStop = true;
                else if (Position.Y == (rock.y + 1) && Position.Direction == CompassDirections.S) _shouldStop = true;
                else _shouldStop = false;
            }
        }

        public void ExecuteInstructions(Instructions[] instructions)
        {
            foreach (var item in instructions)
            {
                if (item == Instructions.L || item == Instructions.R)
                {
                    this.Rotate(item);
                }
                else
                {
                    this.Move();
                }
            }
        }
    }
}
