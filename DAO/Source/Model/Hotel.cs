using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Source.Model
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public int Star { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual HotelImage Avatar { get; set; }
        public virtual List<HotelImage> Images { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual List<HotelRoomType> HotelRoomTypes { get; set; }
        public virtual City City { get; set; }
        public int getMinPrice()
        {
            try
            {
                return (from HotelRoomType type in this.HotelRoomTypes
                        select type.RoomPrices.Where(x => x.EndDate > DateTime.Now).Min(p => p.Price)).First();
            }
            catch
            {
                return 0;
            }
        }
        public List<RoomPrice> getRoomPrice(DateTime checkInTime, DateTime checkOutTime)
        {
            List<RoomPrice> li = new List<RoomPrice>();
            foreach (HotelRoomType rp in HotelRoomTypes)
            {
                li.AddRange(rp.getRoomPrice(checkInTime, checkOutTime));
            }
            return li;
        }
        public int getMinPrice(DateTime checkInTime, DateTime checkOutTime)
        {
            try
            {
                List<RoomPrice> li = getRoomPrice(checkInTime, checkOutTime);
                return li.Min(x => x.Price);
            }
            catch
            {
                return 0;
            }
        }

        public List<HotelRoomType> getListHotelRoomType(DateTime checkInTime, DateTime checkOutTime)
        {
            return (from HotelRoomType hr in HotelRoomTypes.Where(x => x.getRoomPrice(checkInTime, checkOutTime).Count > 0)
                    select hr).ToList();
        }
    }
}
