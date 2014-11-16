using System;
using System.Collections.Generic;
using TeaStall.Business.Models;
using TeaStall.Database.Models;

namespace TeaStall.Business
{
    public class TeaStallBusiness : BusinessManager, ITeaStallBusiness
    {
        private readonly ITeaStallDataContext _teaStallDataContext;

        public TeaStallBusiness(ITeaStallDataContext teaStallDataContext)
        {
            _teaStallDataContext = teaStallDataContext;
        }

        public void AddTeaBase(string teaBase)
        {
            var baseTea = new TeaBase {BaseTea = teaBase, Id = Guid.NewGuid().ToString() };
            _teaStallDataContext.AddBaseTea(baseTea);
        }

        public IList<TeaBase> GetTeaBase()
        {
            return _teaStallDataContext.GetAllBaseTea();
        }

        public void AddFlavor(string flavor)
        {
            var teaFlavor = new TeaFlavor() {Id = Guid.NewGuid().ToString(), Flavor = flavor};
            _teaStallDataContext.AddTeaFlavor(teaFlavor);
        }

        public IList<TeaFlavor> GetFlavors()
        {
            return _teaStallDataContext.GetAllTeaFlavors();
        }

        public void AddTopping(string topping)
        {
            var teaTopping = new Toppings() {Id = Guid.NewGuid().ToString(), Topping = topping };
            _teaStallDataContext.AddTopping(teaTopping);
        }

        public IList<Toppings> GetToppings()
        {
            return _teaStallDataContext.GetToppings();
        }

        public bool SetBasePrice(string baseId, double price)
        {
            return _teaStallDataContext.SetBasePrice(baseId, price);
        }

        public bool SetFlavorPrice(string flavorId, double price)
        {
            return _teaStallDataContext.SetFlavorPrice(flavorId, price);
        }

        public bool SetToppingPrice(string toppingId, double price)
        {
            return _teaStallDataContext.SetToppingPrice(toppingId, price);
        }
    }
}
