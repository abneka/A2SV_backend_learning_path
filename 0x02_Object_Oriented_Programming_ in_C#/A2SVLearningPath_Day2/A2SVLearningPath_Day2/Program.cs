using System;

namespace A2SVLearningPath_Day2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("     => A2SV Learning Path <=");
            Console.WriteLine("press the corresponding number to see the task");
            Console.WriteLine("1. Circle");
            Console.WriteLine("2. Rectangle");
            Console.WriteLine("3. Triangle");
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
                    Console.WriteLine("Please Enter Radius: ");
                    double radius;
                    while (!double.TryParse(Console.ReadLine(), out radius) || radius < 0)
                    {
                        Console.WriteLine("Please Enter a Valid Radius");
                    }

                    Circle circle = new Circle("Circle", radius);
                    Task01.PrintShapeArea(circle);
                    break;
                
                case 2:
                    Console.WriteLine("Please Enter Width: ");
                    double width;
                    while (!double.TryParse(Console.ReadLine(), out width) || width < 0)
                    {
                        Console.WriteLine("Please Enter a Valid Width");
                    }
                    Console.WriteLine("Please Enter Height: ");
                    double height;
                    while (!double.TryParse(Console.ReadLine(), out height) || height < 0)
                    {
                        Console.WriteLine("Please Enter a Valid Height");
                    }

                    Rectangle rectangle = new Rectangle("Rectangle", width, height);
                    Task01.PrintShapeArea(rectangle);
                    break;
                
                case 3:
                    Console.WriteLine("Please Enter Base: ");
                    double basee;
                    while (!double.TryParse(Console.ReadLine(), out basee) || basee < 0)
                    {
                        Console.WriteLine("Please Enter a Valid Base");
                    }
                    Console.WriteLine("Please Enter Height: ");
                    while (!double.TryParse(Console.ReadLine(), out height) || height < 0)
                    {
                        Console.WriteLine("Please Enter a Valid Height");
                    }

                    Triangle triangle = new Triangle("Triangle", basee, height);
                    Task01.PrintShapeArea(triangle);
                    break;
            }
        }
    }
}