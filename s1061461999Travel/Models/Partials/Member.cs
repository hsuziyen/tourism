using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace s1061461999Travel.Models//.Partials
{
    [MetadataType(typeof(MemberMD))]
    public partial class Member
    {
        public class MemberMD
        {
            [Remote("IsUserExists","Home",ErrorMessage ="此帳號已經有人使用")]
            [Display(Name="帳號")]
            [Required(ErrorMessage ="帳號必填")]
            public string Account { get; set; }


            [System.ComponentModel.DataAnnotations.Compare("Password2",ErrorMessage ="兩次密碼不同")]
            [Display(Name = "密碼")]
            [Required(ErrorMessage = "密碼必填")]
            [StringLength(12,MinimumLength =4,ErrorMessage ="密碼最少長度為4個字元")]
            public string Password { get; set; }

            [Display(Name ="確認密碼")]
            public string Password2 { get; set; }
                       
            [Required(ErrorMessage ="Email必填")]
            [EmailAddress(ErrorMessage ="請填入正確的Email格式")]
            public string Email { get; set; }
                       
            [Required(ErrorMessage ="手機欄位必填")]
            [RegularExpression("^\\(?\\d{2}\\)?[\\s\\-]?\\d{4}\\-?\\d{4}$", 
                ErrorMessage ="請填入正確的手機號碼")]
            public string Phone { get; set; }

            [Display(Name ="生日")]
            public DateTime BirthDay { get; set; }

        }
    }
}