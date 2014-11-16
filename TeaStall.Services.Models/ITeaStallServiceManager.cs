using System.Collections.Generic;

namespace TeaStall.Services.Models
{
    public interface ITeaStallServiceManager
    {
        List<CustomerDto> GetCustomers();
        List<ToppingDto> GetToppings();
        List<FlavorDto> GetFlavors();
        List<TeaBaseDto> GetTeaBases();
        bool SaveCustomer(CustomerDto customer);
        bool SetBasePrice(string id, double price, string type);
        bool AddBase(string text);
        bool AddFlavor(string text);
        bool AddTopping(string text);
    }
}