using System.Collections.Generic;

namespace TeaStall.Database.Models
{
    public interface ICustomerDataContext
    {
        bool AddCustomer(Customer customer);
        List<Customer> GetCustomers();
        bool UpdateCustomer(Customer customer);
    }
}