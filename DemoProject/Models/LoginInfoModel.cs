using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Models
{
    public class LoginInfoModel
    {
        [Required]
        public Guid PK {
            get;
            set;
        }
        [Required]
        public Guid UserPK {
            get;
            set;
        }
        [Required]
        [Display(Name="帳號")]
        public string Account {
            get;
            set;
        }
        [Required]
        [Display(Name="密碼")]
        [DataType(DataType.Password)]
        public string Password {
            get;
            set;
        }
        [Required]
        [Display(Name="身分別")]
        public UserType UserType {
            get;
            set;
        }

        //public List<SelectListItem> UserTypeList {
        //    get {
        //        List<SelectListItem> list = new List<SelectListItem>();
        //        list.Add(new SelectListItem { Value = "1", Text = "管理者" });
        //        list.Add(new SelectListItem { Value = "2", Text = "會員" });
        //        return list;
        //    }
        //}
    }

    public enum UserType
    {
        Employee,
        Custom
    }
}