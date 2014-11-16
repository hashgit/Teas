using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TeaStall.Database.Repository
{
    public abstract class BaseDataContext : DbContext
    {
        protected BaseDataContext()
            : base("TeaStallDatabase")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}