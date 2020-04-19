using System;

namespace SSFIEF
{
    public class Lable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int MovieId { get; set; }
        public Movies Movies { get; set; }

        public string City { get; set;}

    }
}