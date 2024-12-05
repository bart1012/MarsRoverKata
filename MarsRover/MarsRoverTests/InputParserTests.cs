using FluentAssertions;
using MarsRover;
using MarsRover.Enums;
namespace MarsRoverTests
{
    public class Tests
    {

        [Test]
        public void InputParser_ParsePlateauSize_TwoIntegers()
        {
            //Arrange
            string input = "5 5";

            //Act
            var result = MarsRover.InputParser.ParsePlateauSize(input);

            //Assert
            Assert.That(result, Is.EqualTo(new Plateau(5, 5)));
        }

        [Test]
        public void InputParser_ParsePlateauSize_TwoChars()
        {
            //Arrange
            string input = "c d";

            //Act
            var result = MarsRover.InputParser.ParsePlateauSize(input);

            //Assert
            Assert.That(result, Is.EqualTo(null));
        }

        [Test]
        public void InputParser_ParsePlateauSize_OneIntegerOneChar()
        {
            //Arrange
            string input = "5 d";

            //Act
            var result = MarsRover.InputParser.ParsePlateauSize(input);

            //Assert
            Assert.That(result, Is.EqualTo(null));
        }

        [Test]
        public void InputParser_ParsePlateauSize_TwoIntegersCommaSeperated()
        {
            //Arrange
            string input = "5,5";

            //Act
            var result = MarsRover.InputParser.ParsePlateauSize(input);

            //Assert
            Assert.That(result, Is.EqualTo(new Plateau(5, 5)));
        }

        [Test]
        public void InputParser_ParsePlateauSize_EmptyString()
        {
            //Arrange
            string input = "";

            //Act
            var result = MarsRover.InputParser.ParsePlateauSize(input);

            //Assert
            Assert.That(result, Is.EqualTo(null));
        }

        [Test]
        public void InputParser_ParsePlateauSize_OneInteger()
        {
            //Arrange
            string input = "5";

            //Act
            var result = MarsRover.InputParser.ParsePlateauSize(input);

            //Assert
            Assert.That(result, Is.EqualTo(null));
        }

        [Test]
        public void InputParser_ParsePlateauSize_WhiteSpaceAtEnd()
        {
            //Arrange
            string input = "5 5 ";

            //Act
            var result = MarsRover.InputParser.ParsePlateauSize(input);

            //Assert
            Assert.That(result, Is.EqualTo(new Plateau(5, 5)));
        }

        [Test]
        public void InputParser_ParsePlateauSize_CommaAtEnd()
        {
            //Arrange
            string input = "5,5,";

            //Act
            var result = MarsRover.InputParser.ParsePlateauSize(input);

            //Assert
            Assert.That(result, Is.EqualTo(new Plateau(5, 5)));
        }

        [Test]
        public void InputParser_ParsePosition()
        {
            //Arrange
            string input = "0 0 N";

            //Act
            var result = MarsRover.InputParser.ParsePosition(input);

            //Assert
            result.Should().Be(new Position(0, 0, CompassDirections.N));
        }

        [Test]
        public void InputParser_ParsePosition_CommaSeperated()
        {
            //Arrange
            string input = "0,0,N";

            //Act
            var result = MarsRover.InputParser.ParsePosition(input);

            //Assert
            result.Should().Be(new Position(0, 0, CompassDirections.N));
        }

        [Test]
        public void InputParser_ParsePosition_CharInsteadOfIntegers()
        {
            //Arrange
            string input = "d,0,N";

            //Act
            var result = MarsRover.InputParser.ParsePosition(input);

            //Assert
            Assert.That(result, Is.EqualTo(null));
        }

        [Test]
        public void InputParser_ParsePosition_InvalidCompassDirection()
        {
            //Arrange
            string input = "0,0,F";

            //Act
            var result = MarsRover.InputParser.ParsePosition(input);

            //Assert
            Assert.That(result, Is.EqualTo(null));
        }

        public static object[] testCasesForPraseInstructions =
        {
            new object[]{"lrm", new Instructions[] {Instructions.L, Instructions.R, Instructions.M} },
            new object[]{"lrms", null }
        };

        [Test]
        [TestCaseSource(nameof(testCasesForPraseInstructions))]
        public void InputParser_ParseInstructions(string input, Instructions[] expectedResult)
        {
            //Act
            var result = MarsRover.InputParser.ParseInstructions(input);

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}