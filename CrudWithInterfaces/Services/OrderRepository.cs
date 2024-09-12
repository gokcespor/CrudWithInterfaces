using CrudWithInterfaces.Data;
using CrudWithInterfaces.Interfaces;
using CrudWithInterfaces.Models;

namespace CrudWithInterfaces.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            var order = GetOrderById(id);

            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public List<Order> GetAllOrders()
        {
            var orderList = _context.Orders.ToList();
            return orderList;
        }

        public Order GetOrderById(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == id);

            return order;
        }

        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }
    }
}
