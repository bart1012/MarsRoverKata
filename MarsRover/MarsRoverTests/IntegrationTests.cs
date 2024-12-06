using FluentAssertions;
using MarsRover;

namespace MarsRoverTests
{
    internal class IntegrationTests
    {
        [Test]
        public void InitializeAndExecuteInstructions()
        {
            //Arrange
            Plateau plateau = (Plateau)InputParser.ParsePlateauSize("5 5");
            Position? startPosition = InputParser.ParsePosition("0 0 N");
            MissionControl missionControl = new(plateau);
            Rover newRover = missionControl.InitaliseNewRover(startPosition);

            //Act
            var instructions = InputParser.ParseInstructions("LMLMLMLMM");
            newRover.ExecuteInstructions(instructions);

            //Assert
            newRover.Position.Should().BeEquivalentTo(new Position(0, 1, MarsRover.Enums.CompassDirections.N));
        }


    }
}
