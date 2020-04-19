using System;

namespace SSFIEF
{
    public class MovieStudioHandeler
    {
        public int Id { get; set;}

        public int MovieStudioId { get; set;}
        public int MovieId { get; set;}
        public int ReviewId { get; set;}


        // navigations propertys som gör FK
        public MovieStudio MovieStudio { get; set;}
        public Movies Movie { get; set;}
        public Review Review { get; set;}





    }
}