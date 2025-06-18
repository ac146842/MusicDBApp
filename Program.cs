using System.Reflection.Metadata.Ecma335;
using Microsoft.IdentityModel.Tokens;
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
            //school connection
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ac146842\\OneDrive - Avondale College\\12TPI\\DBfile\\sqlcode\\MusicDB.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=True";

            storageManager = new StorageManager(connectionString);
            view = new ConsoleView();

            // string tblchoice = view.TblDisplayMenu();
            // string choice = view.DisplayMenu();
            bool Notvalid = true;
            string tblchoice;
            string choice;

            do
            {
                tblchoice = view.DisplayMenu();
                Console.Clear();

                switch (tblchoice)
                {
                    case "1":
                        view.tblRecordLabel();
                        Notvalid = false;

                        do
                        {
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "1":
                                    {
                                        List<RecordLabel> recordLabels = storageManager.GetAllRecordLabel();
                                        view.DisplayRecordLabels(recordLabels);
                                    }
                                    break;

                                case "2":
                                    UpdateRecordLabelsName();
                                    break;

                                case "3":
                                    InsertNewRecordLabels();
                                    break;

                                case "4":
                                    DeleteRecordLabelByName();
                                    break;

                                default:
                                    Console.WriteLine("Invalid option. Please try again.");
                                    break;
                            }
                        }
                        while (Notvalid);
                        break;

                        break;

                    case "2":
                        view.tblArtist();
                        Notvalid = false;

                        do
                        {
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "1":
                                    {
                                        List<Artist> artists = storageManager.GetAllArtist();
                                        view.DisplayArtists(artists);
                                    }
                                    break;

                                case "2":
                                    UpdateArtistsName();
                                    break;

                                case "3":
                                    InsertNewArtists();
                                    break;

                                case "4":
                                    DeleteArtistByName();
                                    break;

                                default:
                                    Console.WriteLine("Invalid option. Please try again.");
                                    break;
                            }
                        }
                        while (Notvalid);
                        break;

                    case "3":
                        view.tblVinyl();
                        Notvalid = false;

                        do
                        {
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "1":
                                    {
                                        List<Vinyl> vinyl = storageManager.GetAllVinyl();
                                        view.DisplayVinyls(vinyl);
                                    }
                                    break;

                                case "2":
                                    UpdateVinylsName();
                                    break;

                                case "3":
                                    InsertNewGenres();
                                    break;

                                case "4":
                                    DeleteVinylByName();
                                    break;

                                default:
                                    Console.WriteLine("Invalid option. Please try again.");
                                    break;
                            }
                        }
                        while (Notvalid);
                        break;


                    case "4":
                        view.tblGenre();
                        Notvalid = false;

                        do
                        {
                            choice = Console.ReadLine();
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
                        while (Notvalid);
                        break;

                    case "5":
                        view.tblReviews();
                        Notvalid = false;

                        do
                        {
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "1":
                                    {
                                        List<Reviews> reviews = storageManager.GetAllReviews();
                                        view.DisplayReviews(reviews);
                                    }
                                    break;

                                case "2":
                                    UpdateReviewersName();
                                    break;

                                case "3":
                                    InsertNewGenres();
                                    break;

                                case "4":
                                    DeleteReviewByName();
                                    break;

                                default:
                                    Console.WriteLine("Invalid option. Please try again.");
                                    break;
                            }
                        }
                        while (Notvalid);
                        break;

                    case "6":
                        view.tblReviewComments();
                        Notvalid = false;

                        do
                        {
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "1":
                                    {
                                        List<ReviewComments> reviewComments = storageManager.GetAllReviewComments();
                                        view.DisplayReviewComments(reviewComments);
                                    }
                                    break;

                                case "2":
                                    UpdateReviewComments();
                                    break;

                                case "3":
                                    InsertNewGenres();
                                    break;

                                case "4":
                                    DeleteReviewCommentByName();
                                    break;

                                default:
                                    Console.WriteLine("Invalid option. Please try again.");
                                    break;
                            }
                        }
                        while (Notvalid);
                        break;

                    case "7":
                        view.Queries();
                        break;
                        /*
                        do
                        {
                            choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "1":
                                    {
                                        view.AdvQry1();
                                    }
                                    break;

                                case "2":
                                    //UpdateReviewersName();
                                    break;

                                case "3":
                                    //InsertNewGenres();
                                    break;

                                case "4":
                                    //DeleteGenresByName();
                                    break;

                                default:
                                    Console.WriteLine("Invalid option. Please try again.");
                                    break;
                            }
                        }

                        while (Notvalid);
                        break;
                        */
                    default:
                        Console.WriteLine("Invalid option please try again.");
                        Notvalid = false;
                        break;
                }
            }
            while (true);

            storageManager.CloseConnection();
        }


        private static void Login()
        {
            Console.WriteLine("Please enter your Username: ");
            string UserName = Console.ReadLine();

            Console.WriteLine("Please enter your Password: ");
            string Password = Console.ReadLine();
        }


        /*
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
    */

        /*
        private static void UpdateRecordLabelName()
        {
            view.DisplayMessage("Enter the RecordLabel_ID to update: ");
            int RecordLabelID = view.GetIntInput();
            view.DisplayMessage("Enter the new RecordLabel name: ");
            string RecordLabelName = view.GetInput();
            int rowsAffected = storageManager.UpdateGenresName();
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }
        */


        private static void UpdateRecordLabelsName()
        {
            view.DisplayMessage("Enter the RecordLabel_ID to update: ");
            int RecordLabelID = view.GetIntInput();
            view.DisplayMessage("Enter the new Record Label name: ");
            string RecordLabelName = view.GetInput();
            int rowsAffected = storageManager.UpdateRecordLabelsName(RecordLabelID, RecordLabelName);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }

        private static void UpdateArtistsName()
        {
            view.DisplayMessage("Enter the Artist_ID to update: ");
            int ArtistID = view.GetIntInput();
            view.DisplayMessage("Enter the new Artist name: ");
            string ArtistName = view.GetInput();
            int rowsAffected = storageManager.UpdateArtistsName(ArtistID, ArtistName);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }

        private static void UpdateVinylsName()
        {
            view.DisplayMessage("Enter the Vinyl_ID to update: ");
            int VinylID = view.GetIntInput();
            view.DisplayMessage("Enter the new Vinyl name: ");
            string VinylName = view.GetInput();
            int rowsAffected = storageManager.UpdateVinylsName(VinylID, VinylName);
            view.DisplayMessage($"Rows affected {rowsAffected}");
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

        private static void UpdateReviewersName()
        {
            view.DisplayMessage("Enter the Review_ID to update: ");
            int ReviewID = view.GetIntInput();
            view.DisplayMessage("Enter the new/same Reviewer Name : ");
            string ReviewerName = view.GetInput();
            int rowsAffected = storageManager.UpdateReviewersName(ReviewID, ReviewerName);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }

        private static void UpdateReviewComments()
        {
            view.DisplayMessage("Enter the Review_ID to update: ");
            int ReviewCommentID = view.GetIntInput();
            view.DisplayMessage("Enter your new Review Comment : ");
            string ShortReview = view.GetInput();
            int rowsAffected = storageManager.UpdateReviewComments(ReviewCommentID, ShortReview);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }


        private static void InsertNewRecordLabels()
        {
            view.DisplayMessage("Enter the new Record Label name: ");
            string RecordLabelName = view.GetInput();
            int RecordLabelID = 0;
            RecordLabel recordLabel = new RecordLabel(RecordLabelName, RecordLabelID);
            int generateID = storageManager.InsertLocationRecordLabels(recordLabel);
            view.DisplayMessage($"new Record Label {recordLabel.RecordLabel_Name} inserted with ID {generateID}");
        }

        private static void InsertNewArtists()
        {
            view.DisplayMessage("Enter the new Artist name: ");
            string ArtistName = view.GetInput();
            int ArtistID = 0;
            int RecordLabelID = 0;
            Artist artist = new Artist(ArtistName, ArtistID, RecordLabelID);
            int generateID = storageManager.InsertLocationArtists(artist);
            view.DisplayMessage($"new Artist {artist.Artist_Name} inserted with ID {generateID}");
        }

        private static void InsertNewGenres()
        {
            view.DisplayMessage("Enter the new Genre name: ");
            string genreName = view.GetInput();
            view.DisplayMessage("Enter a description for the Genre: ");
            string Description = view.GetInput();
            int genreID = 0;
            Genres genre = new Genres(genreName, genreID, Description);
            int generateID = storageManager.InsertLocationGenres(genre);
            view.DisplayMessage($"new Genre {genre.Genre_Name} with Description {genre.Description} inserted with ID {generateID}");
        }

        private static void DeleteRecordLabelByName()
        {
            view.DisplayMessage("Enter the Record Label to delete");
            string recordLabelName = view.GetInput();
            int rowsaffected = storageManager.DeleteRecordLabelByName(recordLabelName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }

        private static void DeleteArtistByName()
        {
            view.DisplayMessage("Enter the Artist to delete");
            string artistName = view.GetInput();
            int rowsaffected = storageManager.DeleteArtistByName(artistName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }

        //delete vinyl name and date of release
        private static void DeleteVinylByName()
        {
            view.DisplayMessage("Enter the Vinyl to delete");
            string vinylName = view.GetInput();
            int rowsaffected = storageManager.DeleteVinylByName(vinylName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }

        private static void DeleteGenresByName()
        {
            view.DisplayMessage("Enter the Genre Name to delete");
            string genreName = view.GetInput();
            int rowsaffected = storageManager.DeleteGenreByName(genreName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }

        //delete out of 5 column
        private static void DeleteReviewByName()
        {
            view.DisplayMessage("Enter the Review Name to delete");
            string reviewName = view.GetInput();
            int rowsaffected = storageManager.DeleteReviewByName(reviewName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }

        //delete short review and review date
        private static void DeleteReviewCommentByName()
        {
            view.DisplayMessage("Enter the Review Comment to delete");
            string shortReview = view.GetInput();
            int rowsaffected = storageManager.DeleteReviewCommentByName(shortReview);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }
    }
}