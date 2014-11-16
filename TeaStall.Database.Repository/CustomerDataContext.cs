using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TeaStall.Database.Models;

namespace TeaStall.Database.Repository
{
    public class CustomerDataContext : BaseDataContext, ICustomerDataContext
    {
        public DbSet<Customer> Customers { get; set; } 

        public bool AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            SaveChanges();
            return true;
        }

        public List<Customer> GetCustomers()
        {
            return Customers.ToList();
        }

        public bool UpdateCustomer(Customer customer)
        {
            Customers.Attach(customer);
            Entry(customer).State = EntityState.Modified;
            SaveChanges();

            return true;
        }
    }
}