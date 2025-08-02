using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MusicDBApp.Model;
using MusicDBApp.Repos;

namespace MusicDBApp.View
{
    public class ConsoleView
    {
        private static StorageManager storageManager;

        public ConsoleView(StorageManager manager)
        {
            storageManager = manager;
        }
     

        // Displays Welcome menu and prompts user for input
        public string WelcomeMenu()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Welcome to MusicDB ");
            Console.WriteLine("Please choose one of the following options: ");
            Console.WriteLine("1. Login ");
            Console.WriteLine("2. Register ");

            Console.Write("Enter your option here: ");
            return Console.ReadLine();
        }

        // Displays Login menu and prompts user for credentials
        public void LoginMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please enter your login credentials: ");

                Console.WriteLine("Please enter your Username: ");
                string InputtedUsername = Console.ReadLine();

                Console.WriteLine("Please enter your Password: ");
                string InputtedPassword = Console.ReadLine();

                string Username = storageManager.getUsername(InputtedUsername);
                string Password = storageManager.getPassword(InputtedUsername);
                int roleID = storageManager.getRoleID(InputtedUsername);
                int userID = storageManager.getUserID(InputtedUsername);

                if (!string.IsNullOrEmpty(Username) && InputtedUsername.Equals(Username) && InputtedPassword.Equals(Password))
                {
                    if (roleID == 1)
                    {
                        Program.AdminMenu();
                    }

                    else if (roleID == 2)
                    {
                        Program.UserMenu();
                    }

                    break;
                }
                else
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Please re enter your details");
                    Console.WriteLine("Press enter to re-try");
                    Console.ReadLine();
                }
            }
        }

        //Displays Registration menu and prompts user for new credentials
        public string RegisterMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("User Registration");

                Console.WriteLine("(Max 100 characters)");
                Console.Write("Please enter your desired username: ");
                string newUsername = Console.ReadLine();

                Console.WriteLine("(Max 100 characters)");
                Console.Write("Please enter your desired password: ");
                string newPassword = Console.ReadLine();

                Console.WriteLine("(minimum age 13, max age 100)");
                Console.Write("Please enter your age: ");
                string ageInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newUsername) || string.IsNullOrWhiteSpace(newPassword))
                {
                    Console.WriteLine("Username or Password cannot be empty.");
                    Console.WriteLine("Press Enter to try again");
                    Console.ReadLine();
                    continue;
                }

                if (newUsername.Length > 100 || newPassword.Length > 100)
                {
                    Console.WriteLine("Username/Password must be under 100 characters.");
                    Console.WriteLine("Press Enter to try again");
                    Console.ReadLine();
                    continue;
                }

                if (!int.TryParse(ageInput, out int newAge) || newAge < 13 || newAge > 100)
                {
                    Console.WriteLine("Invalid age. Please enter a number between 13 and 100.");
                    Console.WriteLine("Press Enter to try again");
                    Console.ReadLine();
                    continue;
                }

                if (newUsername.Length > 100 || newPassword.Length > 100)
                {
                    Console.WriteLine("Username/Password must be under 100 characters.");
                    Console.WriteLine("Press Enter to try again");
                    Console.ReadLine();
                    continue;
                }

                if (storageManager.UserExists(newUsername))
                {
                    Console.WriteLine("Username already exists. Please choose another one.");
                    Console.WriteLine("Press Enter to try again");
                    Console.ReadLine();
                    continue;
                }

                int rowsInserted = storageManager.RegisterUser(newUsername, newPassword, roleID: 2, newAge);

                if (rowsInserted > 0)
                {
                    Console.WriteLine("Registration successful!");

                    while (true)
                    {
                        Console.Write("Press Y to go to login or N to exit: ");
                        string choice = Console.ReadLine().ToUpper();

                        if (choice == "Y")
                        {
                            WelcomeMenu();
                            return newUsername;
                        }
                        else if (choice == "N")
                        {
                            storageManager.CloseConnection();
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter Y or N.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Registration failed. Please press Enter to try again...");
                    Console.ReadLine();
                }
            }
        }



        //Displays Admin menu
        public string DisplayAdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to MusicDB (admin)");
            Console.WriteLine("Menu: ");
            Console.WriteLine("Choose an option from 1-7");


            Console.WriteLine("1. tblRecordLabel");
            Console.WriteLine("2. tblArtist");
            Console.WriteLine("3. tblVinyl");
            Console.WriteLine("4. tblGenre");
            Console.WriteLine("5. tblReviews");
            Console.WriteLine("6. tblReviewComments");
            Console.WriteLine("7. Queries");
            Console.WriteLine("8. Exit");

            return Console.ReadLine();
        }

        //Displays User menu
        public string DisplayUserMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to MusicDB (user)");
            Console.WriteLine("Menu: ");
            Console.WriteLine("Choose an option from 1-7");

            Console.WriteLine("1. RecordLabel");
            Console.WriteLine("2. Artist");
            Console.WriteLine("3. Vinyl");
            Console.WriteLine("4. Genre");
            Console.WriteLine("5. Reviews");
            Console.WriteLine("6. Review Comments");
            Console.WriteLine("7. Exit");

            return Console.ReadLine();
        }


        //Displays tblRecordLabel options for Admin
        public void tblRecordLabelA()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to tblRecordlabel");
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: View All records in tblRecordLabel");
                Console.WriteLine("2: Update a Record Labels info by RecordLabel_ID");
                Console.WriteLine("3: Insert a new Record Label");
                Console.WriteLine("4: Delete a Record Label by Name");
                Console.WriteLine("5: Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        List<RecordLabel> recordLabels = storageManager.GetAllRecordLabel();
                        DisplayRecordLabels(recordLabels);
                        break;

                    case "2":
                        Program.UpdateRecordLabelsName();
                        break;

                    case "3":
                        Program.InsertNewRecordLabels();
                        break;

                    case "4":
                        Program.DeleteRecordLabelByName();
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
                Console.WriteLine("Press Enter to return to the menu");
                Console.ReadLine();
                Console.Clear();
            }
        }

        //Displays tblRecordLabel options for User
        public void tblRecordLabelU()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to tblRecordlabel");
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: View all existing Record Labels");
                Console.WriteLine("2: Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        List<RecordLabel> recordLabels = storageManager.GetAllRecordLabel();
                        DisplayRecordLabels(recordLabels);
                        break;

                    case "2":
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
                Console.WriteLine("Press Enter to return to the menu");
                Console.ReadLine();
            }
        }

        //Displays tblArtist options for Admin
        public void tblArtistA()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to tblArtist");
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: View All records in tblArtist");
                Console.WriteLine("2: Update an Artists details by Artist_ID");
                Console.WriteLine("3: Insert a new Artist");
                Console.WriteLine("4: Delete a Artist by Name");
                Console.WriteLine("5: Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        List<Artist> artists = storageManager.GetAllArtist();
                        DisplayArtists(artists);
                        break;

                    case "2":
                        Program.UpdateArtistsName();
                        break;

                    case "3":
                        Program.InsertNewArtists();
                        break;

                    case "4":
                        Program.DeleteArtistByName();
                        break;

                    case "5":
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
                Console.WriteLine("Press Enter to return to the menu");
                Console.ReadLine();
            }
        }

        //Displays tblArtist options for User
        public void tblArtistU()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to tblArtist");
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: View all existing Artists");
                Console.WriteLine("2: Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        List<Artist> artists = storageManager.GetAllArtist();
                        DisplayArtists(artists);
                        break;

                    case "2":
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
                Console.WriteLine("Press Enter to return to the menu");
                Console.ReadLine();
            }
        }

        //Displays tblVinyl options for Admin
        public void tblVinylA()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to tblVinyl");
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: View All records in tblVinyl");
                Console.WriteLine("2: Update an Vinyls details by Vinyl_ID");
                Console.WriteLine("3: Insert a new Vinyl");
                Console.WriteLine("4: Delete a Vinyl by Name");
                Console.WriteLine("5: Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        List<Vinyl> vinyls = storageManager.GetAllVinyl();
                        DisplayVinyls(vinyls);
                        break;

                    case "2":
                        Program.UpdateVinylsName();
                        break;

                    case "3":
                        Program.InsertNewVinyls();
                        break;

                    case "4":
                        Program.DeleteVinylByName();
                        break;

                    case "5":
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
                Console.WriteLine("Press Enter to return to the menu");
                Console.ReadLine();
            }
        }

        //Displays tblVinyl options for User
        public void tblVinylU()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to tblVinyl");
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: View All records in tblVinyl");
                Console.WriteLine("2: Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        List<Vinyl> vinyls = storageManager.GetAllVinyl();
                        DisplayVinyls(vinyls);
                        break;

                    case "2":
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
                Console.WriteLine("Press Enter to return to the menu");
                Console.ReadLine();
            } 
        }

        //Displays tblGenre options for Admin
        public void tblGenreA()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to tblGenre");
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: View All records in tblGenre");
                Console.WriteLine("2: Update an Genre's details by Genre_ID");
                Console.WriteLine("3: Insert a new Genre");
                Console.WriteLine("4: Delete a Genre by Name");
                Console.WriteLine("5: Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        List<Genres> genres = storageManager.GetAllGenres();
                        DisplayGenres(genres);
                        break;

                    case "2":
                        Program.UpdateGenresName();
                        break;

                    case "3":
                        Program.InsertNewGenres();
                        break;

                    case "4":
                        Program.DeleteGenresByName();
                        break;

                    case "5":
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
                Console.WriteLine("Press Enter to return to the menu");
                Console.ReadLine();
            }
        }

        //Displays tblGenre options for User
        public void tblGenreU()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to tblGenre");
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: View All records in tblGenre");
                Console.WriteLine("2: Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        List<Genres> genres = storageManager.GetAllGenres();
                        DisplayGenres(genres);
                        break;

                    case "2":
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
                Console.WriteLine("Press Enter to return to the menu");
                Console.ReadLine();
            }       
        }

        //Displays tblReviews options for Admin
        public void tblReviewsA()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to tblReviews");
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: View All records in tblReviews");
                Console.WriteLine("2: Update an Reviewer name by Review ID");
                Console.WriteLine("3: Insert a new Review");
                Console.WriteLine("4: Delete a Review by ID");
                Console.WriteLine("5: Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        List<Reviews> reviews = storageManager.GetAllReviews();
                        DisplayReviews(reviews);
                        break;

                    case "2":
                        Program.UpdateReviewersName();
                        break;

                    case "3":
                        Program.InsertNewReview();
                        break;

                    case "4":
                        Program.DeleteReviewByID();
                        break;

                    case "5":
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
                Console.WriteLine("Press Enter to return to the menu");
                Console.ReadLine();
            }
        }

        //Displays tblReviews options for User
        public void tblReviewsU()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to tblReviews");
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: View All records in tblReviews");
                Console.WriteLine("2: Leave a rating");
                Console.WriteLine("3: Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        List<Reviews> reviews = storageManager.GetAllReviews();
                        DisplayReviews(reviews);
                        break;

                    case "2":
                        Program.InsertNewReview();
                        break;

                    case "3":
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
                Console.WriteLine("Press Enter to return to the menu");
                Console.ReadLine();
            }
        }

        //Displays tblReviewComments options for Admin
        public void tblReviewCommentsA()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to tblReviewComments");
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: View All records in tblReviewComments");
                Console.WriteLine("2: Update Review Comment by ReviewComment_ID");
                Console.WriteLine("3: Insert a new Review Comment");
                Console.WriteLine("4: Delete a Review Comment by ID");
                Console.WriteLine("5: Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        List<ReviewComments> reviewComments = storageManager.GetAllReviewComments();
                        DisplayReviewComments(reviewComments);
                        break;

                    case "2":
                        Program.UpdateReviewComments();
                        break;

                    case "3":
                        Program.InsertNewReviewComment();
                        break;

                    case "4":
                        Program.DeleteReviewCommentByID();
                        break;

                    case "5":
                        return;
                        break;

                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
                Console.WriteLine("Press Enter to return to the menu");
                Console.ReadLine();
            }
        }

        //Displays tblReviewComments options for User
        public void tblReviewCommentsU()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to tblReviewComments");
                Console.WriteLine("Please choose one of the following options");
                Console.WriteLine("Menu: ");
                Console.WriteLine("1: View all review comments");
                Console.WriteLine("2: Leave a review comment");
                Console.WriteLine("3: Return to main menu");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        List<ReviewComments> reviewComments = storageManager.GetAllReviewComments();
                        DisplayReviewComments(reviewComments);
                        break;

                    case "2":
                        Program.InsertNewReviewComment();
                        break;

                    case "3":
                        return;

                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
                Console.WriteLine("Press Enter to return to the menu");
                Console.ReadLine();
            }
        }

        // Displays Query options
        public void QueryOptions()
        {
                Console.Clear();
                Console.WriteLine("Simple");
                Console.WriteLine("1. qry Genre");
                Console.WriteLine("2. qry RecordLabels");
                Console.WriteLine("3. qry ReviewComments");
                Console.WriteLine("4. qry Reviews");
                Console.WriteLine("5. qry Vinyls");
                Console.WriteLine(" ");

                Console.WriteLine("Advanced: ");
                Console.WriteLine("6. qry Artist Name Like A");
                Console.WriteLine("7. qry Genres After Letter M");
                Console.WriteLine("8. qry Higher Rating Than 3");
                Console.WriteLine("9. qry Reviews Between 2010 & 2020");
                Console.WriteLine("10. qry Short Review Under 30 char");
                Console.WriteLine(" ");

                Console.WriteLine("Complex: ");
                Console.WriteLine("11. qry Artist AvgRating");
                Console.WriteLine("12. qry Counting Artist Vinyl");
                Console.WriteLine("13. qry Earliest Vinyl Dates");
                Console.WriteLine("14. qry Highest Rated Vinyl For Artist");
                Console.WriteLine("15  qry Record Label Artist Count");
                Console.WriteLine(" ");
                Console.WriteLine("16. Return to main menu");
        }

        //Displays list of record labels and their IDs
        public void DisplayRecordLabels(List<RecordLabel> recordLabels)
        {
            foreach (RecordLabel recordLabel in recordLabels)
            {
                Console.WriteLine($"Record Label ID: {recordLabel.RecordLabel_ID}, Record Label: {recordLabel.RecordLabel_Name}");
                Console.WriteLine("-----------------------------");
            }
        }

        // Displays list of artists and their IDs
        public void DisplayArtists(List<Artist> artists)
        {
            foreach (Artist artist in artists)
            {
                Console.WriteLine($"Artist: {artist.Artist_Name}, Artist ID: {artist.Artist_ID}, Record Label ID: {artist.RecordLabel_ID}");
                Console.WriteLine("-----------------------------");
            }
        }

        // Displays list of vinyls and their IDs
        public void DisplayVinyls(List<Vinyl> vinyls)
        {
            foreach (Vinyl vinyl in vinyls)
            {
                Console.WriteLine($"Vinyl ID: {vinyl.Vinyl_ID}, Vinyl Name:{vinyl.Vinyl_Name}, Artist ID: {vinyl.Artist_ID}, Vinyl Date of release: {vinyl.Date_Of_Release:yyyy-MM-dd}");
                Console.WriteLine("-----------------------------");
            }
        }

        // Displays list of genres and their IDs
        public void DisplayGenres(List<Genres> genres)
        {
            foreach (Genres genre in genres)
            {
                Console.WriteLine($"Genre ID: {genre.Genre_ID}, Genre Name: {genre.Genre_Name}");
                Console.WriteLine("-----------------------------");
            }
        }

        // Displays list of reviews and their IDs
        public void DisplayReviews(List<Reviews> reviews)
        {
            foreach (Reviews review in reviews)
            {
                Console.WriteLine($"Review ID: {review.Review_ID}, Reviewer name: {review.Reviewer_Name}, Vinyl ID: {review.Vinyl_ID}, Rating: {review.Out_Of_5}");
                Console.WriteLine("-----------------------------");
            }
        }

        // Displays list of review comments and their IDs
        public void DisplayReviewComments(List<ReviewComments> reviewComments)
        {            
            foreach (ReviewComments reviewComment in reviewComments)
            {
                Console.WriteLine($"Review Comment: {reviewComment.Short_Review}, Review ID: {reviewComment.Review_ID}, Review Comment ID: {reviewComment.ReviewComment_ID}, Review Date: {reviewComment.Review_Date:yyyy-MM-dd}");
                Console.WriteLine("-----------------------------");
            }
        }

        // Displays a message to the console
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        // Gets user input for text
        public string GetInput()
        {
            return Console.ReadLine();
        }

        // Gets user input for numbers
        public int GetIntInput()
        {
            int result;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    return result; // valid number
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number:");
                }
            }
        }
    }
}