namespace MarsRover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "lrm";
            var inst = InputParser.ParseInstructions(input);
            if (inst is null)
            {
                Console.WriteLine("null");
            }
            foreach (var item in inst)
            {
                Console.WriteLine(item);
            }
        }
    }
}
