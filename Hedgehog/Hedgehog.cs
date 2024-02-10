namespace Hedgehog
{
    class Hedgehog
    {
        public Colors color {  get; set; }

        public Hedgehog(Colors color)
        {
            this.color = color;
        }

        public bool meetHedgehog(Hedgehog otherHedgehog) 
        { 
            if (this.color != otherHedgehog.color)
            {
                Colors rightColor = changeColor(this.color, otherHedgehog.color);
                this.color = rightColor;
                otherHedgehog.color = rightColor;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Colors changeColor(Colors color1, Colors color2)
        {
            foreach (Colors color in Enum.GetValues(typeof(Colors)))
            {
                if (color != color1 && color != color2)
                {
                    return color;
                }
            }

            throw new InvalidOperationException("Invalid combination of colors.");
        }
    }
}
