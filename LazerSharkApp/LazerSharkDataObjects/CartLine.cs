using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LazerSharkDataObjects
{
    public class CartLine
    {
        public Movie Movie { get; set; }
        public Game Game { get; set; }
        public int Quantity { get; set; }

    }
}
