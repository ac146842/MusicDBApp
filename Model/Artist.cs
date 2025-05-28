using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDBApp.Model
{
    public class Artist
    {
        public string Artist_Name { get; set; }
        public int Artist_ID { get; set; }
        public int RecordLabel_ID { get; set; }

        public Artist(string inArtist_Name, int inArtist_ID, int inRecordLabel_ID)
        {
            Artist_Name = inArtist_Name;
            Artist_ID = inArtist_ID;
            RecordLabel_ID = inRecordLabel_ID;
        }
    }
}
