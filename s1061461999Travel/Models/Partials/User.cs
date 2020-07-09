using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace s1061461999Travel.Models//.Partials
{
    [MetadataType(typeof(UserMD))]
    public partial class User
    {
        public class UserMD
        {
            [Remote("IsUserExists", "User", ErrorMessage = "此帳號已經有人使用")]
            [Display(Name = "帳號")]
            [Required(ErrorMessage = "帳號必填")]
            public string Account { get; set; }

            [Display(Name = "密碼")]
            [Required(ErrorMessage = "密碼必填")]
            [StringLength(12, MinimumLength = 4, ErrorMessage = "密碼最少長度為4個字元")]
            public string Password { get; set; }
        }
    }
}