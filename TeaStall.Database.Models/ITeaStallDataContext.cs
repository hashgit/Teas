using System.Collections.Generic;

namespace TeaStall.Database.Models
{
    public interface ITeaStallDataContext
    {
        void AddBaseTea(TeaBase baseTea);
        List<TeaBase> GetAllBaseTea();
        void AddTeaFlavor(TeaFlavor teaFlavor);
        IList<TeaFlavor> GetAllTeaFlavors();
        void AddTopping(Toppings teaTopping);
        IList<Toppings> GetToppings();
        bool SetBasePrice(string baseId, double price);
        bool SetFlavorPrice(string flavorId, double price);
        bool SetToppingPrice(string toppingId, double price);
    }
}
