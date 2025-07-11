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
                    view.RegisterMenu();
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

                                case "12":
                                    storageManager.CmxQry2();
                                    break;

                                case "13":
                                    storageManager.CmxQry3();
                                    break;

                                case "14":
                                    storageManager.CmxQry4();
                                    break;

                                case "15":
                                    storageManager.CmxQry5();
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


        public static void UpdateGenresName()
        {
            view.DisplayMessage("Enter the Genre_ID to update: ");
            int genreID = view.GetIntInput();
            view.DisplayMessage("Enter the new Genre name: ");
            string genreName = view.GetInput();
            int rowsAffected = storageManager.UpdateGenresName(genreID, genreName);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }

        public static void UpdateReviewersName()
        {
            view.DisplayMessage("Enter the Review_ID to update: ");
            int ReviewID = view.GetIntInput();
            view.DisplayMessage("Enter the new/same Reviewer Name : ");
            string ReviewerName = view.GetInput();
            int rowsAffected = storageManager.UpdateReviewersName(ReviewID, ReviewerName);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }

        public static void UpdateReviewComments()
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
            view.DisplayMessage("Enter the artist's name: ");
            string artistName = view.GetInput();
            view.DisplayMessage("Enter the record label ID: ");
            int recordLabelID = view.GetIntInput();
            Artist artist = new Artist(artistName, recordLabelID);
            int artistID = storageManager.InsertLocationArtists(artist);
            view.DisplayMessage($"New artist '{artist.Artist_Name}' inserted with ID {artistID}");
        }


        public static void InsertNewVinyls()
        {
            view.DisplayMessage("Enter the new Vinyl name: ");
            string vinylName = view.GetInput();
            view.DisplayMessage("Enter the Artist ID: ");
            int artistID = view.GetIntInput();
            view.DisplayMessage("Enter the release date (yyyy-mm-dd): ");
            DateTime releaseDate = DateTime.Parse(view.GetInput());
            Vinyl vinyl = new Vinyl(vinylName, artistID, releaseDate);
            int generatedID = storageManager.InsertLocationVinyls(vinyl);
            view.DisplayMessage($"New vinyl '{vinyl.Vinyl_Name}' inserted with ID {generatedID}");
        }

        public static void InsertNewGenres()
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

        public static void InsertNewReview()
        {
            view.DisplayMessage("Enter the Vinyl ID to review: ");
            int vinylID = view.GetIntInput();
            view.DisplayMessage("Enter your name: ");
            string reviewerName = view.GetInput();

            decimal OutOf5 = 0;
            while (true)
            {
                view.DisplayMessage("Rating out of 5 (Can't be less than 0 or more than 5): ");
                OutOf5 = view.GetIntInput();
                if (OutOf5 > 5 || OutOf5 < 0)
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Invalid rating. Please enter a number between 0 and 5.");
                }
            }
            Reviews review = new Reviews(vinylID, reviewerName, OutOf5);
            int reviewID = storageManager.InsertLocationReviews(review);
            view.DisplayMessage($"New review inserted with ID {reviewID}");
        }

        public static void InsertNewReviewComment()
        {
            view.DisplayMessage("Enter the Review ID you are commenting on: ");
            int reviewID = view.GetIntInput();
            view.DisplayMessage("Enter your short comment: ");
            string shortReivew = view.GetInput();
            view.DisplayMessage("Enter the review date (YYYY-MM-DD): ");
            DateTime reviewDate = DateTime.Parse(view.GetInput());
            ReviewComments reviewComments = new ReviewComments(reviewID, shortReivew, reviewDate);
            int reviewCommentsID = storageManager.InsertLocationReviewComments(reviewComments);
            view.DisplayMessage($"New review comment inserted with ID {reviewCommentsID}");
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


        public static void DeleteVinylByName()
        {
            view.DisplayMessage("Enter the Vinyl to delete");
            string vinylName = view.GetInput();
            int rowsaffected = storageManager.DeleteVinylByName(vinylName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }

        public static void DeleteGenresByName()
        {
            view.DisplayMessage("Enter the Genre Name to delete");
            string genreName = view.GetInput();
            int rowsaffected = storageManager.DeleteGenreByName(genreName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }


        public static void DeleteReviewByName()
        {
            view.DisplayMessage("Enter the Review Name to delete");
            string reviewName = view.GetInput();
            int rowsaffected = storageManager.DeleteReviewByName(reviewName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }

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