using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Source.Model
{
    public class HotelRoomType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxPeople { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual List<HotelRoom> HotelRooms { get; set; }
        public virtual List<HotelFeature> HotelFeatures{ get; set; }
        public virtual HotelImage Avatar { get; set; }
        public virtual List<RoomPrice> RoomPrices { get; set; }
        public List<RoomPrice> getRoomPrice(DateTime checkInTime, DateTime checkOutTime)
        {
            return (from RoomPrice rp in RoomPrices.Where(x => (x.StartDate >= checkInTime && x.StartDate < checkOutTime) ||
                   (x.EndDate > checkInTime && x.EndDate <= checkOutTime)
                   || (x.StartDate < checkInTime && x.EndDate >= checkOutTime))
                    select rp).ToList();
        }
        public int getTotalPrice(DateTime checkInTime, DateTime checkOutTime)
        {
            try
            {
                List<RoomPrice> li = getRoomPrice(checkInTime, checkOutTime);
                int total = 0;
                foreach(RoomPrice rp in li)
                {
                    DateTime start=rp.StartDate>checkInTime?rp.StartDate:checkInTime;
                    DateTime end=rp.EndDate<checkOutTime?rp.EndDate:checkOutTime;
                    total += rp.Price*(end.Subtract(start).Days);
                }
                return total;
            }
            catch
            {
                return 0;
            }
        }
        
    }
}
