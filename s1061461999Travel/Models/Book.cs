using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace s1061461999Travel.Models
{
    public partial class Book
    {
        public string ISBN { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }
        public string Company { get; set; }
        public DateTime Publish { get; set; }

        public int Price { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

    }
}