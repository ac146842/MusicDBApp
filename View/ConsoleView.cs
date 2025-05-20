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
            Console.WriteLine("1. View all Records in Genres");

            return Console.ReadLine();
        }

        public void DisplayGenres(List<Genres> genres)
        {
            foreach (Genres genre in genres)
            {
                Console.WriteLine($"{genre.Genre_ID}, {genre.Genre_ID}");
            }
        }
    }
}