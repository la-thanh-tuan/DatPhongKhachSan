using DAO.Source;
using DAO.Source.Model;
using FrontEnd.Source.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd.Source.usrHotelDetail
{
    public partial class usrHotelDetail : System.Web.UI.UserControl
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
            litNumOfRoom.Text = _hotel.HotelRoomTypes.Sum(x => x.HotelRooms.Count()).ToString();
            int sId;
            if (int.TryParse(Request["sId"], out sId))
            {
                SearchInput input = _db.SearchInputs.Find(sId);
                litPrice.Text = FormatHelper.FormatPrice(_hotel.getMinPrice(input.DateCheckIn, input.DateCheckOut).ToString());
            }
            else
            {
                litPrice.Text =FormatHelper.FormatPrice( _hotel.getMinPrice().ToString());
            }
            rptFeature.DataSource = _db.HotelFeatures.Where(x => x.HotelRoomTypes.Where(y => y.Hotel.Id == id).Count() > 0).ToList();
            rptFeature.DataBind();
        }
    }
}