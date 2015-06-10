using DAL;
using DAL.Service;
using DemoProject.Models;
using DemoProject.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Areas.Custom.Controllers
{
    public class OrderController : BaseController
    {
        IOrderRepository _IOrder = BFactory.CreateOrder("Custom");
        IProductRepository _IProduct = new BProduct();
        // GET: Custom/OrderManage
        public ActionResult Index() {
            OrderModel model = new OrderModel();
            var orders = _IOrder.CustomOrders(LoginInfo.UserPK);
            if (orders.Any()) {
                model.OrderList = orders.Select(o => new OrderModel {
                    PK = o.PK,
                    OrderNo = o.OrderNo,
                    Count = o.Count.Value,
                    Price = o.Product.Price.Value,
                    ProductPK = o.ProductPK,
                    ProductName = o.Product.Name,
                    Status = (OrderStatus)o.Status,
                    TotalPrice = o.Count.Value * o.Product.Price.Value,
                    UserPK = o.UserPK
                }).ToList();
            }
            return PartialView("_Index", model);
        }

        [HttpPost]
        public ActionResult LoadEmptyOrder()
        {
            OrderModel model = new OrderModel();
            return PartialView("_OrderDetail", model);
        }

        [HttpGet]
        public ActionResult GetPrice(Guid ProductPK) {
            var price = _IProduct.GetProductDetail(ProductPK).Price;
            return Content(price.ToString());
        }

        public ActionResult SaveOrder(FormCollection collection) {
            OrderModel model = new OrderModel(); 
            var bResult = false;
            if (TryUpdateModel(model) && ModelState.IsValid) {
                Order order = new Order {
                    PK = Guid.NewGuid(),
                    ProductPK = model.ProductPK,
                    TotalPrice = model.TotalPrice,
                    Count = model.Count,
                    UserPK = LoginInfo.UserPK,
                    Status = (int)OrderStatus.待審,
                    OrderNo = model.OrderNo
                };
                bResult = _IOrder.SaveOrder(order);
            }
            //ViewBag.Success = bResult;
            return RedirectToAction("Index", "Order");
        }
    }
}