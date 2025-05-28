using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDBApp.Model
{

    public class Genres
    {
        public string Genre_Name { get; set; }
        public int Genre_ID { get; set; }
        //public string Description { get; set; }    
        
        public Genres(string inGenre, int inGenre_ID/*, string inDescription*/)
        {
            Genre_Name = inGenre;
            Genre_ID = inGenre_ID;
            //Description = inDescription;
        }
    } //genre class
}
