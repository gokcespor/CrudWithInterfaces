using CrudWithInterfaces.Models;

namespace CrudWithInterfaces.Interfaces
{
    public interface ICustomerRepository
    {
        void AddCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        void DeleteCustomer(int id);
        void UpdateCustomer(Customer customer);
        Customer GetCustomerById(int id);
    }
}
