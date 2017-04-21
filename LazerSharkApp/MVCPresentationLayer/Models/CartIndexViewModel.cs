using LazerSharkLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPresentationLayer.Models
{
    public class CartIndexViewModel
    {
        public CartManager Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}