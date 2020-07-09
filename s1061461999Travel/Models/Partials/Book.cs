using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace s1061461999Travel.Models//.Partials
{
    [MetadataType(typeof(BookMD))]
    public partial class Book
    {
        public class BookMD
        {
            [Display(Name ="書名")]
            [Required(ErrorMessage ="書名必填")]
            public string Name { get; set; }

            [Required(ErrorMessage ="ISBN必填")]
            public string ISBN { get; set; }

            [Remote("CheckPrice","Home",ErrorMessage ="低於成本價")]
            [Required(ErrorMessage ="定價必填")]
            public int Price { get; set; }
        }
    }
}