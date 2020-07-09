using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace s1061461999Travel.Models.ViewModels
{
    public class ProductCategoryVM
    {
        public List<供應商> Company { get; set; }
        public List<產品類別> Category { get; set; }
        public List<產品資料> Product { get; set; }
    }
}