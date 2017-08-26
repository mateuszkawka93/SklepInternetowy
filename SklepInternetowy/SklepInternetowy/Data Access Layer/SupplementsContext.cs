using SklepInternetowy.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SklepInternetowy.Data_Access_Layer
{
    public class SupplementsContext : DbContext
    {
        public SupplementsContext() : base("SupplementsContext")
        {
        }

        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }


        //usunięcie opcji automatycznego dopisywania S na końcu nazw tabel

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}