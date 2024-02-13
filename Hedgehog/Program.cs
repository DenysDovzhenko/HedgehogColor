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

            // Uncomment next line to test main functionality
            // TestPlayground([0, 0, 17], 0);
            // TestPlayground([34, 32, 35], 0);

            // Uncomment next line to test main functionality for several cases
            // TestPlaygrounds([0, 0, 17], 0, TestPlayground);
            // TestPlaygrounds([0, 0, 0], 0, TestPlayground);

            // Uncomment next line to do full test
            // TestPlaygroundHedgehogs([0, 0, 17], 1);
            // TestPlaygroundHedgehogs([34, 32, 35], 1);

            // Uncomment next line to do full test for several cases 
            // TestPlaygrounds([0, 0, 17], 1, TestPlaygroundHedgehogs);
            // TestPlaygrounds([34, 32, 35], 1, TestPlaygroundHedgehogs);

            // Uncomment next line to launch runtime interface for testing
             ConsoleInput();
        }

        static void ConsoleInput()
        {
            Console.WriteLine("\t\t\t\t\t***HEDGEHOGS-COLOR***");
            Console.WriteLine("This is hedgehogs task testing interface in runtime. You can choose here which test method to use.");
            Console.WriteLine("---");
            Console.WriteLine("*SIMPLE*");
            Console.WriteLine("\tThe method of testing one case without checking hedgehogs move.");
            Console.WriteLine("\tAccording to the instructions, enter the input data of the problem.");
            Console.WriteLine("\tUSAGE: enter 's'");
            Console.WriteLine("---");
            Console.WriteLine("*MULTIPLY-SIMPLE*");
            Console.WriteLine("\tThe method of testing multiply cases.");
            Console.WriteLine("\tIt iterates over all variants of each color from 0 (if possible) to the color value of the array.");
            Console.WriteLine("\tUSAGE: enter 'ms'");
            Console.WriteLine("---");
            Console.WriteLine("*FULL*");
            Console.WriteLine("\tThe method of testing one case with checking hedgehogs move.");
            Console.WriteLine("\tUSAGE: enter 'f'");
            Console.WriteLine("---");
            Console.WriteLine("*MULTIPLY-FULL*");
            Console.WriteLine("\tThe method of testing multiply cases with checking hedgehogs move.");
            Console.WriteLine("\tUSAGE: enter 'mf'");
            Console.WriteLine();

            do
            {
                Console.Write("ENTER VALUE [s, ms, f, mf]: ");
            } while (UserConsoleInput());
        }

        static bool UserConsoleInput()
        {
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "s":
                    TestPlayground(UserArrayInput(), UserColorInput());
                    return false;
                case "ms":
                    TestPlaygrounds(UserArrayInput(), UserColorInput(), TestPlayground);
                    return false;
                case "f":
                    TestPlaygroundHedgehogs(UserArrayInput(), UserColorInput());
                    return false;
                case "mf":
                    TestPlaygrounds(UserArrayInput(), UserColorInput(), TestPlaygroundHedgehogs);
                    return false;
                default:
                    Console.WriteLine("Wrong value, try again.");
                    return true;
            }
        }

        static int[] UserArrayInput()
        {
            int[] userArray = new int[3];

            Console.WriteLine("Enter the number of red hedgehogs.");
            userArray[0] = ValidateUserInput("0..int.MaxValue");
            Console.WriteLine("Enter the number of green hedgehogs.");
            userArray[1] = ValidateUserInput("0..int.MaxValue");
            Console.WriteLine("Enter the number of blue hedgehogs.");
            userArray[2] = ValidateUserInput(userArray[0] <= 0 && userArray[1] <= 0 ? "1..int.MaxValue": "0..int.MaxValue");

            return userArray;
        }

        static int UserColorInput()
        {
            Console.WriteLine("Enter the number of desirable hedgehog color.");
            Console.WriteLine("*possible colors:");
            Console.WriteLine("\tRed - 0");
            Console.WriteLine("\tGreen - 1");
            Console.WriteLine("\tBlue - 2");
            Console.WriteLine();

            return ValidateUserInput("0..2");
        }

        static int ValidateUserInput(string tip)
        {
            bool isValidInput;
            int number;

            do
            {
                Console.Write($"ENTER VALUE [{ tip }]: ");
                isValidInput = int.TryParse(Console.ReadLine(), out number);

                if (!isValidInput)
                    Console.WriteLine("You have to enter integer value.");

                Console.WriteLine();

            } while (!isValidInput);

            return number;
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