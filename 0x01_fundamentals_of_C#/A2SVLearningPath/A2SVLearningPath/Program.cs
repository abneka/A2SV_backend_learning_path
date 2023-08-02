using System;

namespace A2SVLearningPath
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("     => A2SV Learning Path <=");
            Console.WriteLine("press the corresponding number to see the task");
            Console.WriteLine("1. Task 01 - Grade Average");
            Console.WriteLine("2. Task 02 - Count Characters");
            Console.WriteLine("3. Task 03 - Check Palindrome");
            Console.Write(" ==> ");
            int prompt;
            Console.ForegroundColor = ConsoleColor.Red;
            while (!int.TryParse(Console.ReadLine(), out prompt) || prompt < 1 || prompt > 3)
            {
                Console.WriteLine("Please Enter numbers between 1 and 3");
                Console.Write(" ==> ");
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            switch (prompt)
            {
                case 1:
                    Task01.GetAverage();
                    break;
                
                case 2:
                    Task02.CountCharacter();
                    break;
                
                case 3:
                    Task03.CheckPalindrome();
                    break;
            }
        }
    }
}