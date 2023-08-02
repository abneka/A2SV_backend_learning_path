using System;
using System.Collections.Generic;

namespace A2SVLearningPath_Day3_task2
{
    public class Library
    {
        internal string Name { get; set; }
        internal string Address { get; set; }
        internal List<Book> Books { get; set; } = new List<Book>();
        internal List<MediaItem> MediaItems { get; set; } = new List<MediaItem>();


        public Library(string[] lib)
        {
            Name = lib[0];
            Address = lib[1];
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            
            Console.WriteLine("Item added Successfully");
        }

        public void RemoveBook(Book book)
        {
            int index = 0;
            int length = Books.Count;
            foreach (Book search in Books)
            {
                if (search.Title == book.Title && search.Author == book.Author && search.ISBN == book.ISBN && search.PublicationYear == book.PublicationYear)
                {
                    break;
                }

                index = index + 1;
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (index == length)
            {
                Console.WriteLine("The Book does not exist");
            }
            else
            {
                Books.RemoveAt(index);
                Console.WriteLine("Item removed Successfully");
            }
            
        }

        public void AddMediaItem(MediaItem item)
        {
            MediaItems.Add(item);
            
            Console.WriteLine("Item added Successfully");
        }

        public void RemoveMediaItem(MediaItem item)
        {
            int index = 0;
            int length = MediaItems.Count;
            foreach (MediaItem search in MediaItems)
            {
                if (search.Title == item.Title && search.MediaType == item.MediaType && search.Duration == item.Duration)
                {
                    break;
                }

                index = index + 1;
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            if (index == length)
            {
                Console.WriteLine("The Media does not exist");
            }
            else
            {
                MediaItems.RemoveAt(index);
                Console.WriteLine("Item removed Successfully");
            }
        }

        public void PrintCatalog()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("     => Items to Display <=");
            Console.WriteLine("press the corresponding number to Display the Items");
            Console.WriteLine("1. Books");
            Console.WriteLine("2. Media Items");
            Console.Write(" ==> ");
            int prompt;
            Console.ForegroundColor = ConsoleColor.Red;
            while (!int.TryParse(Console.ReadLine(), out prompt) || prompt < 1 || prompt > 3)
            {
                Console.WriteLine("Please Enter numbers between 1 and 2");
                Console.Write(" ==> ");
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            switch (prompt)
            {
                case 1:
                    foreach (Book book in Books)
                    {
                        Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                        Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                        Console.WriteLine("Title: " + book.Title);
                        Console.WriteLine("Author: " + book.Author);
                        Console.WriteLine("ISBN: " + book.Author);
                        Console.WriteLine("Publication Year: " + book.PublicationYear);
                    }
                    break;
                
                case 2:
                    foreach (MediaItem item in MediaItems)
                    {
                        Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                        Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
                        Console.WriteLine("Title: " + item.Title);
                        Console.WriteLine("Media Type: " + item.MediaType);
                        Console.WriteLine("Duration: " + item.Duration);
                    }
                    break;
            }
        }
    }
}