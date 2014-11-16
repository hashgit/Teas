using System.Collections;
using System.Collections.Generic;
using TeaStall.Database.Models;

namespace TeaStall.Business.Models
{
    public interface ITeaStallBusiness
    {
        void AddTeaBase(string teaBase);
        IList<TeaBase> GetTeaBase();
        void AddFlavor(string flavor);
        IList<TeaFlavor> GetFlavors();
        void AddTopping(string topping);
        IList<Toppings> GetToppings();
        bool SetBasePrice(string baseId, double price);
        bool SetFlavorPrice(string flavorId, double price);
        bool SetToppingPrice(string toppingId, double price);
    }
}
