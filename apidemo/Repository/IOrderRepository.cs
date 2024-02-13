using apidemo.Models;
using System.Collections;

namespace apidemo.Repository
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int OrderId);
        void InsertOrder(Order Order);
        void DeleteOrder(int OrderId);
        void UpdateOrder(Order Order);
        void Save();
    }
}
