namespace MarsRover
{
    public class Plateau
    {
        public int X { get; }
        public int Y { get; }

        public List<Rock> Rocks;

        public Plateau(int x, int y)
        {
            X = x;
            Y = y;
            Rocks = new();
            this.PopulateWithRocks();
        }

        public void PopulateWithRocks() //5, 15
        {
            //int numberOfRocks = Math.Max(X, Y) / 2;
            //Random random = new();
            //int availableVerticalSpace = (Y / 2) - 1;
            //int availableHorizontalSpace = (X / 2) - 1;

            //for (int i = 0; i < numberOfRocks; i++)
            //{
            //    Rocks.Add(new Rock(random.Next(-availableHorizontalSpace, availableHorizontalSpace),
            //        random.Next(-availableVerticalSpace, availableVerticalSpace)));
            //}
            Rocks.Add(new Rock(0, 1));
        }
    }
}
