namespace DAO.Migrations
{
    using DAO.Source.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAO.Source.DatPhongKhachSanDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DAO.Source.DatPhongKhachSanDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.ManagerPermissions.AddOrUpdate(
            //  new ManagerPermission { Permission=Permission.Admin },
            //  new ManagerPermission { Permission=Permission.HotelManager },
            //  new ManagerPermission { Permission = Permission.RoomManager }
            //);
            //ManagerPermission mp = context.ManagerPermissions.Where(x=>x.Permission==Permission.Admin).First();
            //context.Managers.AddOrUpdate(
            //  new Manager { UserName = "admin", Password = "123456", ManagerPermission = mp }
            //);
            
        }
    }
}
