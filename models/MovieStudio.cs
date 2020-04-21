using System.Collections.Generic;

namespace SSFIEF
{
    public class MovieStudio
    {
        public int Id { get; set; }
        public string FilmStudioName { get; set; }
        public string City { get; set; }



        public ICollection<RentedMovies> RentedMovies { get; set; } = new List<RentedMovies>();
        public void AddRentedMovie(Movies movies)
        {
            if (movies.AmountOfMovies > 0)
            {
                movies.AmountOfMovies--;
            }

            var rentedMovie = new RentedMovies { Movies = movies };

            RentedMovies.Add(rentedMovie);
        }





    }
}