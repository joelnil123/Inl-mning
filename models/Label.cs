using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SSFIEF
{
    public class Lable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public string MovieName { get;set;}
        public string City { get; set;}

        public async Task<Lable> GetEtikettData(MyDbContext _context, int movieId, int MovieStudioId)
        {
            var movie = await _context.Movies.FindAsync(movieId);
            var movieStudio = await _context.MovieStudio.FindAsync(MovieStudioId);

            var lable = new Lable() {Date = DateTime.Now, MovieName = movie.Title, City = movieStudio.City};


            return lable;
        }
        public Lable CreateLabel(Lable lable)
        {
        
            return lable;
        }


    }
}