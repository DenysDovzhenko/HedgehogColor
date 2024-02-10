namespace Hedgehog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TestPlayground(10, 10, 10);
            // Console.WriteLine("End of test playground");
            TestPlaygrounds(10, 10, 10);
        }

        static void TestPlaygrounds(int redCol, int greenCol, int blueCol)
        {
            for (int redNum = 1; redNum <= redCol; redNum++)
            {
                for (int greenNum = 1; greenNum <= greenCol; greenNum++)
                {
                    for (int blueNum = 1; blueNum <= blueCol; blueNum++)
                    {
                        TestPlayground(redNum, greenNum, blueNum);
                    }
                }
            }
        }

        static void TestPlayground(int redNum, int greenNum, int blueNum)
        {
            Console.WriteLine($"Test data:");
            Console.WriteLine($"\t{ nameof(redNum) } : { redNum }");
            Console.WriteLine($"\t{ nameof(greenNum) } : { greenNum }");
            Console.WriteLine($"\t{ nameof(blueNum) } : { blueNum }");

            Playground happyHedgehogs = new Playground(1, new int[] { redNum, greenNum, blueNum });
            int result = happyHedgehogs.CalculateMeetingsNumber(); 
            Console.WriteLine($"The minimum number of meetings required for little cheerful hedgehogs: { result }");
            
            if (result == -1)
                Console.WriteLine("What a pity! The little hedgehogs won't be able to change colors");

            Console.WriteLine();
        }
    }
} 