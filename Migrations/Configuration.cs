namespace QuanLyNhaTro.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuanLyNhaTro.Models.QuanLyKhachTroContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "QuanLyNhaTro.EF.Model.QuanLyKhachTroContext";
        }

        protected override void Seed(QuanLyNhaTro.Models.QuanLyKhachTroContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
