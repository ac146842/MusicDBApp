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

            return Console.ReadLine();
        }


        public void tblRecordLabel()
        {
            Console.WriteLine("Welcome to tblRecordlabel");
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tblRecordLabel");
            Console.WriteLine("2: Update a Record Labels info by RecordLabel_ID");
        }

        public void tblArtist()
        {
            Console.WriteLine("Welcome to tblArtist");
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tblArtist");
            Console.WriteLine("2: Update an Artists details by Artist_ID");
        }

        public void tblVinyl()
        {
            Console.WriteLine("Welcome to tblVinyl");
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tblVinyl");
            Console.WriteLine("2: Update an Vinyls details by Vinyl_ID");
        }

        public void tblGenre()
        {
            Console.WriteLine("Welcome to tblGenre");
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tblGenre");
            Console.WriteLine("2: Update an Genre's details by Genre_ID");
        }

        public void tblReviews()
        {
            Console.WriteLine("Welcome to tblReviews");
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tblReviews");
            Console.WriteLine("2: Update an Reviews details by Review_ID");
        }

        public void tblReviewComments()
        {
            Console.WriteLine("Welcome to tblReviewComments");
            Console.WriteLine("Please choose one of the following options");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1: View All records in tblReviewComments");
            Console.WriteLine("2: Update an Employee's details by ReviewComment_ID");
        }


        public void DisplayVinyl(List<Vinyl> vinyl)
        {
            foreach (Vinyl vinyl in vinyl)
            {
                Console.WriteLine($"{vinyl.Artist_ID}, {vinyl.VinylName1}, {vinyl.VinylName2}");
            }
        }


        public void DisplayGenres(List<Genres> genres)
        {
            foreach (Genres genre in genres)
            {
                Console.WriteLine($"{genre.Genre_ID}, {genre.Genre_Name}");
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