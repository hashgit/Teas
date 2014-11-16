using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TeaStall.Database.Models;

namespace TeaStall.Database.Repository
{
    public class TeaStallDataContext : BaseDataContext, ITeaStallDataContext
    {
        public DbSet<TeaBase> BaseTeaCollection { get; set; }
        public DbSet<TeaFlavor> TeaFlavorCollection { get; set; }
        public DbSet<Toppings> ToppingCollection { get; set; } 

        public void AddBaseTea(TeaBase baseTea)
        {
            BaseTeaCollection.Add(baseTea);
            SaveChanges();
        }

        public List<TeaBase> GetAllBaseTea()
        {
            return BaseTeaCollection.ToList();
        }

        public void AddTeaFlavor(TeaFlavor teaFlavor)
        {
            TeaFlavorCollection.Add(teaFlavor);
            SaveChanges();
        }

        public IList<TeaFlavor> GetAllTeaFlavors()
        {
            return TeaFlavorCollection.ToList();
        }

        public void AddTopping(Toppings teaTopping)
        {
            ToppingCollection.Add(teaTopping);
            SaveChanges();
        }

        public IList<Toppings> GetToppings()
        {
            return ToppingCollection.ToList();
        }

        public bool SetBasePrice(string baseId, double price)
        {
            var baseTea = BaseTeaCollection.FirstOrDefault(b => b.Id == baseId);
            if (baseTea != null)
            {
                baseTea.Price = price;
                SaveChanges();

                return true;
            }

            return false;
        }

        public bool SetFlavorPrice(string flavorId, double price)
        {
            var flavor = TeaFlavorCollection.FirstOrDefault(b => b.Id == flavorId);
            if (flavor != null)
            {
                flavor.Price = price;
                SaveChanges();

                return true;
            }

            return false;
        }

        public bool SetToppingPrice(string toppingId, double price)
        {
            var topping = ToppingCollection.FirstOrDefault(b => b.Id == toppingId);
            if (topping != null)
            {
                topping.Price = price;
                SaveChanges();

                return true;
            }

            return false;
        }
    }
}