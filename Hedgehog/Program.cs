namespace Hedgehog
{
    enum Colors
    {
        Red,
        Green,
        Blue
    }
    class Playground
    {
        public int meetNumber {  get; set; }
        public Colors desiredColor { get; set; }
        public Playground(int desiredColor, int[] hedgehogsNumber)
        {
            this.desiredColor = (Colors)desiredColor;
        }
        public int startMeetings()
        {
            // Not implemented
            return meetNumber;
        }
    }
    class Hedgehog
    {
        public Colors color {  get; set; }
        public Hedgehog(int color)
        {
            this.color = (Colors)color;
        }
        public bool meetHedgehog(Hedgehog otherHedgehog) 
        { 
            if (this.color != otherHedgehog.color)
            {
                Console.WriteLine("Color-changing meeting");
                foreach (Colors color in Enum.GetValues(typeof(Colors)))
                {
                    //Not implemented
                }
            }
            else
            {
                Console.WriteLine("Simple meeting");
            }
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Hedgehog hr = new Hedgehog(1);
        }
    }
}
