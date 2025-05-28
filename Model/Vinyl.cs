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

        public Vinyl(string inVinyl_Name, int inVinyl_ID, int inArtist_ID, DateTime inDate_Of_Release)
        {
            Vinyl_Name = inVinyl_Name;
            Vinyl_ID = inVinyl_ID;
            Artist_ID = inArtist_ID;
            Date_Of_Release = inDate_Of_Release;
        }        
    }
}
