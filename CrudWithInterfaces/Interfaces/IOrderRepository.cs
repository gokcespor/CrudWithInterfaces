using CrudWithInterfaces.Models;

namespace CrudWithInterfaces.Interfaces
{
    public interface IOrderRepository
    {
        void AddOrder(Order order);
        List<Order> GetAllOrders();
        void DeleteOrder(int id);
        void UpdateOrder(Order order);
        Order GetOrderById(int id);
    }
}
