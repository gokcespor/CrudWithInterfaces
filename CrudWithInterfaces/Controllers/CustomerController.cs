using CrudWithInterfaces.Interfaces;
using CrudWithInterfaces.Models;
using CrudWithInterfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudWithInterfaces.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
            return RedirectToAction("GetAllCustomers", "Customer");
        }
        public IActionResult GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();
            return View(customers);
        }
        [HttpPost]
        public IActionResult DeleteCustomer(int id)
        {
            _customerRepository.DeleteCustomer(id);
            return RedirectToAction("GetAllCustomers", "Customer");
        }
        public IActionResult UpdateCustomer(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
            return RedirectToAction("GetAllCustomers", "Customer");
        }
    }
}
