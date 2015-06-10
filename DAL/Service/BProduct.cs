using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Service.Model;
using System.Web.Mvc;

namespace DAL.Service
{
    public class BProduct :IProductRepository
    {
        protected TestDataBaseEntities db = new TestDataBaseEntities();

        public Product GetProductDetail(Guid ProductPK) {
            var query = from p in db.Products
                        where p.PK == ProductPK
                        select p;
            return query.SingleOrDefault();
        }

        public List<Product> GetProductList() {
            return db.Products.ToList();
        }

        public IEnumerable<SelectListItem> GetProductDPList() {
            IEnumerable<SelectListItem> result;
            result = GetProductList().Select(p => new SelectListItem {
                Text = p.Name,
                Value = p.PK.ToString()
            });
            return result;
        }

        public bool InsertProduct(Product _Product) {
            var bResult = false;
            try {
                db.Products.Add(_Product);
                bResult = db.SaveChanges() > 0;
                return bResult;
            }
            catch {
                return bResult;
            }
        }

        public bool UpdateProduct(Product _Product) {
            var bResult = false;
            try {
                var query = from p in db.Products
                            where p.PK == _Product.PK
                            select p;
                foreach (var p in query) {
                    p.Name = _Product.Name;
                    p.Price = _Product.Price;
                    p.Description = _Product.Description;
                }
                bResult = db.SaveChanges() > 0;
            }
            catch {
                bResult = false;
            }
            return bResult;
        }

        public bool DeleteProduct(Guid PK) {
            var bResult = false;
            try {
                var query = from p in db.Products
                            where p.PK == PK
                            select p;
                var obj = query.SingleOrDefault();
                db.Products.Remove(obj);
                bResult = db.SaveChanges() > 0;
            }
            catch(Exception){
                bResult = false;
            }
            return bResult;
        }
    }
}
