using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SSFIEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // using auotomatiskt alla objekt i detta kommer att stängas.
            using (var db = new MyDbContext())
            {

                // db.Add(new MovieStudio { City = "Borås", FilmStudioName = "Borås Filmstudio" });
                // db.Add(new MovieStudio { City = " Stockholm ", FilmStudioName = "Stockholm Filmstudio" });
                // db.Add(new MovieStudio { City = "Vällingby", FilmStudioName = "Vällingby Filmstudio" });
                // db.Add(new MovieStudio { City = "Kista", FilmStudioName = "Kista Filmstudio" });
                // db.Add(new MovieStudio { City = "Mall Of Scandinavia", FilmStudioName = "Mall Of Scandinaiva Filmstudio" });
                // db.Add(new MovieStudio { City = "Hötorget", FilmStudioName = "Hötorget Filmstudio" });

                // db.SaveChanges();



                // db.Add(new MovieStudioHandeler { MovieStudioId = 1, MovieId = 1, ReviewId = 2 });
                // db.Add(new MovieStudioHandeler { MovieStudioId = 3, MovieId = 1, ReviewId = 1 });
                // db.Add(new MovieStudioHandeler { MovieStudioId = 2, MovieId = 2, ReviewId = 3 });
                // db.Add(new MovieStudioHandeler { MovieStudioId = 3, MovieId = 3, ReviewId = 4 });
                // db.Add(new MovieStudioHandeler { MovieStudioId = 4, MovieId = 4, ReviewId = 5 });
                // db.Add(new MovieStudioHandeler { MovieStudioId = 5, MovieId = 5, ReviewId = 6 });

                // db.Add ( new RentedMovies {MoviesId = 2 , MovieStudioId =2 });
                // db.SaveChanges();

               // db.Add(new Movies { Title = "8 mile", Genre = "Horror", AmountOfMovies = 2, IsRented = false, });
                //    db.Add(new Movies { Title = "Pulp Fiction", Genre = "Thriller", AmountOfMovies = 1, IsRented = false });
                // db.Add(new Movies { Title = "Stright Outa Compton", Genre = "Sci-fi", AmountOfMovies = 6, IsRented = false });
                //  db.Add(new Movies { Title = "Torkel i Knipa", Genre = "Drama", AmountOfMovies = 14, IsRented = false });
                // db.Add(new Movies { Title = "Deadpool", Genre = "Action", AmountOfMovies = 5, IsRented = false });
               // db.Add(new Movies { Title = "Training Day", Genre = "Comedy", AmountOfMovies = 11, IsRented = false });

                //  var movie = db.Movies.OrderByDescending(m => m.Id)
                //                           .First();

                //   var MovieStudio = db.Movies.OrderByDescending(m => m.Id)
                //                           .First();
                //   movie.Reviews.Add(new Review { Grade = 1, comment = "sämst ",MovieStudioId = MovieStudio.Id});
                                        
                //  db.SaveChanges();


            }



            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
