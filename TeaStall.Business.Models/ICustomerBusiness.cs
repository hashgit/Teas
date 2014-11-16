using System.Collections.Generic;
using TeaStall.Database.Models;

namespace TeaStall.Business.Models
{
    public interface ICustomerBusiness
    {
        bool AddCustomer(Customer customer);
        IList<Customer> GetCustomers();
        bool UpdateCustomer(Customer dto);
    }
}