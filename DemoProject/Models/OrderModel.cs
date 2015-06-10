using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoProject.Models
{
   public class OrderModel {

        public OrderModel() {
            OrderList = new List<OrderModel>();
            OrderNo = DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        [Required]
        public Guid PK { get; set; }

        [Required]
        [Display(Name = "訂單編號")]
        public string OrderNo { get; set; }

        [Required]
        [Display(Name="商品名稱")]
        [UIHint("ProductDropDown")]
        public Guid ProductPK { get; set; }

        [Display(Name="商品名稱")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name="數量")]
        public int Count { get; set; }

        [Display(Name="單價")]
        public int Price { get; set; }

        [Display(Name="總價")]
        public int TotalPrice { get; set; }

        [Required]
        public Guid UserPK { get; set; }
        
        [Display(Name="購買人")]
        public string UserName { get; set; }

        [Required]
        [Display(Name="訂單狀態")]
        public OrderStatus Status { get; set; }

        public List<OrderModel> OrderList { get; set; }
    }

    public enum OrderStatus {
        待審 = 0,
        成立,
        取消,
        駁回
    }
}