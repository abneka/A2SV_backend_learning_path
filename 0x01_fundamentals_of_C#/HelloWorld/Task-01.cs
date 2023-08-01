class Task1
{
    public static float gradeCalc()
    {
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();
  
        Console.WriteLine("Number of Subject: ");
        int numberOfGrades;
        while (!int.TryParse(Console.ReadLine(), out numberOfGrades))
        {
            Console.WriteLine("Insert a number: ");
        }

        if (numberOfGrades == 0) 
        {return 0;}

        int total = 0;
        for (int i = 0; i < numberOfGrades; i++)
        {
            Console.WriteLine("Subject Name: ");
            string? subject = Console.ReadLine();
            Console.WriteLine($"{subject}'s grade");
            int mark;
            while (!int.TryParse(Console.ReadLine(), out mark))
            {
                Console.WriteLine("Insert a number: ");
            }
            total = total + mark;
        }
        Console.WriteLine(total / numberOfGrades);
        return total / numberOfGrades;
    }
}