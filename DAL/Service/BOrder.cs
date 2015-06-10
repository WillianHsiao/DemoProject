using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class BOrder : IOrderRepository
    {
        protected TestDataBaseEntities db = new TestDataBaseEntities();

        public IQueryable<Order> CustomOrders(Guid UserPK) {
            return null;
        }

        public IQueryable<Order> Orders() {
            return null;
        }

        public Order OrderDetail(Guid OrderPK) {
            return null;
        }

        public bool SaveOrder(Order order) {
            return false;
        }
    }
}
