using SampleApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleApp.Services
{
    public interface ICustomerService
    {
        Task<int> AddCustomer(Customer customer);
        Task DeleteCustomer(int id);
        Task DeleteAllCustomers();
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerById(int id);
    }
}
