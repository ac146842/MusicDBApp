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

        string tblchoice;
        string choice;

        static void Main(string[] args)
        {
            //school connection
            //string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ac146842\\OneDrive - Avondale College\\12TPI\\DBfile\\sqlcode\\MusicDB.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=True";
            //home
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MusicDB1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storageManager = new StorageManager(connectionString);
            view = new ConsoleView(storageManager);


            // string tblchoice = view.TblDisplayMenu();
            // string choice = view.DisplayMenu();
            bool Notvalid = true;
            string tblchoice;

            
            string choice = view.WelcomeMenu();

            switch (choice)
            {
                case "1":
                    view.LoginMenu();
                    break;

                case "2":
                    Console.WriteLine("register");
                    break;

                default:
                    Console.WriteLine("Please try again.");
                    break;
            }
        }




        public static void AdminMenu()
       
        {  
            while (true)
            {
                
                string choice = view.DisplayAdminMenu();
                switch (choice)
                {
                    case "1":
                        view.tblRecordLabelA();

                        break;
                    case "2":
                        view.tblArtistA();

                        break;
                    case "3":
                        view.tblVinylA();

                        break;
                    case "4":
                        view.tblGenreA();

                        break;
                    case "5":
                        view.tblReviewsA();
                     
                        break;
                    case "6":
                        view.tblReviewCommentsA();
                        
                        break;

                    case "7":
                        view.QueryOptions();

                        while (true)
                        {
                            Console.Write("Please enter one of the following options: ");
                            string queryChoice = Console.ReadLine();

                            switch (queryChoice)
                            {
                                case "1":
                                    storageManager.SmpQry1();
                                    break;

                                case "2":
                                    storageManager.SmpQry2();
                                    break;

                                case "3":
                                    storageManager.SmpQry3();
                                    break;

                                case "4":
                                    storageManager.SmpQry4();
                                    break;

                                case "5":
                                    storageManager.SmpQry5();
                                    break;

                                case "6":
                                    storageManager.AdvQry1();
                                    break;

                                case "7":
                                    storageManager.AdvQry2();
                                    break;

                                case "8":
                                    storageManager.AdvQry3();
                                    break;

                                case "9":
                                    storageManager.AdvQry4();
                                    break;

                                case "10":
                                    storageManager.AdvQry5();
                                    break;

                                case "11":
                                    storageManager.CmxQry1();
                                    break;

                                default:
                                    Console.WriteLine("Invalid query option. Try again.");
                                    break;
                            }
                        }

                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public static void UserMenu()
        {
            while (true)
            {
                string choice = view.DisplayUserMenu();

                switch (choice)
                {
                    case "1":
                        view.tblRecordLabelU();
                        break;
                    case "2":
                        view.tblArtistU();
                        break;
                    case "3":
                        view.tblVinylU();
                        break;
                    case "4":
                        view.tblGenreU();
                        break;
                    case "5":
                        view.tblReviewsU();
                        break;
                    case "6":
                        view.tblReviewCommentsU();
                        break;                    
                }
            }
        }



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

        default:
            Console.WriteLine("Invalid option please try again.");
            Notvalid = false;
            break;
    }
}
while (true);

storageManager.CloseConnection();
}
*/


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


        public static void UpdateRecordLabelsName()
        {
            view.DisplayMessage("Enter the RecordLabel_ID to update: ");
            int RecordLabelID = view.GetIntInput();
            view.DisplayMessage("Enter the new Record Label name: ");
            string RecordLabelName = view.GetInput();
            int rowsAffected = storageManager.UpdateRecordLabelsName(RecordLabelID, RecordLabelName);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }

        public static void UpdateArtistsName()
        {
            view.DisplayMessage("Enter the Artist_ID to update: ");
            int ArtistID = view.GetIntInput();
            view.DisplayMessage("Enter the new Artist name: ");
            string ArtistName = view.GetInput();
            int rowsAffected = storageManager.UpdateArtistsName(ArtistID, ArtistName);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }

        public static void UpdateVinylsName()
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


        public static void InsertNewRecordLabels()
        {
            view.DisplayMessage("Enter the new Record Label name: ");
            string RecordLabelName = view.GetInput();
            int RecordLabelID = 0;
            RecordLabel recordLabel = new RecordLabel(RecordLabelName, RecordLabelID);
            int generateID = storageManager.InsertLocationRecordLabels(recordLabel);
            view.DisplayMessage($"new Record Label {recordLabel.RecordLabel_Name} inserted with ID {generateID}");
        }

        public static void InsertNewArtists()
        {
            view.DisplayMessage("Enter the new Artist name: ");
            string ArtistName = view.GetInput();
            int ArtistID = 0;
            int RecordLabelID = 0;
            Artist artist = new Artist(ArtistName, ArtistID, RecordLabelID);
            int generateID = storageManager.InsertLocationArtists(artist);
            view.DisplayMessage($"new Artist {artist.Artist_Name} inserted with ID {generateID}");
        }

        /*
        public static void InsertNewVinyls()
        {
            view.DisplayMessage("Enter the new Vinyl name: ");
            string vinylName = view.GetInput();
            int VinylID = 0;
            int RecordLabelID = 0;
            Vinyl vinyl = new Vinyl(VinylName, ArtistID, RecordLabelID);
            int generateID = storageManager.InsertLocationVinyls(vinyl);
            view.DisplayMessage($"new Artist {vinyl.Vinyl_Name} inserted with ID {generateID}");
        }
        */

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

        public static void DeleteRecordLabelByName()
        {
            view.DisplayMessage("Enter the Record Label to delete");
            string recordLabelName = view.GetInput();
            int rowsaffected = storageManager.DeleteRecordLabelByName(recordLabelName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }

        public static void DeleteArtistByName()
        {
            view.DisplayMessage("Enter the Artist to delete");
            string artistName = view.GetInput();
            int rowsaffected = storageManager.DeleteArtistByName(artistName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }


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


        private static void DeleteReviewByName()
        {
            view.DisplayMessage("Enter the Review Name to delete");
            string reviewName = view.GetInput();
            int rowsaffected = storageManager.DeleteReviewByName(reviewName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }

        //delete short review and review date
        /*
        private static void DeleteReviewCommentByID()
        {
            view.DisplayMessage("Enter the Review Comment to delete");
            int ReviewCommentID = view.GetInput();
            int rowsaffected = storageManager.DeleteReviewCommentByID(ReviewCommentID);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }
        */
    }
}