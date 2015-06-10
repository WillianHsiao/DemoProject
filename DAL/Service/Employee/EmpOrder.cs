using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service.Employee
{
    public class EmpOrder : IOrderRepository {
        protected TestDataBaseEntities db = new TestDataBaseEntities();
        public IQueryable<Order> CustomOrders(Guid UserPK) {
            return null;
        }
        public IQueryable<Order> Orders() {
            var query = from o in db.Orders
                        select o;
            return query;
        }
        public Order OrderDetail(Guid OrderPK) {
            var query = from o in db.Orders
                        where o.PK == OrderPK
                        select o;
            return query.SingleOrDefault();
        }
        public bool SaveOrder(Order order) {
            var bResult = false;
            try {
                var query = (from o in db.Orders
                            where o.PK == order.PK
                             select o).Single();
                query.Status = order.Status;
                bResult = db.SaveChanges() > 0;
                return bResult;
            }
            catch {
                return bResult;
            }
        }
    }
}
