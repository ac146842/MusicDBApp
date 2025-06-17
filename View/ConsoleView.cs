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
            Console.WriteLine("Choose an option from 1-6");

            /*           
            Console.WriteLine("1. View all Records in Genres");
            Console.WriteLine("2. Update a Genres name by Genre_ID");
            Console.WriteLine("3. Insert a new Genre");
            Console.WriteLine("4. Delete a Genre by Gemre_Name");
            */


            Console.WriteLine("1. tblRecordLabel");
            Console.WriteLine("2. tblArtist");
            Console.WriteLine("3. tblVinyl");
            Console.WriteLine("4. tblGenre");
            Console.WriteLine("5. tblReviews");
            Console.WriteLine("6. tblReviewComments");
            Console.WriteLine("7. Queries");

            return Console.ReadLine();
        }


        public void tblRecordLabel()
        {
            Console.WriteLine("Welcome to tblRecordlabel");
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tblRecordLabel");
            Console.WriteLine("2: Update a Record Labels info by RecordLabel_ID");
            Console.WriteLine("3: Insert a new Record Label");
            Console.WriteLine("4: Delete a Record Label by Name");
            Console.WriteLine("5: Return to main menu");
        }

        public void tblArtist()
        {
            Console.WriteLine("Welcome to tblArtist");
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tblArtist");
            Console.WriteLine("2: Update an Artists details by Artist_ID");
            Console.WriteLine("3: Insert a new Artist");
            Console.WriteLine("4: Delete a Artist by Name");
            Console.WriteLine("5: Return to main menu");
        }

        public void tblVinyl()
        {
            Console.WriteLine("Welcome to tblVinyl");
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tblVinyl");
            Console.WriteLine("2: Update an Vinyls details by Vinyl_ID");
            Console.WriteLine("3: Insert a new Vinyl");
            Console.WriteLine("4: Delete a Vinyl by Name");
            Console.WriteLine("5: Return to main menu");
        }

        public void tblGenre()
        {
            Console.WriteLine("Welcome to tblGenre");
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tblGenre");
            Console.WriteLine("2: Update an Genre's details by Genre_ID");
            Console.WriteLine("3: Insert a new Genre");
            Console.WriteLine("4: Delete a Genre by Name");
            Console.WriteLine("5: Return to main menu");
        }

        public void tblReviews()
        {
            Console.WriteLine("Welcome to tblReviews");
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tblReviews");
            Console.WriteLine("2: Update an Reviews details by Review_ID");
            Console.WriteLine("3: Insert a new Review");
            Console.WriteLine("4: Delete a Review by Name");
            Console.WriteLine("5: Return to main menu");
        }

        public void tblReviewComments()
        {
            Console.WriteLine("Welcome to tblReviewComments");
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tblReviewComments");
            Console.WriteLine("2: Update an Employee's details by ReviewComment_ID");
            Console.WriteLine("3: Insert a new Review Comment");
            Console.WriteLine("4: Delete a Review Comment by Name");
            Console.WriteLine("5: Return to main menu");
        }

        public void Queries()
        {
            Console.WriteLine("Simple: ");
            Console.WriteLine("1. ");
            Console.WriteLine("2. ");
            Console.WriteLine("3. ");
            Console.WriteLine("4. ");
            Console.WriteLine("5. ");
            Console.WriteLine(" ");

            Console.WriteLine("Advanced: ");
            Console.WriteLine("1. ");
            Console.WriteLine("2. ");
            Console.WriteLine("3. ");
            Console.WriteLine("4. ");
            Console.WriteLine("5. ");
            Console.WriteLine(" ");

            Console.WriteLine("Complex: ");
            Console.WriteLine("1. ");
            Console.WriteLine("2. ");
            Console.WriteLine("3. ");
            Console.WriteLine("4. ");
            Console.WriteLine("5. ");
        }

        /*
        public void DisplayVinyl(List<Vinyl> vinyl)
        {
            foreach (Vinyl vinyl in vinyl)
            {
                Console.WriteLine($"{vinyl.Artist_ID}, {vinyl.VinylName1}, {vinyl.VinylName2}");
            }
        }
        */

        public void DisplayRecordLabels(List<RecordLabel> recordLabels)
        {
            foreach (RecordLabel recordLabel in recordLabels)
            {
                Console.WriteLine($"{recordLabel.RecordLabel_ID}, {recordLabel.RecordLabel_Name}");
            }
        }

        public void DisplayArtists(List<Artist> artists)
        {
            foreach (Artist artist in artists)
            {
                Console.WriteLine($"{artist.Artist_Name}, {artist.Artist_ID}, {artist.RecordLabel_ID}");
            }
        }

        public void DisplayVinyls(List<Vinyl> vinyls)
        {
            foreach (Vinyl vinyl in vinyls)
            {
                Console.WriteLine($"{vinyl.Vinyl_ID}, {vinyl.Vinyl_Name}, {vinyl.Artist_ID}, {vinyl.Date_Of_Release:yyyy-MM-dd}");
            }
        }

        public void DisplayGenres(List<Genres> genres)
        {
            foreach (Genres genre in genres)
            {
                Console.WriteLine($"{genre.Genre_ID}, {genre.Genre_Name}");
            }
        }

        public void DisplayReviews(List<Reviews> reviews)
        {
            foreach (Reviews review in reviews)
            {
                Console.WriteLine($"{review.Review_ID}, {review.Reviewer_Name}, {review.Vinyl_ID}, {review.Out_Of_5}");
            }
        }

        public void DisplayReviewComments(List<ReviewComments> reviewComments)
        {
            foreach (ReviewComments reviewComment in reviewComments)
            {
                Console.WriteLine($"{reviewComment.Short_Review}, {reviewComment.Review_ID}, {reviewComment.ReviewComment_ID}, {reviewComment.Review_Date:yyyy-MM-dd}");
            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string GetInput()
        {
           return Console.ReadLine();
        }

        public int GetIntInput()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}