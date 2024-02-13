namespace Hedgehog
{
    delegate Playground testMethod(int[] hedgehogsNum, int color);

    internal class Program
    {
        static void Main(string[] args)
        {
            // Simple program run
            // Playground happyHedgehogs = new Playground([34, 32, 35], 0); // Paste input data here
            // int result = happyHedgehogs.PlanMeetings(); // Get output data here
            // Console.WriteLine(result); // Print output

            /* CUSTOM TESTS */

            // Uncoment next line to test main functionality
            // TestPlayground([0, 0, 17], 0);
            // TestPlayground([34, 32, 35], 0);

            // Uncoment next line to test main functionality for several cases
            // TestPlaygrounds([0, 0, 17], 0, TestPlayground);
            // TestPlaygrounds([0, 0, 0], 0, TestPlayground);

            // Uncoment next line to do full test
            // TestPlaygroundHedgehogs([0, 0, 17], 1);
            // TestPlaygroundHedgehogs([34, 32, 35], 1);

            // Uncoment next line to do full test for several cases 
            // TestPlaygrounds([0, 0, 17], 1, TestPlaygroundHedgehogs);
            // TestPlaygrounds([34, 32, 35], 1, TestPlaygroundHedgehogs);
        }

        static void TestPlaygrounds(int[] hedgehogsCount, int color, testMethod test)
        {
            Playground.ValidateInputs(hedgehogsCount, color);

            int testNum = 1;
            for (int redNum = 0; redNum <= hedgehogsCount[0]; redNum++)
            {
                for (int greenNum = 0; greenNum <= hedgehogsCount[1]; greenNum++)
                {
                    for (int blueNum = 0; blueNum <= hedgehogsCount[2]; blueNum++)
                    {
                        if (redNum + greenNum + blueNum >= 1)
                        {
                            Console.WriteLine($"TEST #{ testNum++ }");
                            test([redNum, greenNum, blueNum], color);
                        }
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