using MarsRover.Enums;
using System.Text.RegularExpressions;

namespace MarsRover
{
    public static class InputParser
    {
        private static Regex regEx;

        public static Plateau? ParsePlateauSize(string inputString)
        {
            regEx = new(@"^\d[ ,]\d");

            if (!regEx.IsMatch(inputString)) return null;

            int x;
            int y;
            string[] dimensions;

            if (inputString.Contains(',')) dimensions = inputString.Split(",");
            else dimensions = inputString.Split(" ");


            if (int.TryParse(dimensions[0], out x) && int.TryParse(dimensions[0], out y)) return new Plateau(x, y);
            else return null;
        }

        public static Position? ParsePosition(string inputString)
        {
            regEx = new(@"^\d[ ,]\d[ ,][NSEWnsew]$");

            if (!regEx.IsMatch(inputString)) return null;

            int x;
            int y;
            char position;
            string[] dimensions;

            if (inputString.Contains(',')) dimensions = inputString.Split(",");
            else dimensions = inputString.Split(" ");


            if (int.TryParse(dimensions[0], out x) && int.TryParse(dimensions[0], out y)) return new Position(x, y, (CompassDirections)char.ToLower(char.Parse(dimensions[2])));
            else return null;
        }

        public static Instructions[]? ParseInstructions(string inputString)
        {
            regEx = new(@"^[LRMlrm]+$");

            if (!regEx.IsMatch(inputString)) return null;

            Instructions[] instructions = inputString.ToCharArray().Select(x => (Instructions)char.ToLower(x)).ToArray();

            return instructions;
        }

    }
}
