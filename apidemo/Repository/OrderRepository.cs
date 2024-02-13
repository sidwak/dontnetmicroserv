using apidemo.DBContexts;
using apidemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace apidemo.Repository
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ProductContext _dbContext;

        public OrderRepository(ProductContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public void DeleteOrder(int orderId) 
        {
            var order = _dbContext.Orders.Find(orderId);
            _dbContext.Orders.Remove(order);
            Save();
        }
        public Order GetOrderById(int orderId) 
        {
            return _dbContext.Orders.Find(orderId);
        }
        public IEnumerable<Order> GetOrders() 
        {
            return _dbContext.Orders.ToList();
        }
        public void InsertOrder(Order order) 
        {
            _dbContext.Add(order);
            Save();
        }
        public void Save() 
        {
            _dbContext.SaveChanges();
        }
        public void UpdateOrder(Order order) 
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            Save();
        }       
    }
}
