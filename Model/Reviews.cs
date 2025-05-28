using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDBApp.Model
{
    public class Reviews
    {
        public string Reviewer_Name { get; set; }
        public int Review_ID { get; set; }
        public int Vinyl_ID { get; set; }
        public decimal Out_Of_5 { get; set; }

        public Reviews(string inReviewer_Name, int inReview_ID, int inVinyl_ID, decimal inOut_Of_5)
        {
            Reviewer_Name = inReviewer_Name;
            Review_ID = inReview_ID;
            Vinyl_ID = inVinyl_ID;
            Out_Of_5 = inOut_Of_5;
        }
    }
}
