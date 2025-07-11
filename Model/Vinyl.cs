using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDBApp.Model
{
    public class Vinyl
    {
        public string Vinyl_Name { get; set; }
        public int Vinyl_ID { get; set; }
        public int Artist_ID { get; set; }
        public DateTime Date_Of_Release { get; set; }

        public Vinyl(string vinylName, int vinylID, int artistID, DateTime releaseDate)
        {
            Vinyl_Name = vinylName;
            Vinyl_ID = vinylID;
            Artist_ID = artistID;
            Date_Of_Release = releaseDate;
        }
        public Vinyl(string vinylName, int artistID, DateTime releaseDate)
        {
            Vinyl_Name = vinylName;
            Artist_ID = artistID;
            Date_Of_Release = releaseDate;
        }
    }
}
