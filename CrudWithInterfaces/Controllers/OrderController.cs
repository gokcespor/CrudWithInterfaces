using CrudWithInterfaces.Interfaces;
using CrudWithInterfaces.Models;
using CrudWithInterfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudWithInterfaces.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddOrder()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            _orderRepository.AddOrder(order);
            return RedirectToAction("GetAllOrders", "Order");
        }
        public IActionResult GetAllOrders()
        {
            var orders = _orderRepository.GetAllOrders();   
            return View(orders);
        }
        [HttpPost]
        public IActionResult DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
            return RedirectToAction("GetAllOrders", "Order");
        }
        public IActionResult UpdateOrder(int id)
        {
            var order = _orderRepository.GetOrderById(id);
            return View(order);
        }
        [HttpPost]
        public IActionResult UpdateOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
            return RedirectToAction("GetAllOrders", "Order");
        }
    }
}
