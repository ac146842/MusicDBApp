using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicDBApp.Model;

namespace MusicDBApp.View
{
    public class ConsoleView
    {
        public string DisplayMenu()
        {
            Console.WriteLine("Welcome to MusicDB ");
            Console.WriteLine("Menu: ");
            Console.WriteLine("Choose an option from 1-4");
            Console.WriteLine("1. View all Records in Genres");
            Console.WriteLine("2. Update a Genres name by Genre_ID");
            Console.WriteLine("3. Insert a new Genre");
            Console.WriteLine("4. Delete a Genre by Gemre_Name");

            return Console.ReadLine();
        }

        public void DisplayGenres(List<Genres> genres)
        {
            foreach (Genres genre in genres)
            {
                Console.WriteLine($"{genre.Genre_ID}, {genre.Genre_Name}");
            }
        }
    }
}