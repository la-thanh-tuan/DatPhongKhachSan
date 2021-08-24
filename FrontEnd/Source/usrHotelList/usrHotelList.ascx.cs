using DAO.Source;
using DAO.Source.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd.Source.usrHotelList
{
    public partial class usrHotelList : System.Web.UI.UserControl
    {
        private DatPhongKhachSanDbContext _db = new DatPhongKhachSanDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            lvHotelList.DataSource = _db.Hotels.ToList();
            lvHotelList.DataBind();
        }

        protected void lvHotelList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dtpHotelList.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            LoadData();
        }

        protected void lvHotelList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Literal litFeature = e.Item.FindControl("litFeature") as Literal;
            if (litFeature != null)
            {
                int hotelId = int.Parse(DataBinder.Eval(e.Item.DataItem, "Id").ToString());
                List<HotelFeature> htfs = _db.HotelFeatures.Where(x => x.HotelRoomTypes.Where(y => y.Hotel.Id == hotelId).Count() > 0).ToList();
                foreach (HotelFeature hf in htfs)
                    litFeature.Text += "<div class='divFeatured'><b>" + hf.Name + "</b> miễn phí</div>";
            }
        }
    }
}