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
        public void InputParser_ParseInstructions(Instructions input, Position expectedResult)
        {
            //Arrange
            MissionControl missionControl = new();
            Rover newRover = missionControl.InitaliseNewRover(new Position(0, 0, CompassDirections.N));

            //Act
            newRover.Rotate(input);

            //Assert
            newRover.Position.Should().BeEquivalentTo(expectedResult);
        }
    }
}
