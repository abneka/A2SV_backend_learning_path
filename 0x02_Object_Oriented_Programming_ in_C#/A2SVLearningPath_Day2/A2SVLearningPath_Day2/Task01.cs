using System;

namespace A2SVLearningPath_Day2
{
    public class Task01
    {
        public static void PrintShapeArea(Shape obj)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Shape: " + obj.Name);
            Console.WriteLine("Area: " + obj.CalculateArea());
        }
    }
}