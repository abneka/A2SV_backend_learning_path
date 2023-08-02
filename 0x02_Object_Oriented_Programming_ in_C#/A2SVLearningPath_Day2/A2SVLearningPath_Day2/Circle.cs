using System;

namespace A2SVLearningPath_Day2
{
    public class Circle:Shape
    {
        private double Radius { get; set; } = 0;

        public Circle(string name, double radius)
        {
            Name = name;
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}