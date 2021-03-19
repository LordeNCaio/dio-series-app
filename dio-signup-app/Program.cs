using dio_signup_app.Entities;
using dio_signup_app.Enums;
using dio_signup_app.Repositories;
using System;

namespace dio_signup_app
{
    class Program
    {
        static SeriesRepository _seriesRepository = new SeriesRepository();

        static void Main(string[] args)
        {
            string userInput = UserInput();

            while(userInput != "9")
            {
                Console.WriteLine();
                switch (userInput)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSeries();
                        break;
                    case "5":
                        ViewSeries();
                        break;
                    case "8":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userInput = UserInput();
            }
            Console.WriteLine("Thanks for using our Dwarfs");
        }

        public static void ListSeries()
        {
            Console.WriteLine("List Dwarf Series");
            var series = _seriesRepository.ListItem();
            if(series.Count == 0)
            {
                Console.WriteLine("No dwarts has been encountered");
                return;
            }
            foreach(var s in series)
            {
                Console.WriteLine("#ID {0}: - {1}", s.Id, s.Name);
            }
        }

        public static void InsertSeries()
        {
            Console.WriteLine("Insert a new Dwarf Series");
            foreach(uint i in Enum.GetValues(typeof(Category)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Category), i));
            }

            Console.WriteLine("\nInsert the category number between the above value:");
            int category = int.Parse(Console.ReadLine());

            Console.WriteLine("\nInsert the series name:");
            string name = Console.ReadLine();

            Console.WriteLine("\nInsert the series description:");
            string desc = Console.ReadLine();

            Console.WriteLine("\nInsert the series release year:");
            int release = int.Parse(Console.ReadLine());

            Series newSeries = new Series(id: _seriesRepository.NextId(), name: name, description: desc, releaseYear: release, category: (Category)category);
            _seriesRepository.Create(newSeries);
        }

        public static void UpdateSeries()
        {
            Console.WriteLine("Update a Dwarf Series");
            ListSeries();

            Console.WriteLine("\nInsert the number of the series to be updated:");
            int series = int.Parse(Console.ReadLine());

            Console.WriteLine();
            foreach (uint i in Enum.GetValues(typeof(Category)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Category), i));
            }

            Console.WriteLine("\nUpdate the series category, using number between the above value:");
            int category = int.Parse(Console.ReadLine());

            Console.WriteLine("\nUpdate the series series name:");
            string name = Console.ReadLine();

            Console.WriteLine("\nUpdate the series description:");
            string desc = Console.ReadLine();

            Console.WriteLine("\nUpdate the series release year:");
            int release = int.Parse(Console.ReadLine());

            Series newSeries = new Series(id: series, name: name, description: desc, releaseYear: release, category: (Category)category);
            _seriesRepository.Update(series, newSeries);
        }

        public static void DeleteSeries()
        {
            Console.WriteLine("Delete a Dwarf Series");
            ListSeries();

            Console.WriteLine("\nInsert the number of the series to be deleted:");
            int series = int.Parse(Console.ReadLine());
            _seriesRepository.Delete(series);
        }

        public static void ViewSeries()
        {
            Console.WriteLine("\nView Dwarf Series");
            ListSeries();

            Console.WriteLine("\nSelect one series:");
            int series = int.Parse(Console.ReadLine());

            var s = _seriesRepository.FindById(series);
            Console.WriteLine("\n" + s.ToString());
        }

        public static string UserInput()
        {
            Console.WriteLine();
            Console.WriteLine("DwarFlix the Dwarf Entertainment World");
            Console.WriteLine("Insert an option");

            Console.WriteLine("1 - List Dwarf Series");
            Console.WriteLine("2 - Insert a new Dwarf Series");
            Console.WriteLine("3 - Update Dwarf Series");
            Console.WriteLine("4 - Delete Dwarf Series");
            Console.WriteLine("5 - View Dwarf Series");
            Console.WriteLine("8 - Clear DwarFlix Console");
            Console.WriteLine("9 - Exit DwarFlix");

            Console.WriteLine();
            return Console.ReadLine().ToUpper();
        }

    }
}
