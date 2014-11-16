using System.Collections.Generic;
using Newtonsoft.Json;
using TeaStall.Services.Models;

namespace TeaStall.ServiceManager
{
    public class TeaStallServiceManager : BaseServiceManager, ITeaStallServiceManager
    {
        private const string TeaContents = "/api/teacontents/";
        private const string Customers = "/api/customers/";

        public List<CustomerDto> GetCustomers()
        {
            var resource = string.Format("{0}", Customers);
            var serializer = new JsonSerializer();
            return GetWebApiModel<List<CustomerDto>>(resource, serializer);
        }

        public List<ToppingDto> GetToppings()
        {
            var resource = string.Format("{0}/topping", TeaContents);
            var serializer = new JsonSerializer();
            return GetWebApiModel<List<ToppingDto>>(resource, serializer);
        }

        public List<FlavorDto> GetFlavors()
        {
            var resource = string.Format("{0}/flavor", TeaContents);
            var serializer = new JsonSerializer();
            return GetWebApiModel<List<FlavorDto>>(resource, serializer);
        }

        public List<TeaBaseDto> GetTeaBases()
        {
            var resource = string.Format("{0}/base", TeaContents);
            var serializer = new JsonSerializer();
            return GetWebApiModel<List<TeaBaseDto>>(resource, serializer);
        }

        public bool SaveCustomer(CustomerDto customer)
        {
            bool returnFlag = PostWebApiModel<bool, CustomerDto>(Customers, customer);
            return returnFlag;
        }

        public bool SetBasePrice(string id, double price, string type)
        {
            var resource = string.Format("{0}/{3}/{1}/price/{2}", TeaContents, id, price, type);
            return PutWebApiModel<bool, TeaBaseDto>(resource, null);
        }

        public bool AddBase(string text)
        {
            var resource = string.Format("{0}/{1}/{2}", TeaContents, "base", text);
            return PostWebApiModel<bool, TeaBaseDto>(resource, null);
        }

        public bool AddFlavor(string text)
        {
            var resource = string.Format("{0}/{1}/{2}", TeaContents, "flavor", text);
            return PostWebApiModel<bool, TeaBaseDto>(resource, null);
        }

        public bool AddTopping(string text)
        {
            var resource = string.Format("{0}/{1}/{2}", TeaContents, "topping", text);
            return PostWebApiModel<bool, TeaBaseDto>(resource, null);
        }
    }
}