using System;

namespace A2SVLearningPath_Day3_task2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Library library = new Library(UserInput.NewLibrary());
            Menu(library);
        }

        private static void BookMenu(Library lib)
        {
            int prompt = 1;
            while (prompt > 0 && prompt < 3)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("     => Books Menu <=");
                Console.WriteLine("press the corresponding number to activate the actions");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Remove Book");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press any number to goto previous menu");
                Console.Write(" ==> ");
                if (!int.TryParse(Console.ReadLine(), out prompt) || prompt < 1 || prompt > 2)
                {
                    Console.WriteLine("Please Enter numbers between 1 and 3 (or any number to return)");
                    Console.Write(" ==> ");
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                switch (prompt)
                {
                    case 1:
                        Book book = new Book(UserInput.NewBook());
                        lib.AddBook(book);
                        break;

                    case 2:
                        Book book2 = new Book(UserInput.NewBook());
                        lib.RemoveBook(book2);
                        break;

                    default:
                        Console.WriteLine("Returning to Menu");
                        break;
                }
            }
        }

        private static void MediaMenu(Library lib)
        {
            int prompt = 1;
            while (prompt > 0 && prompt < 3)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("     => Media Menu <=");
                Console.WriteLine("press the corresponding number to activate the actions");
                Console.WriteLine("1. Add Media");
                Console.WriteLine("2. Remove Media");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press any number to goto previous menu");
                Console.Write(" ==> ");
                if (!int.TryParse(Console.ReadLine(), out prompt) || prompt < 1 || prompt > 2)
                {
                    Console.WriteLine("Please Enter numbers between 1 and 3 (or any number to return)");
                    Console.Write(" ==> ");
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                switch (prompt)
                {
                    case 1:
                        MediaItem media = new MediaItem(UserInput.NewMedia());
                        lib.AddMediaItem(media);
                        break;

                    case 2:
                        MediaItem media2 = new MediaItem(UserInput.NewMedia());
                        lib.RemoveMediaItem(media2);
                        break;

                    default:
                        Console.WriteLine("Returning to Menu");
                        break;
                }
            }
        }

        private static void Menu(Library lib)
        {
            int prompt = 1;
            while (prompt > 0 && prompt < 4){
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"     => Welcome To {lib.Name} Library Catalogue <=");
                Console.WriteLine("press the corresponding number to see the activate the actions");
                Console.WriteLine("1. Books");
                Console.WriteLine("2. Media");
                Console.WriteLine("3. Print Catalog");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Press any number to exit");
                Console.Write(" ==> ");
                if (!int.TryParse(Console.ReadLine(), out prompt) || prompt < 1 || prompt > 3)
                {
                    Console.WriteLine("Please Enter numbers between 1 and 3 (or any number to exit)");
                    Console.Write(" ==> ");
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                switch (prompt)
                {
                    case 1:
                        BookMenu(lib);
                        break;

                    case 2:
                        MediaMenu(lib);
                        break;
                    
                    case 3:
                        lib.PrintCatalog();
                        break;

                    default:
                        Console.WriteLine("Thanks for using out system");
                        break;
                }
            }
        }
    }
}