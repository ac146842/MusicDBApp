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
        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to MusicDB ");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all Records in Genres");
        }

        public void DisplayGenres(List<Genres> genres)
        {
            List<Genres> genres = storageManager.GetAllGenres();
            foreach (Genres genre in genres)
            {
                Console.WriteLine($"{genres.GenreName}, {genres.GenreID}");
            }
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
