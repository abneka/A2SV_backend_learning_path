namespace A2SVLearningPath_Day2
{
    public class Rectangle:Shape
    {
        public double Width { get; set; } = 0;
        public double Height { get; set; } = 0;

        public Rectangle(string name, double width, double height)
        {
            Name = name;
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }
}