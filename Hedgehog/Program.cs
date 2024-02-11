namespace Hedgehog
{
    delegate Playground testMethod(int[] hedgehogsNum, int color);

    internal class Program
    {
        static void Main(string[] args)
        {
            // Uncoment next line to test main functionality
            // TestPlayground([10, 10, 10], 0);

            // Uncoment next line to test main functionality for several cases
            // TestPlaygrounds([10, 10, 10], 0, TestPlayground);

            // Uncoment next line to do full test
            // TestPlaygroundHedgehogs([10, 10, 7], 0);

            // Uncoment next line to do full test for several cases 
            // TestPlaygrounds([5, 5, 5], 1, TestPlaygroundHedgehogs);
        }

        static void TestPlaygrounds(int[] hedgehogsCount, int color, testMethod test)
        {
            int testNum = 1;
            for (int redNum = 1; redNum <= hedgehogsCount[0]; redNum++)
            {
                for (int greenNum = 1; greenNum <= hedgehogsCount[1]; greenNum++)
                {
                    for (int blueNum = 1; blueNum <= hedgehogsCount[2]; blueNum++)
                    {
                        Console.WriteLine($"TEST #{ testNum++ }");
                        test([redNum, greenNum, blueNum], color);
                    }
                }
            }
        }

        static Playground TestPlaygroundHedgehogs(int[] hedgehogsNum, int color)
        {
            Playground playground = TestPlayground(hedgehogsNum, color);

            Console.WriteLine();

            Console.WriteLine($"Red hedgehogs number: { playground.HedgehogColors[(int)Colors.Red] }");
            Console.WriteLine($"Is it correct number: { playground.CheckHedgehogsColor(Colors.Red) }");           

            Console.WriteLine($"Green hedgehogs number: { playground.HedgehogColors[(int)Colors.Green] }");
            Console.WriteLine($"Is it correct number: { playground.CheckHedgehogsColor(Colors.Green) }"); 

            Console.WriteLine($"Blue hedgehogs number: {playground.HedgehogColors[(int)Colors.Blue]}");
            Console.WriteLine($"Is it correct number: { playground.CheckHedgehogsColor(Colors.Blue) }");

            Console.WriteLine();

            return playground;
        }

        static Playground TestPlayground(int[] hedgehogsNum, int color)
        {
            Console.WriteLine($"Test data:");
            Console.WriteLine($"\tRed: { hedgehogsNum[0] }");
            Console.WriteLine($"\tGreen: { hedgehogsNum[1] }");
            Console.WriteLine($"\tBlue: { hedgehogsNum[2] }");

            Playground happyHedgehogs = new Playground(hedgehogsNum, color);
            int result = happyHedgehogs.PlanMeetings(); 

            Console.WriteLine($"The minimum number of meetings required for little cheerful hedgehogs: { result }");
            
            if (result == -1)
                Console.WriteLine("What a pity! The little hedgehogs won't be able to change colors");

            Console.WriteLine();

            return happyHedgehogs;
        }
    }
} 