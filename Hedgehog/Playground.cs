namespace Hedgehog
{
    class Playground
    {
        public int MeetNumber {  get; set; }
        public int[] HedgehogColors { get; set; }
        public Colors DesiredColor { get; set; }
        public List<Hedgehog> Hedgehogs { get; set; }

        public Playground(int desiredColor, int[] hedgehogNumbers)
        {
            this.DesiredColor = (Colors)desiredColor;
            this.HedgehogColors = hedgehogNumbers;
            this.Hedgehogs = new List<Hedgehog>();

            for (int i = 0; i < hedgehogNumbers.Length; i++) 
            {
                for (int j = 0; j < hedgehogNumbers[i]; j++)
                {
                    Hedgehog hedgehog = new Hedgehog((Colors)i);
                    this.Hedgehogs.Add(hedgehog);
                }
            }
        }

        public int CalculateMeetingsNumber()
        {
            const int impossibleMeetings = -1;

            if (ThereAreOneColorHedgehogs())
                return this.MeetNumber = impossibleMeetings;

            OtherColors colors = HedgehogOutsidersColor(this.DesiredColor);
            
            if (OtherHedgehogsHavePairs(this.HedgehogColors[colors.First], this.HedgehogColors[colors.Second]))
            {
                return this.MeetNumber = this.HedgehogColors[colors.First];
            }
            else if (CanMergeIntoOneColor(this.HedgehogColors[colors.First], this.HedgehogColors[colors.Second]))
            {
                return this.MeetNumber = impossibleMeetings;
            }
            else
            {
                return this.MeetNumber = StartMeetings(colors);
            }
        }

        int StartMeetings(OtherColors color)
        {
            int numOfMeetings = 0;
            while (HedgehogColors[color.First] != HedgehogColors[color.Second])
            {
                int min = Array.IndexOf(HedgehogColors, HedgehogColors.Min());

                OtherColors tempColors = HedgehogOutsidersColor((Colors)min);
                
                this.HedgehogColors[min] += 2;
                this.HedgehogColors[tempColors.First]--;
                this.HedgehogColors[tempColors.Second]--;

                numOfMeetings++;
            }
            
            return numOfMeetings;
        }

        OtherColors HedgehogOutsidersColor(Colors MainColor)
        {
            switch (MainColor)
            {
                case Colors.Red:
                    return new OtherColors((int)Colors.Green, (int)Colors.Blue);
                case Colors.Green:
                    return new OtherColors((int)Colors.Red, (int)Colors.Blue);
                case Colors.Blue:
                    return new OtherColors((int)Colors.Red, (int)Colors.Green);
                default:
                    throw new ArgumentException("Invalid color");
            }
        }

        bool ThereAreOneColorHedgehogs()
        {
            return Hedgehogs.Count == HedgehogColors[(int)DesiredColor];
        }

        bool OtherHedgehogsHavePairs(int groupNumber1, int groupNumber2)
        {
            return groupNumber1 == groupNumber2;
        }

        bool CanMergeIntoOneColor(int groupNumber1, int groupNumber2)
        {
            const int unacceptableDifferenceDivisor = 3;
            int difference = Math.Abs(groupNumber1 - groupNumber2);
            return difference % unacceptableDifferenceDivisor != 0;
        }
    }
}    
