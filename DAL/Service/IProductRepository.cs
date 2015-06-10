using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DAL.Service
{
    public interface IProductRepository
    {
        Product GetProductDetail(Guid ProductPK);
        List<Product> GetProductList();
        bool InsertProduct(Product _Product);
        bool UpdateProduct(Product _Product);
        bool DeleteProduct(Guid PK);
        IEnumerable<SelectListItem> GetProductDPList();
    }
}
