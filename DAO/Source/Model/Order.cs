using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Source.Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime OrderDate { get; set; }
        public int Price { get; set; }
        public virtual OrderContact OrderContact { get; set; }
        public virtual List<OrderHotelRoomType> OrderHotelRoomTypes { get; set; }
        public OrderStateEnum State { get; set; }
    }
    public enum OrderStateEnum
    {
        NEW=0,
        PROCESSING=1,
        CANCEL=2,
        COMPLETE=3
    }
}
