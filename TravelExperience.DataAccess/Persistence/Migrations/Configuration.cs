namespace TravelExperience.DataAccess.Persistence.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TravelExperience.DataAccess.Persistence.Repositories.AppDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            MigrationsDirectory = @"Persistence\Migrations";
        }

        protected override void Seed(Repositories.AppDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.


        }
    }
}
