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

        }

        public void tblArtist()
        {

        }

        public void tblVinyl()
        {

        }

        public void tblGenre()
        {

        }

        public void tblReviews()
        {

        }

        public void tblReviewComments()
        {

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