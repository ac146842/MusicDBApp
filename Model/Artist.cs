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

        public Artist(string Artist_Name, int Artist_ID, int RecordLabel_ID)
        {
            Artist_Name = Artist_Name;
            Artist_ID = Artist_ID;
            RecordLabel_ID = RecordLabel_ID;
        }

        public Artist(string name, int recordLabelID)
        {
            Artist_Name = name;
            RecordLabel_ID = recordLabelID;
        }
    }
}
