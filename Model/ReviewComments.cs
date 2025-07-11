using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDBApp.Model
{
    public class ReviewComments
    {
        public string Short_Review { get; set; }
        public int Review_ID { get; set; }
        public int ReviewComment_ID { get; set; }
        public DateTime Review_Date { get; set; }

        public ReviewComments(string Short_Review, int Review_ID, int ReviewComment_ID, DateTime Review_Date)
        {
            Short_Review = Short_Review;
            Review_ID = Review_ID;
            ReviewComment_ID = ReviewComment_ID;
            Review_Date = Review_Date;
        }

        public ReviewComments(string shortreview, int reviewID, int commentID)
        {
            Short_Review = shortreview;
            Review_ID = reviewID;
            ReviewComment_ID = commentID;
        }
    }
}
