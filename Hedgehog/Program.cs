namespace Hedgehog
{
    enum colors
    {
        Red,
        Green,
        Blue
    }
    class Hedgehog
    {
        public int color {  get; set; }
        public Hedgehog(int color)
        {
            this.color = color; 
        }
        public void changeColor(Hedgehog otherHedgehog) 
        { 
            if (this.color != otherHedgehog.color)
            {

            }
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {

        }
    }
}
