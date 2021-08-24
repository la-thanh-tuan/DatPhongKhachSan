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
    public partial class usrHotelImage : System.Web.UI.UserControl
    {
        private DatPhongKhachSanDbContext _db = new DatPhongKhachSanDbContext();
        private Hotel _hotel;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            int id = int.Parse(Page.RouteData.Values["hotelId"].ToString());
            _hotel = _db.Hotels.Find(id);
           imgHotelImage.ImageUrl =UrlHelper.BackEndUrl+ _hotel.Images[0].Url;

            rptImage.DataSource = _hotel.Images.ToList();
            rptImage.DataBind();
        }
    }
}