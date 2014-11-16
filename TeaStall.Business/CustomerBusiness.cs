using System;
using System.Collections.Generic;
using TeaStall.Business.Models;
using TeaStall.Database.Models;

namespace TeaStall.Business
{
    public class CustomerBusiness : BusinessManager, ICustomerBusiness
    {
        private readonly ICustomerDataContext _customerDataContext;

        public CustomerBusiness(ICustomerDataContext customerDataContext)
        {
            _customerDataContext = customerDataContext;
        }

        public bool AddCustomer(Customer customer)
        {
            customer.Id = Guid.NewGuid().ToString();
            return _customerDataContext.AddCustomer(customer);
        }

        public IList<Customer> GetCustomers()
        {
            return _customerDataContext.GetCustomers();
        }

        public bool UpdateCustomer(Customer customer)
        {
            return _customerDataContext.UpdateCustomer(customer);
        }
    }
}