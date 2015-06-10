using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoProject.Areas.Custom.Models {
    public class UserDataModel {
        [Required]
        public Guid PK { get; set; }
        [Required]
        [Display(Name="姓名")]
        public string Name { get; set; }
        [Display(Name="家用電話")]
        public string H_TEL { get; set; }
        [Display(Name="行動電話")]
        public string M_TEL { get; set; }
        [Display(Name="地址")]
        public string ADDR { get; set; }
        [Display(Name="電子郵件")]
        public string EMAIL { get; set; }
    }
}