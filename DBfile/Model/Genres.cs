using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDBApp.DBfile.Model
{

    public class Genres
    {
        private string Genre_Name { get; set; }
        private int Genre_ID { get; set; }

        public Genres(string inGenre, int inGenre_ID)
        {
            Genre_Name = inGenre;
            Genre_ID = inGenre_ID;
        }
    }
}
