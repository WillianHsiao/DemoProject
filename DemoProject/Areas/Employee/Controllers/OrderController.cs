using DAL.Service;
using DemoProject.Core.Controllers;
using DemoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Areas.Employee.Controllers
{
    public class OrderController : BaseController
    {
        IOrderRepository _IOrder = BFactory.CreateOrder("Employee");
        // GET: Employee/OrderManage
        public ActionResult Index() {
            OrderModel model = new OrderModel();
            var orders = _IOrder.Orders();
            if (orders.Any()) {
                model.OrderList = orders.Select(o => new OrderModel {
                    PK = o.PK,
                    OrderNo = o.OrderNo,
                    Count = o.Count.Value,
                    Price = o.Product.Price.Value,
                    ProductPK = o.ProductPK,
                    ProductName = o.Product.Name,
                    Status = (OrderStatus)o.Status,
                    TotalPrice = o.TotalPrice.Value,
                    UserPK = o.UserPK,
                    UserName = o.UserData.Name
                }).ToList();
            }
            return PartialView("_Index", model);
        }

        public ActionResult OrderDetail(Guid OrderPK) {
            OrderModel model = new OrderModel();
            var order = _IOrder.OrderDetail(OrderPK);
            AutoMapper.Mapper.Map(order, model);
            model.ProductName = order.Product.Name;
            model.UserName = order.UserData.Name;
            model.Price = order.Product.Price.Value;
            return PartialView("_OrderDetail", model);
        }

        public ActionResult ConfirmOrder(Guid OrderPK, OrderStatus Status) {
            bool bResult = false;
            var order = _IOrder.OrderDetail(OrderPK);
            order.Status = (int)Status;
            bResult = _IOrder.SaveOrder(order);
            return RedirectToAction("Index", "Order");
        }
    }
}