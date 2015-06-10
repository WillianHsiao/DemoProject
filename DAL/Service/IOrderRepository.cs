using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public interface IOrderRepository
    {
        IQueryable<Order> CustomOrders(Guid UserPK);
        IQueryable<Order> Orders();
        Order OrderDetail(Guid OrderPK);
        bool SaveOrder(Order order);
    }
}
