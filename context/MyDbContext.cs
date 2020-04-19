using Microsoft.EntityFrameworkCore;

namespace SSFIEF
{
    public class MyDbContext : DbContext
    {
        public DbSet<Movies> Movies { get; set; }
        public DbSet<MovieStudio> MovieStudio { get; set; }
        public DbSet<MovieStudioHandeler> MovieStudioHandeler { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<RentedMovies> RentedMovies { get; set; }
        public DbSet<Lable> lables { get; set;}

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public MyDbContext()
        {
        }

        // håller koll på villke db du vill connecta till din lokala?
        // eller om du ha rnågon på internet skulle du ha connection stringen här
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Databas.db");

        }

    }






}