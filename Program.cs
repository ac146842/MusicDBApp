using MusicDBApp;
using MusicDBApp.Model;
using MusicDBApp.Repos;
using MusicDBApp.View;

namespace MusicDBApp
{
    public class Program
    {
        private static StorageManager storageManager;
        private static ConsoleView view;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MusicApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storageManager = new StorageManager(connectionString);
            view = new ConsoleView();

            // string tblchoice = view.TblDisplayMenu();
            // string choice = view.DisplayMenu();
            bool Notvalid = true;
            string tblchoice;
            string choice;


            switch (choice)
            {
                case "1":
                    {
                        List<Genres> genres = storageManager.GetAllGenres();
                        view.DisplayGenres(genres);
                    }
                    break;

                case "2":
                    UpdateGenresName();
                    break;

                case "3":
                    InsertNewGenres();
                    break;

                case "4":
                    DeleteGenresByName();
                    break;               

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }


        private static void UpdateGenresName()
        {
            view.DisplayMessage("Enter the Genre_ID to update: ");
            int genreID = view.GetIntInput();
            view.DisplayMessage("Enter the new Genre name: ");
            string genreName = view.GetInput();
            int rowsAffected = storageManager.UpdateGenresName(genreID, genreName);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }

        private static void InsertNewGenres()
        {
            view.DisplayMessage("Enter the new Genre name: ");
            string genreName = view.GetInput();
            int genreID = 0;
            Genres genre = new Genres(genreName, genreID);
            int generateID = storageManager.InsertLocation(genre);
            view.DisplayMessage($"new Genre inserted with ID {generateID}");
        }

        private static void DeleteGenresByName()
        {
            view.DisplayMessage("Enter the Genre Name to delete");
            string genreName = view.GetInput();
            int rowsaffected = storageManager.DeleteLocationByName(genreName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }
    }
}
