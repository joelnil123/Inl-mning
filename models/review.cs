namespace SSFIEF
{
    public class Review
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string comment { get; set; }

        public int MovieStudioId { get; set; }
        public MovieStudio movieStudio { get; set; }


        public bool CheckGrade(Review review)
        {
            if (review.Grade < 5 && review.Grade < 1)
                return true;
            else return false;
        }
    }
}
