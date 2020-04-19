namespace SSFIEF
{
    public class RentedMovies
    {
        public int Id { get; set; }
        public int MovieStudioId { get; set; }
        public int MoviesId { get; set; }

        public MovieStudio MovieStudio { get; set; }
        public Movies Movies { get; set; }

    }
}