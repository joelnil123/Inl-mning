using System.Collections.Generic;

namespace SSFIEF
{
    public class Movies
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int AmountOfMovies { get; set; }
        //behövs inte
        public bool IsRented { get ; set;} = false;

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}