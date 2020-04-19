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
            
            using (var db = new MyDbContext())
            {
                db.Add( new Movies {Title = "Need" , Genre = "Action", AmountOfMovies = 5, IsRented = false} );
                // db.Add( new Movies {Title = "Torkel i Knipa" , Genre = "Drama", AmountOfMovies = 14, IsRented = true} );
                // db.Add( new Movies {Title = "Training Day" , Genre = "Comedy", AmountOfMovies = 11, IsRented = false} );
                // db.Add( new Movies {Title = "Stright Outa Compton" , Genre = "Sci-fi", AmountOfMovies = 6, IsRented = true} );
                // db.Add( new Movies {Title = "8 mile" , Genre = "Horror", AmountOfMovies = 2, IsRented = false} );
                // db.Add( new Movies {Title = "Pulp Fiction" , Genre = "Thriller", AmountOfMovies = 1, IsRented = true} );

                // db.Add( new MovieStudio {City = "Borås" , FilmStudioName = "Borås Filmstudio"} );
                // db.Add( new MovieStudio {City = " Stockholm " , FilmStudioName = "Stockholm Filmstudio"} );
                // db.Add( new MovieStudio {City = "Vällingby" , FilmStudioName = "Vällingby Filmstudio"} );
                // db.Add( new MovieStudio {City = "Kista" , FilmStudioName = "Kista Filmstudio"} );
                // db.Add( new MovieStudio {City = "Mall Of Scandinavia" , FilmStudioName = "Mall Of Scandinaiva Filmstudio"} );
                // db.Add( new MovieStudio {City = "Hötorget" , FilmStudioName = "Hötorget Filmstudio"} );

                


                var movie = db.Movies .OrderBy(m => m.Id)
                                        .First();
                movie.Reviews.Add( new Review { Grade = 3 ,comment = "Hejsan" });                        
                db.SaveChanges();
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
