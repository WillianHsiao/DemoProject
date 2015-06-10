using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service.Custom
{
    public class CustOrder : IOrderRepository {
        protected TestDataBaseEntities db = new TestDataBaseEntities();
        public IQueryable<Order> CustomOrders(Guid UserPK) {
            var query = from o in db.Orders
                        where o.UserPK == UserPK
                        select o;
            return query;
        }

        public IQueryable<Order> Orders() {
            return null;
        }

        public Order OrderDetail(Guid OrderPK) {
            return null;
        }

        public bool SaveOrder(Order order) {
            var bResult = false;
            try {
                db.Orders.Add(order);
                bResult = db.SaveChanges() > 0;
                return bResult;
            }
            catch {
                return bResult;
            }
        }
    }
}
