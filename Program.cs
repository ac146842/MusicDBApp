using MusicDBApp;
using MusicDBApp.Model;
using MusicDBApp.View;

namespace MusicDBApp
{
    public class Program
    {
        private static StorageManager storageManager;       
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=MusicDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storageManager = new StorageManager(connectionString);
            consoleView view = new ConsoleView();
            View.DisplayMenu();
            string choice = 

            storageManager = new StorageManager(connectionString);
            //get list from storage manager
            List<Genres> genres = storageManager.GetAllGenres();
            foreach (Genres genre in genres)
            {
                Console.WriteLine($"{genres.GenreName}, {genres.GenreID}");
            }
        }
    }
}
