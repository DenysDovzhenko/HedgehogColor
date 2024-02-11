namespace Hedgehog
{
    class Hedgehog
    {
        public Colors color { get; set; }

        public Hedgehog(Colors color)
        {
            this.color = color;
        }

        public void MeetHedgehog(Hedgehog otherHedgehog) 
        { 
            if (this.color != otherHedgehog.color)
            {
                Colors newColor = PickColor(this.color, otherHedgehog.color);
                this.color = newColor;
                otherHedgehog.color = newColor;
            }
            else
            {
                throw new HedgehogException("Hedgehogs cannot change with same color");
            }
        }

        Colors PickColor(Colors color1, Colors color2)
        {
            foreach (Colors colorWalker in Enum.GetValues(typeof(Colors)))
            {
                if (colorWalker != color1 && colorWalker != color2)
                    return colorWalker;
            }

            throw new InvalidOperationException("Invalid combination of colors.");
        }
    }
}
