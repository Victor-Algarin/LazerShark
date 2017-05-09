using LazerSharkDataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPresentationLayer.Models
{
    public class CheckoutModel
    {
        [Key]
        public int checkoutId { get; set; }
        public List<Movie> Movies { get; set; }

        public List<Game> Games { get; set; }
    }
}