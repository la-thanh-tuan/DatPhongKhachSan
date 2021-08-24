using DAO.Source;
using DAO.Source.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackEnd.Source.HotelManager
{
    public partial class DeleteHotelImage : System.Web.UI.Page
    {
        private DatPhongKhachSanDbContext _db = new DatPhongKhachSanDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    int imageId = int.Parse(Request["imageId"]);
                    HotelImage img= _db.HotelImages.Find(imageId);
                    Hotel hotel = _db.Hotels.Where(x => x.Images.Where(x1 => x1.Id == imageId).FirstOrDefault() != null).FirstOrDefault();
                    hotel.Images.Remove(img);
                    _db.HotelImages.Remove(img);
                    _db.SaveChanges();
                    litResult.Text = "true";
                }
                catch
                {
                    litResult.Text = "false";
                }
                

            }
        }
    }
}