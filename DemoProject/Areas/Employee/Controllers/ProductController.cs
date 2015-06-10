using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoProject.Areas.Employee.Models;
using DAL.Service;
using DemoProject.Core.Controllers;

namespace DemoProject.Areas.Employee.Controllers
{
    public class ProductController : BaseController
    {
        IProductRepository _IProduct = BFactory.CreateProduct("Employee");
        public ActionResult Index(Guid? ProductPK) {
            ProductModel model = new ProductModel();
            if (ProductPK.HasValue) { 
                var pro = _IProduct.GetProductDetail(ProductPK.Value);
                model.PK = pro.PK;
                model.Name = pro.Name;
                model.Price = pro.Price.HasValue ? pro.Price.Value : 0;
                model.Description = pro.Description;
            }
            model.ProductList = _IProduct.GetProductList().Select(p=>new ProductModel {
                PK = p.PK,
                Name = p.Name,
                Price = p.Price.HasValue ? p.Price.Value : 0,
                Description = p.Description
            }).ToList();
            return PartialView("_ProductManage", model);
        }

        public ActionResult SaveProduct(FormCollection collection) {
            ProductModel model = new ProductModel();
            var bResult = false;
            if (TryUpdateModel(model) && ModelState.IsValid) {
                DAL.Product _Product = new DAL.Product {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description
                };
                if (model.PK == Guid.Empty) {
                    _Product.PK = Guid.NewGuid();
                    bResult = _IProduct.InsertProduct(_Product);
                }
                else {
                    _Product.PK = model.PK;
                    bResult = _IProduct.UpdateProduct(_Product);
                }
            }
            //ViewBag.Success = bResult;
            return RedirectToAction("Index", "Product");
        }

        public ActionResult DeleteProduct(Guid PK) {
            var bResult =_IProduct.DeleteProduct(PK);
            return RedirectToAction("Index", "Product");
        }
    }
}