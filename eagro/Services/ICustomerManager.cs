using eagro.Models;
using eagro.Options;
using System.Collections.Generic;

namespace eagro.Services
{
    public interface ICustomerManager
    {
        Customer CreateCustomer(CustomerOption custOption);
        string CustomerName(int customerId);
        bool DeleteCustomerById(int id);
        Customer FindCustomerByEmail(CustomerOption custOption);
        Customer FindCustomerById(int customerId);
        Customer FindCustomerByLoginDetails(CustomerOption custOption);
        List<Customer> FindCustomerByName(CustomerOption custOption);
        bool SoftDeleteCustomerById(int id);
        Customer Update(CustomerOption custOption, int customerId);
    }
}