using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Source.Model
{
    public class Manager
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public bool Sex { get; set; }
        public string Skype { get; set; }
        public string ChucVu { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public virtual ManagerPermission ManagerPermission { get; set; }
        public virtual HotelImage Image { get; set; }
        public bool IsManagerOfHotel(Hotel hotel)
        {
            if (ManagerPermission.Permission == Permission.Admin)
                return true;
            if (hotel.Manager == this)
                return true;
            return false;
        }
        public bool IsManagerOfHotel(List<OrderHotelRoomType> orderRoomTypes)
        {
            if (ManagerPermission.Permission == Permission.Admin)
                return true;
            if(orderRoomTypes.Where(x=>x.HotelRoomType.HotelRooms.Where(y=>y.Manager==this).Count()>0).Count()>0)
                return true;
            return false;
        }
    }
}
