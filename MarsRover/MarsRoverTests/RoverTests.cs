using FluentAssertions;
using MarsRover;
using MarsRover.Enums;

namespace MarsRoverTests
{
    class RoverTests
    {
        public static object[] testCasesForRoverRotate =
       {
            new object[]{Instructions.L, new Position(0,0,CompassDirections.W) },
            new object[]{Instructions.R, new Position(0,0,CompassDirections.E) },
            new object[]{Instructions.M, new Position(0,0,CompassDirections.N) },


        };

        [Test]
        [TestCaseSource(nameof(testCasesForRoverRotate))]
        public void Rover_Rotate(Instructions input, Position expectedResult)
        {
            //Arrange
            Plateau plateau = new(5, 5);
            MissionControl missionControl = new(plateau);
            Rover newRover = missionControl.InitaliseNewRover(new Position(0, 0, CompassDirections.N));

            //Act
            newRover.Rotate(input);

            //Assert
            newRover.Position.Should().BeEquivalentTo(expectedResult);
        }

        public static object[] testCasesForRoverMove =
      {
            new object[]{ new Position(0, 0, CompassDirections.N), new Position(0,1,CompassDirections.N) },
            new object[]{ new Position(0, 1, CompassDirections.S), new Position(0,0,CompassDirections.S) },
            new object[]{ new Position(0, 0, CompassDirections.E), new Position(1,0,CompassDirections.E) },
            new object[]{ new Position(0, 0, CompassDirections.W), new Position(-1,0,CompassDirections.W) },

        };

        [Test]
        [TestCaseSource(nameof(testCasesForRoverMove))]
        public void Rover_Move(Position startPosition, Position expectedResult)
        {
            //Arrange
            Plateau plateau = new(5, 5);
            MissionControl missionControl = new(plateau);
            Rover newRover = missionControl.InitaliseNewRover(startPosition);

            //Act
            newRover.Move();

            //Assert
            newRover.Position.Should().BeEquivalentTo(expectedResult);
        }

        public static object[] testCasesForRoverDetectTerrainBoundry =
        {
            new object[]{ new Position(0, 0, CompassDirections.N), new Position(0,1,CompassDirections.N) },
            new object[]{ new Position(0, 0, CompassDirections.S), new Position(0,-1,CompassDirections.S) },
            new object[]{ new Position(0, 0, CompassDirections.E), new Position(1,0,CompassDirections.E) },
            new object[]{ new Position(0, 0, CompassDirections.W), new Position(-1,0,CompassDirections.W) },

        };


        [Test]
        [TestCaseSource(nameof(testCasesForRoverDetectTerrainBoundry))]
        public void Rover_DetectTerrainBoundry(Position startPosition, Position expectedResult)
        {
            //Arrange
            Plateau plateau = new(5, 5);
            MissionControl missionControl = new(plateau);
            Rover newRover = missionControl.InitaliseNewRover(startPosition);

            //Act
            newRover.Move();
            newRover.Move();
            newRover.Move();

            //Assert
            newRover.Position.Should().BeEquivalentTo(expectedResult);
        }


        [Test]
        public void Rover_SequentialMoveAndRotate()
        {
            //Arrange
            Plateau plateau = new(5, 5);
            MissionControl missionControl = new(plateau);
            Rover newRover = missionControl.InitaliseNewRover(new Position(0, 0, CompassDirections.N));

            //Act
            newRover.Move(); //0,1
            newRover.Rotate(Instructions.L);//W
            newRover.Move();//-1,1
            newRover.Move();//-1,1
            newRover.Rotate(Instructions.L);//S
            newRover.Move();//-1,0
            newRover.Move();//-1,-1

            //Assert
            newRover.Position.Should().BeEquivalentTo(new Position(-1, -1, CompassDirections.S));
        }



    }
}
