using SklepInternetowy.Data_Access_Layer;

namespace SklepInternetowy.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<SklepInternetowy.Data_Access_Layer.SupplementsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SklepInternetowy.Data_Access_Layer.SupplementsContext";
        }

        protected override void Seed(SklepInternetowy.Data_Access_Layer.SupplementsContext context)
        {
            SupplementsInitializer.SeedSupplementsData(context);
        }
    }
}
