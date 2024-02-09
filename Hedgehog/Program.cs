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
        public int[] hedgehogColors { get; set; }
        public Colors desiredColor { get; set; }
        public List<Hedgehog> hedgehogs { get; set; }
        public Playground(int desiredColor, int[] hedgehogNumbers)
        {
            this.desiredColor = (Colors)desiredColor;
            this.hedgehogColors = hedgehogNumbers;
            this.hedgehogs = new List<Hedgehog>();
            for (int i = 0; i < hedgehogNumbers.Length; i++) 
            {
                for (int j = 0; j < hedgehogNumbers[i]; j++)
                {
                    Hedgehog hedgehog = new Hedgehog((Colors)i);
                    hedgehogs.Add(hedgehog);
                }
            }
        }
        public int calcMeetingsNumber()
        {
            const int impossibleMeetings = -1;
            if (thereAreOneColorHedgehogs())
            {
                return meetNumber = impossibleMeetings;
            }

            var otherColors = hedgehogOutsidersColor();
            int firstColor = (int)otherColors.Item1;
            int secondColor = (int)otherColors.Item2;
            
            if (otherHedgehogsHavePairs(hedgehogColors[firstColor], hedgehogColors[secondColor]))
            {
                return meetNumber = hedgehogColors[firstColor];
            }
            else if (canMergeIntoOneColor(hedgehogColors[firstColor], hedgehogColors[secondColor]))
            {
                return meetNumber = impossibleMeetings;
            }
            else
            {
                return meetNumber = startMeetings(firstColor, secondColor);
            }
        }
        int startMeetings(int groupIndex1, int groupIndex2)
        {
            int numOfMeetings = 0;
            while (hedgehogColors[groupIndex1] != hedgehogColors[groupIndex2])
            {
                int min = Array.IndexOf(hedgehogColors, hedgehogColors.Min());
                hedgehogColors[min] += 2;
                for (int i = 0; i < hedgehogColors.Length; i++)
                {
                    if (i != min)
                    {
                        hedgehogColors[i]--;
                    }
                }

                numOfMeetings++;
            }
            
            return numOfMeetings;
        }

        (Colors, Colors) hedgehogOutsidersColor()
        {
            switch (desiredColor)
            {
                case Colors.Red:
                    return (Colors.Green, Colors.Blue);
                case Colors.Green:
                    return (Colors.Red, Colors.Blue);
                case Colors.Blue:
                    return (Colors.Red, Colors.Green);
                default:
                    throw new ArgumentException("Invalid color");
            }
        }
        bool thereAreOneColorHedgehogs()
        {
            return hedgehogs.Count == hedgehogColors[(int)desiredColor];
        }

        bool otherHedgehogsHavePairs(int groupNumber1, int groupNumber2)
        {
            return groupNumber1 == groupNumber2;
        }
        bool canMergeIntoOneColor(int groupNumber1, int groupNumber2)
        {
            const int unacceptableDifferenceDivisor = 3;
            int difference = Math.Abs(groupNumber1 - groupNumber2);
            return difference % unacceptableDifferenceDivisor != 0;
        }
    }
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
    internal class Program
    {
        static void Main(string[] args)
        {
            Playground happyHedgehogs = new Playground(0, [8, 1, 13]);
            Console.WriteLine(happyHedgehogs.calcMeetingsNumber());
        }
    }
} 