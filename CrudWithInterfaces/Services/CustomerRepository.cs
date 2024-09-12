using CrudWithInterfaces.Data;
using CrudWithInterfaces.Interfaces;
using CrudWithInterfaces.Models;

namespace CrudWithInterfaces.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            var customerList = _context.Customers.ToList();
            return customerList;
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}
