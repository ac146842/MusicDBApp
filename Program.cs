using MusicDBApp;
using MusicDBApp.Model;
using MusicDBApp.Repos;
using MusicDBApp.View;

namespace MusicDBApp
{
    public class Program
    {
        private static StorageManager storageManager;       
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MusicApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storageManager = new StorageManager(connectionString);
            ConsoleView view = new ConsoleView();            
            string choice = view.DisplayMenu();


            switch (choice)
            {
                case "1":
                    {
                        List<Genres> genres = storageManager.GetAllGenres();
                        view.DisplayGenres(genres);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
