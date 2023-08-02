using System;

namespace A2SVLearningPath_Day3_task2
{
    public class Book
    {
        internal string Title { get; set; } = "Book Name";
        internal string Author { get; set; } = "Jon Doe";
        internal string ISBN { get; set; } = "0000";
        internal int PublicationYear { get; set; } = DateTime.Now.Year;

        public Book(string[] input)
        {
            Title = input[0];
            Author = input[1];
            ISBN = input[2];
            PublicationYear = int.Parse(input[3]);
        }
        
        
    }
}