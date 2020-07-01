using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.Services
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> _customers;

        public CustomerService()
        {
            _customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "John.Doe@email.com",
                    PhoneNumber = "123-456-7890",
                    BirthMonth = 2,
                    BirthYear = 2000
                }
            };
        }

        /*
        public object AddCustomer(CustomerService customer)
        {
            throw new NotImplementedException();
        }*/
 
        public async Task<int> AddCustomer(Customer customer)
        {
            //simpliy generate new id
            customer.Id = _customers.Count + 1;

            _customers.Add(customer);
            return customer.Id;
        }

        public async Task DeleteCustomer(int id)
        {
            var customerToDelete = await GetCustomerById(id);
            _customers.Remove(customerToDelete);
        }

        public async Task DeleteAllCustomers()
        {
            _customers = new List<Customer>();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return _customers;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);
        }
    }
}
