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

        public ReviewComments(string inShort_Review, int inReview_ID, int inReviewComment_ID, DateTime inReview_Date)
        {
            Short_Review = inShort_Review;
            Review_ID = inReview_ID;
            ReviewComment_ID = inReviewComment_ID;
            Review_Date = inReview_Date;
        }
    }
}
