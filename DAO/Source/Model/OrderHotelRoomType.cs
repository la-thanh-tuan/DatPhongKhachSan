using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Source.Model
{
    public class OrderHotelRoomType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int NumOfRoom { get; set; }
        public int NumOfPeople { get; set; }
        public virtual  HotelRoomType HotelRoomType { get; set; }
    }
}
