using System;
using CodeTest.Core;
using CodeTest.Core.Writer;


namespace CodeTest.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {


   

            string inputString;
            string subText;
            TextMatcher textMatcher;
            DisplayOutput displayOut;
           // WriteCharacterStrings();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("** TextMatcher test harness **");
            Console.WriteLine("-----------------------------------------");

            Console.Write("Enter a text:");
            inputString = Console.ReadLine();

            do
            {
                Console.Write("\nEnter the subtext:");
                subText = Console.ReadLine();

                textMatcher = new TextMatcher(inputString, subText);
                displayOut = new DisplayOutput(new FancyConsoleWriter(inputString, subText));
                displayOut.Display(textMatcher.GetMatchingPositions());

                Console.WriteLine("\nPress <ESC> to quit, any key to resume");

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            Console.WriteLine("Press the ENTER key to finish...");
            Console.ReadLine();
        }
        private static void WriteCharacterStrings()
        {
            var defColor = Console.BackgroundColor;

            Console.Write("The");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("quick");
            Console.BackgroundColor = defColor;
            Console.Write("brown");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("fox");
            Console.BackgroundColor = defColor;

        }
    }
}
