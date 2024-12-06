namespace MarsRover.GameElements
{
    public class Inventory
    {
        public List<Sample> Samples { get; private set; }

        public Inventory()
        {
            Samples = new();
        }

        public void Add(Sample sample)
        {
            Samples.Add(sample);
        }

        public void Remove(Sample sample)
        {
            Samples.Remove(sample);
        }
    }
}
