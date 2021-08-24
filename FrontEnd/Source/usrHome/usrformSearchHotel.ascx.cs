using DAO.Source;
using DAO.Source.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd.Source.usrHome
{
    public partial class usrformSearchHotel : System.Web.UI.UserControl
    {
        private DatPhongKhachSanDbContext _db = new DatPhongKhachSanDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                TextBoxCheckIn.Text = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy");
                TextBoxCheckOut.Text = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy");
                hidHotel.Value = string.Join(",", _db.Hotels.ToList().Select(x => x.Name));

                ddlCity.DataSource = _db.Cities.OrderBy(x => x.Name).ToList();
                ddlCity.DataValueField = "Id";
                ddlCity.DataTextField = "Name";
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, new ListItem("Tất cả", "0"));
            }
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string hotelName = TextBoxHotelName.Text;
                string CheckInTime = TextBoxCheckIn.Text;
                if (CheckInTime == "")
                {
                    LiteralSearchError.Text = "<div class='error'>Bạn phải chọn ngày đến !</div>";
                    LiteralSearchError.Visible = true;
                    return;
                }
                string CheckOutTime = TextBoxCheckOut.Text;
                if (CheckOutTime == "")
                {
                    LiteralSearchError.Text = "<div class='error'>Bạn phải chọn ngày đi !</div>";
                    LiteralSearchError.Visible = true;
                    return;
                }
                SearchInput input = new SearchInput
                {
                    KeyWord = hotelName,
                    DateCheckIn = DateTime.Parse(CheckInTime, CultureInfo.GetCultureInfo("en-Gb")),
                    DateCheckOut = DateTime.Parse(CheckOutTime, CultureInfo.GetCultureInfo("en-Gb")),
                    CityId = int.Parse(ddlCity.SelectedValue),
                    Star = int.Parse(ddlStar.SelectedValue)
                };
                _db.SearchInputs.Add(input);
                _db.SaveChanges();
                Response.Redirect("/tim-kiem?sId=" + input.Id);
            }
            catch
            {
                LiteralSearchError.Text = "<div class='error'>đã xảy ra lỗi !</div>";
                LiteralSearchError.Visible = true;
            }

        }
    }
}