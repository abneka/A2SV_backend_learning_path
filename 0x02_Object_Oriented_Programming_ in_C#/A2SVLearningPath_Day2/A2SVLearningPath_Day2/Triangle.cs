namespace A2SVLearningPath_Day2
{
    public class Triangle:Shape
    {
        public double Base { get; set; } = 0;
        public double Height { get; set; } = 0;

        public Triangle(string name, double bas, double height)
        {
            Name = name;
            Base = bas;
            Height = height;
        }

        public override double CalculateArea()
        {
            return (Base * Height) / 2;
        }
    }
}