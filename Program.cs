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

        // Main method and displays Login/Register menu
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
            string tblchoice;   

            while (true)
            {
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
                        view.WelcomeMenu();
                        break;
                }
            }
        }

        // Takes user input for admin menu and query options
        public static void AdminMenu()       
        {
            Console.Clear();
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

                        Console.Write("Please enter one of the following options: ");
                        string queryChoice = Console.ReadLine();
                        while (true)
                        {
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
                            Console.WriteLine("Press Enter to return to the main menu");
                            Console.ReadLine();
                            break;
                        }
                    break;

                    case "8":
                        storageManager.CloseConnection();
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // Takes user input for user menu
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
                    case "7":
                        storageManager.CloseConnection();
                        Environment.Exit(0);
                        break;
                }
            }
        }

        // Takes user input to update record label name based off ID 
        public static void UpdateRecordLabelsName()
        {
            int RecordLabelID;
            while (true)
            {
                view.DisplayMessage("Enter the RecordLabel_ID to update: ");
                RecordLabelID = view.GetIntInput();

                if (storageManager.RecordLabelExists(RecordLabelID))
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Record Label ID does not exist or was not found, please try again.");
                }
            }

            string RecordLabelName;
            while (true)
            {
                view.DisplayMessage("Enter the new Record Label name: ");
                RecordLabelName = view.GetInput();

                if (!string.IsNullOrWhiteSpace(RecordLabelName) && RecordLabelName.Length <= 100)
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Record Label Name cannot be empty or more than 100 characters, please try again.");
                }
            };
            int rowsAffected = storageManager.UpdateRecordLabelsName(RecordLabelID, RecordLabelName);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }

        // Takes user input to update Artist name based off ID 
        public static void UpdateArtistsName()
        {
            int ArtistID;
            while (true)
            {
                view.DisplayMessage("Enter the Artist_ID to update: ");
                ArtistID = view.GetIntInput();

                if (storageManager.ArtistExists(ArtistID))
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Artist ID does not exist or was not found, please try again.");
                }
            }

            string ArtistName;
            while (true)
            {
                view.DisplayMessage("Enter the new Artist name: ");
                ArtistName = view.GetInput();

                if (!string.IsNullOrWhiteSpace(ArtistName) && ArtistName.Length <= 100)
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Artist Name cannot be empty or more than 100 characters, please try again.");
                }
            }
            int rowsAffected = storageManager.UpdateArtistsName(ArtistID, ArtistName);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }

        // Takes user input to update Vinyl name based off ID 
        public static void UpdateVinylsName()
        {
            int VinylID;
            while (true)
            {
                view.DisplayMessage("Enter the Vinyl_ID to update: ");
                VinylID = view.GetIntInput();

                if (storageManager.VinylExists(VinylID))
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Vinyl ID does not exist or was not found, please try again.");
                }
            }

            string VinylName;
            while (true)
            {
                view.DisplayMessage("Enter the new Vinyl name: ");
                VinylName = view.GetInput();

                if (!string.IsNullOrWhiteSpace(VinylName) && VinylName.Length <= 100)
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Vinyl Name cannot be empty or more than 100 characters, please try again.");
                }
            }
            int rowsAffected = storageManager.UpdateVinylsName(VinylID, VinylName);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }

        // Takes user input to update Genre name based off ID 
        public static void UpdateGenresName()
        {
            int genreID;
            while (true)
            {
                view.DisplayMessage("Enter the Genre_ID to update: ");
                genreID = view.GetIntInput();

                if (storageManager.GenreExists(genreID))
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Genre ID does not exist or was not found, please try again.");
                }
            }

            string genreName;
            while (true)
            {
                view.DisplayMessage("Enter the new Genre name: ");
                genreName = view.GetInput();

                if (!string.IsNullOrWhiteSpace(genreName) && genreName.Length <= 100)
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Genre Name cannot be empty or more than 100 characters, please try again.");
                }
            }
            int rowsAffected = storageManager.UpdateGenresName(genreID, genreName);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }

        // Takes user input to update Review name based off ID 
        public static void UpdateReviewersName()
        {
            int ReviewID;
            while (true)
            {
                view.DisplayMessage("Enter the Review_ID to update: ");
                ReviewID = view.GetIntInput();

                if (storageManager.ReviewIDExists(ReviewID))
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Review ID does not exist or was not found, please try again.");
                }
            }

            string ReviewerName;
            while (true)
            {
                view.DisplayMessage("Enter the new/same Reviewer Name : ");
                ReviewerName = view.GetInput();

                if (!string.IsNullOrWhiteSpace(ReviewerName) && ReviewerName.Length <= 100)
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Reviewer Name cannot be empty or more than 100 characters, please try again.");
                }
            }
            int rowsAffected = storageManager.UpdateReviewersName(ReviewID, ReviewerName);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }

        // Takes user input to update Review Comment name based off ID 
        public static void UpdateReviewComments()
        {
            int ReviewCommentID;
            while (true)
            {
                view.DisplayMessage("Enter the Review_ID to update: ");
                ReviewCommentID = view.GetIntInput();

                if (storageManager.ReviewCommentIDExists(ReviewCommentID))
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Review Comment ID does not exist or was not found, please try again.");
                }
            }

            string ShortReview;
            while (true)
            {
                view.DisplayMessage("Enter your new Review Comment : ");
                ShortReview = view.GetInput();

                if (!string.IsNullOrWhiteSpace(ShortReview) && ShortReview.Length <= 255)
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Review Comment cannot be empty or more than 255 characters, please try again.");
                }
            }
            int rowsAffected = storageManager.UpdateReviewComments(ReviewCommentID, ShortReview);
            view.DisplayMessage($"Rows affected {rowsAffected}");
        }

        // Takes user input to insert a new record label name
        public static void InsertNewRecordLabels()
        {
            string RecordLabelName;
            while (true)
            {
                view.DisplayMessage("Enter the new Record Label name: ");
                RecordLabelName = view.GetInput();

                if (!string.IsNullOrWhiteSpace(RecordLabelName) && RecordLabelName.Length <= 100)
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Record Label cannot be empty or more than 100 characters, please try again.");
                }
            }
            int RecordLabelID = 0;
            RecordLabel recordLabel = new RecordLabel(RecordLabelName, RecordLabelID);
            int generateID = storageManager.InsertLocationRecordLabels(recordLabel);
            view.DisplayMessage($"new Record Label {recordLabel.RecordLabel_Name} inserted with ID {generateID}");
        }

        // Takes user input to insert a new artist name
        public static void InsertNewArtists()
        {
            string artistName;
            while (true)
            {
                view.DisplayMessage("Enter the artist's name: ");
                artistName = view.GetInput();

                if (!string.IsNullOrWhiteSpace(artistName) && artistName.Length <= 100)
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Artist cannot be empty or more than 100 characters, please try again.");
                }
            }

            int recordLabelID;
            while (true)
            {
                view.DisplayMessage("Enter the record label ID: ");
                recordLabelID = view.GetIntInput();

                if (storageManager.RecordLabelExists(recordLabelID))
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Reecord Label ID does not exist or was not found, please try again.");
                }
            }

            Artist artist = new Artist(artistName, recordLabelID);
            int artistID = storageManager.InsertLocationArtists(artist);
            view.DisplayMessage($"New artist '{artist.Artist_Name}' inserted with ID {artistID}");
        }

        // Takes user input to insert a new vinyl name
        public static void InsertNewVinyls()
        {
            string vinylName;
            while (true)
            {
                view.DisplayMessage("Enter the new Vinyl name: ");
                vinylName = view.GetInput();

                if (!string.IsNullOrWhiteSpace(vinylName) && vinylName.Length <= 100)
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Vinyl cannot be empty or more than 100 characters, please try again.");
                }
            }

            int artistID;
            while (true)
            {
                view.DisplayMessage("Enter the Artist ID: ");
                artistID = view.GetIntInput();

                if (storageManager.ArtistExists(artistID))
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Artist ID does not exist or was not found, please try again.");
                }
            }
            view.DisplayMessage("Enter the release date (yyyy-mm-dd): ");
            DateTime releaseDate = DateTime.Parse(view.GetInput());
            Vinyl vinyl = new Vinyl(vinylName, artistID, releaseDate);
            int generatedID = storageManager.InsertLocationVinyls(vinyl);
            view.DisplayMessage($"New vinyl '{vinyl.Vinyl_Name}' inserted with ID {generatedID}");
        }

        // Takes user input to insert a new genre name
        public static void InsertNewGenres()
        {
            string genreName;
            while (true)
            {
                view.DisplayMessage("Enter the new Genre name: ");
                genreName = view.GetInput();

                if (!string.IsNullOrWhiteSpace(genreName) && genreName.Length <= 100)
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Genre cannot be empty or more than 100 characters, please try again.");
                }
            }

            string Description;
            while (true)
            {
                view.DisplayMessage("Enter a description for the Genre: ");
                Description = view.GetInput();

                if (!string.IsNullOrWhiteSpace(Description) && Description.Length <= 255)
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Description cannot be empty or more than 255 characters, please try again.");
                }
            }


            int genreID = 0;
            Genres genre = new Genres(genreName, genreID, Description);
            int generateID = storageManager.InsertLocationGenres(genre);
            view.DisplayMessage($"new Genre {genre.Genre_Name} with Description {genre.Description} inserted with ID {generateID}");
        }

        // Takes user input to insert a new review name
        public static void InsertNewReview()
        {
            int vinylID;
            while (true)
            {
                view.DisplayMessage("Enter the Vinyl ID to review: ");
                vinylID = view.GetIntInput();

                if (storageManager.VinylExists(vinylID))
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Vinyl ID does not exist or was not found, please try again.");
                }
            }

            string reviewerName = "";
            while (true)
            {
                view.DisplayMessage("Enter your name: ");
                reviewerName = view.GetInput();
                if (string.IsNullOrWhiteSpace(reviewerName))
                {
                    reviewerName = "Anonymous";
                    break;
                }
                else
                {
                    break;
                }
            }

            decimal OutOf5 = 0;
            while (true)
            {
                view.DisplayMessage("Rating out of 5 (Can't be less than 0 or more than 5): ");
                OutOf5 = decimal.Parse(view.GetInput());
                if (OutOf5 >= 0 && OutOf5 <= 5)
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
            view.DisplayMessage($"New review by {reviewerName} inserted with ID {reviewID}");
        }

        // Takes user input to insert a new review comment name
        public static void InsertNewReviewComment()
        {
            int reviewID;
            while (true)
            {
                view.DisplayMessage("Enter the Review ID you are commenting on: ");
                reviewID = view.GetIntInput();

                if (storageManager.VinylExists(reviewID))
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Vinyl ID does not exist or was not found, please try again.");
                }
            }

            string shortReivew;
            while (true)
            {
                view.DisplayMessage("Enter your short comment: ");
                shortReivew = view.GetInput();

                if (!string.IsNullOrWhiteSpace(shortReivew) && shortReivew.Length <= 255)
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Short review cannot be empty or more than 255 characters, please try again.");
                }
            }
            view.DisplayMessage("Enter the review date (YYYY-MM-DD): ");
            DateTime reviewDate = DateTime.Parse(view.GetInput());
            ReviewComments reviewComments = new ReviewComments(reviewID, shortReivew, reviewDate);
            int reviewCommentsID = storageManager.InsertLocationReviewComments(reviewComments);
            view.DisplayMessage($"New review comment inserted with ID {reviewCommentsID}");
        }

        // Takes user input to delete a record label by name
        public static void DeleteRecordLabelByName()
        {
            view.DisplayMessage("Enter the Record Label Name to delete");
            string recordLabelName = view.GetInput();
            int rowsaffected = storageManager.DeleteRecordLabelByName(recordLabelName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }

        // Takes user input to delete a artist by name
        public static void DeleteArtistByName()
        {
            view.DisplayMessage("Enter the Artist to delete");
            string artistName = view.GetInput();
            int rowsaffected = storageManager.DeleteArtistByName(artistName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }

        // Takes user input to delete a vinyl by name
        public static void DeleteVinylByName()
        {
            view.DisplayMessage("Enter the Vinyl to delete");
            string vinylName = view.GetInput();
            int rowsaffected = storageManager.DeleteVinylByName(vinylName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }

        // Takes user input to delete a genre by name
        public static void DeleteGenresByName()
        {
            view.DisplayMessage("Enter the Genre Name to delete");
            string genreName = view.GetInput();
            int rowsaffected = storageManager.DeleteGenreByName(genreName);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }

        // Takes user input to delete a review by ID
        public static void DeleteReviewByID()
        {
            view.DisplayMessage("Enter the Review ID to delete: ");
            int reviewID = view.GetIntInput();
            int rowsaffected = storageManager.DeleteReviewByName(reviewID);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }

        // Takes user input to delete a review comment by ID
        public static void DeleteReviewCommentByID()
        {
            view.DisplayMessage("Enter the Review Comment ID to delete");
            int ReviewCommentID = view.GetIntInput();

            while (true)
            {
                if (storageManager.ReviewIDExists(ReviewCommentID))
                {
                    break;
                }
                else
                {
                    view.DisplayMessage("Review ID either does not exist or wasn't found, please try again.");
                    DeleteReviewCommentByID();
                }
            }

            int rowsaffected = storageManager.DeleteReviewCommentByID(ReviewCommentID);
            view.DisplayMessage($"Rows affected: {rowsaffected}");
        }       
    }
}