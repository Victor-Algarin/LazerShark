using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazerSharkDataObjects
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string GenreID { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public string MediumID { get; set; }
        public int QuantityAvailable { get;  set;}
        public int Quantity { get; set; }
        public decimal RentalPrice { get; set; }
        public bool Active { get; set; }
    }
}
