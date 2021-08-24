using DAO.Source;
using DAO.Source.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd.Source.usrHotelDetail
{
    public partial class usrHotelIntroduction : System.Web.UI.UserControl
    {
        private DatPhongKhachSanDbContext _db = new DatPhongKhachSanDbContext();
        private Hotel _hotel;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            int id = int.Parse(Page.RouteData.Values["hotelId"].ToString());
            _hotel = _db.Hotels.Find(id);
            imgStar.ImageUrl = "/Images/Hotel/Star/b-star-" + _hotel.Star + ".png";
            litName.Text = _hotel.Name;
            litAdress.Text = _hotel.Adress;
        }
    }
}