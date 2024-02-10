﻿namespace Hedgehog
{
    class Playground
    {
        public int MeetNumber { get; private set; }
        public int[] HedgehogColors { get; }
        public Colors DesiredColor { get; }
        public List<Hedgehog> Hedgehogs { get; }

        public Playground(int desiredColor, int[] hedgehogNumbers)
        {
            ValidateInputs(desiredColor, hedgehogNumbers);

            this.DesiredColor = (Colors)desiredColor;
            this.HedgehogColors = hedgehogNumbers;
            this.Hedgehogs = new List<Hedgehog>();

            InitializeHedgehogs();
        }

        public int PlanMeetings()
        {
            const int impossibleMeetings = -1;

            if (ThereAreOneColorHedgehogs())
                return this.MeetNumber = impossibleMeetings;

            OtherColors colors = HedgehogOutsidersColor(this.DesiredColor);

            if (OtherHedgehogsHavePairs(this.HedgehogColors[colors.First], this.HedgehogColors[colors.Second]))
            {
                this.MeetNumber = this.HedgehogColors[colors.First];
                HedgehogsMeetings(this.Hedgehogs, colors, this.MeetNumber, (int)this.DesiredColor);
                return this.MeetNumber;
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

        public bool CheckHedgehogsColor(Colors checkColor)
        {
            int desiredHedgehogsNumber = this.Hedgehogs.Where(hedgehog => hedgehog.color == checkColor).ToArray().Length;
            int writtenHedgehogsNumber = this.HedgehogColors[(int)checkColor];

            return desiredHedgehogsNumber == writtenHedgehogsNumber;
        }

        void ValidateInputs(int desiredColor, int[] hedgehogNumbers)
        {
            if (desiredColor < 0 || desiredColor >= Enum.GetValues(typeof(Colors)).Length)
            {
                throw new ArgumentOutOfRangeException(nameof(desiredColor), "Invalid color index.");
            }

            if (hedgehogNumbers is null)
            {
                throw new ArgumentNullException(nameof(hedgehogNumbers), "Color number array cannot be null.");
            }
            
            if (hedgehogNumbers.Length != Enum.GetValues(typeof(Colors)).Length)
            {
                throw new ArgumentException("Invalid number of hedgehog colors provided", nameof(hedgehogNumbers));
            }

            if (hedgehogNumbers.Sum() < 1 && hedgehogNumbers.Sum() > int.MaxValue)
            {
                throw new ArgumentException("Sum of hedgehog numbers should be between 1 and int.MaxValue.", nameof(hedgehogNumbers));
            }
        }

        void InitializeHedgehogs()
        {
            for (int i = 0; i < HedgehogColors.Length; i++)
            {
                for (int j = 0; j < HedgehogColors[i]; j++)
                {
                    Hedgehog hedgehog = new Hedgehog((Colors)i);
                    Hedgehogs.Add(hedgehog);
                }
            }
        }

        int StartMeetings(OtherColors color)
        {
            int numOfMeetings = 0;

            while (HedgehogColors[color.First] != HedgehogColors[color.Second])
            {
                int min = Array.IndexOf(HedgehogColors, HedgehogColors.Min());

                OtherColors tempColors = HedgehogOutsidersColor((Colors)min);
                HedgehogsMeeting(this.Hedgehogs, tempColors, min);

                numOfMeetings++;
            }

            int remainingMeetings = this.HedgehogColors[color.First];

            HedgehogsMeetings(this.Hedgehogs, color, remainingMeetings, (int)this.DesiredColor);
            numOfMeetings += remainingMeetings;

            return numOfMeetings;
        }

        void HedgehogsMeetings(List<Hedgehog> allHedgehogs, OtherColors hedgehogColors, int meetingsNum, int mainColor)
        {
            ChangeHedgehogsNumber(meetingsNum, mainColor, hedgehogColors);

            var firstGroup = GetHedgehogGroup(allHedgehogs, (Colors)hedgehogColors.First, meetingsNum);
            var secondGroup = GetHedgehogGroup(allHedgehogs, (Colors)hedgehogColors.Second, meetingsNum);

            var zippedGroups = firstGroup.Zip(secondGroup, (first, second) => new { First = first, Second = second });

            foreach (var pair in zippedGroups)
            {
                pair.First.MeetHedgehog(pair.Second);
            }
        }
        
        void HedgehogsMeeting(List<Hedgehog> allHedgehogs, OtherColors hedgehogColors, int mainColor)
        {
            ChangeHedgehogsNumber(1, mainColor, hedgehogColors);

            Hedgehog first = GetHedgehog(allHedgehogs, (Colors)hedgehogColors.First);
            Hedgehog second = GetHedgehog(allHedgehogs, (Colors)hedgehogColors.Second);

            first.MeetHedgehog(second);
        }

        Hedgehog GetHedgehog(List<Hedgehog> fullGroup, Colors wantedColor)
        {
            return fullGroup.First(hedgehog => hedgehog.color == wantedColor);
        }

        IEnumerable<Hedgehog> GetHedgehogGroup(List<Hedgehog> fullGroup, Colors wantedColor, int takeNum)
        {
            return fullGroup.Where(hedgehog => hedgehog.color == wantedColor).Take(takeNum);
        }

        void ChangeHedgehogsNumber(int meetingsNumber, int mainColor, OtherColors otherColors)
        {
            this.HedgehogColors[otherColors.First] -= meetingsNumber;
            this.HedgehogColors[otherColors.Second] -= meetingsNumber;
            this.HedgehogColors[mainColor] += meetingsNumber * 2;
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