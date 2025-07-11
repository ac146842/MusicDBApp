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

        public ReviewComments(string shortReview, int reviewID, int reviewCommentID, DateTime reviewDate)
        {
            Short_Review = shortReview;
            Review_ID = reviewID;
            ReviewComment_ID = reviewCommentID;
            Review_Date = reviewDate;
        }

        public ReviewComments(int reviewID, string shortReview, DateTime reviewDate)
        {
            Review_ID = reviewID;
            Short_Review = shortReview;
            Review_Date = reviewDate;
        }
    }
}
