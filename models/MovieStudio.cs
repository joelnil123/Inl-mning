using System.Collections.Generic;

namespace SSFIEF
{
    public class MovieStudio
    {
        public int Id { get ; set;}
        public string FilmStudioName { get; set;}
        public string City { get; set;}

        public ICollection<Movies> Movies { get; set; } = new List<Movies>();
    }
}