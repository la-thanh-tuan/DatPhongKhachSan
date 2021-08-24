using DAO.Source.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Source
{
    public class DatPhongKhachSanDbContext:DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelFeature> HotelFeatures { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<HotelRoomType> HotelRoomTypes { get; set; }
        public DbSet<HotelImage> HotelImages { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<ManagerPermission> ManagerPermissions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderContact> OrderContacts { get; set; }
        public DbSet<OrderHotelRoomType> OrderRooms { get; set; }
        public DbSet<RoomPrice> Prices { get; set; }
        public DbSet<Promote> Promotes { get; set; }
        public DbSet<SearchInput> SearchInputs { get; set; }
        public DbSet<City> Cities { get; set; }
        public DatPhongKhachSanDbContext():base("DatPhongKhachSanDB")
        {
            
        }
        public List<Order> GetListOrder(Manager currentUser)
        {
            if (currentUser.ManagerPermission.Permission == Permission.Admin)
                return this.Orders.ToList();
            return Orders.ToList();
        }
        public int GetNumOfRoomTypeOrder(DateTime checkInTime, DateTime checkOutTime,int roomTypeId)
        {
            try
            {
              return  Orders.Where(x => ((x.StartDate >= checkInTime && x.StartDate < checkOutTime) ||
                   (x.EndDate > checkInTime && x.EndDate <= checkOutTime)
                   || (x.StartDate < checkInTime && x.EndDate >= checkOutTime)) && (x.OrderHotelRoomTypes.Where(y => y.Id == roomTypeId)).Count() > 0).Count();
            }
            catch
            {
                return 0;
            }
        } 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
