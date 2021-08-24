using DAO.Source;
using DAO.Source.Model;
using FrontEnd.Source.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd.Source
{
    public partial class HotelResult : System.Web.UI.Page
    {
        private DatPhongKhachSanDbContext _db = new DatPhongKhachSanDbContext();
        private SearchInput input;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                int sId = int.Parse(Request["sId"]);
                input = _db.SearchInputs.Find(sId);
                TextBoxHotelName.Text = input.KeyWord;
                TextBoxNgayDen.Text = input.DateCheckIn.ToString("dd/MM/yyyy");
                TextBoxNgayDi.Text = input.DateCheckOut.ToString("dd/MM/yyyy");

                ddlCity.DataSource = _db.Cities.OrderBy(x => x.Name).ToList();
                ddlCity.DataValueField = "Id";
                ddlCity.DataTextField = "Name";
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, new ListItem("Tất cả", "0"));
                ddlCity.SelectedValue = input.CityId.ToString();
                ddlStar.SelectedValue = input.Star.ToString();

                hidHotelTag.Value = string.Join(",", _db.Hotels.Select(x => x.Name).ToList());
                Hotel[] li = _db.Hotels.Where(x => (input.KeyWord.Length == 0 || x.Name.Contains(input.KeyWord)) && (input.CityId == 0 || x.City.Id == input.CityId)
                    && (input.Star == 0 || input.Star == x.Star)).ToArray();
                for (int i = 0; i < li.Length - 1; i++)
                {
                    for (int j = i; j < li.Length; j++)
                    {
                        if (li[i].getMinPrice(input.DateCheckIn, input.DateCheckOut) > li[j].getMinPrice(input.DateCheckIn, input.DateCheckOut))
                        {
                            Hotel a = li[i];
                            li[i] = li[j];
                            li[j] = a;
                        }
                    }
                }
                lvHotel.DataSource = li;
                lvHotel.DataBind();
            }
            catch { };
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string hotelName = TextBoxHotelName.Text;
                string CheckInTime = TextBoxNgayDen.Text;
                string CheckOutTime = TextBoxNgayDi.Text;
                SearchInput input = new SearchInput
                {
                    KeyWord = hotelName,
                    DateCheckIn = DateTime.Parse(CheckInTime, CultureInfo.GetCultureInfo("en-Gb")),
                    DateCheckOut = DateTime.Parse(CheckOutTime, CultureInfo.GetCultureInfo("en-Gb")),
                    CityId = int.Parse(ddlCity.SelectedValue),
                    Star = int.Parse(ddlStar.SelectedValue)
                };
                DatPhongKhachSanDbContext db = new DatPhongKhachSanDbContext();
                db.SearchInputs.Add(input);
                db.SaveChanges();
                Response.Redirect("/tim-kiem?sId=" + input.Id);
            }
            catch
            {
            }
        }

        protected void mnOrderBy_MenuItemClick(object sender, MenuEventArgs e)
        {
            int sId = int.Parse(Request["sId"]);
            input = _db.SearchInputs.Find(sId);
            if (e.Item.Value == "thap-nhat")
            {
                Hotel[] li = _db.Hotels.Where(x => (input.KeyWord.Length == 0 || x.Name.Contains(input.KeyWord)) && (input.CityId == 0 || x.City.Id == input.CityId)
                    && (input.Star == 0 || input.Star == x.Star)).ToArray();
                for (int i = 0; i < li.Length - 1; i++)
                {
                    for (int j = i; j < li.Length; j++)
                    {
                        if (li[i].getMinPrice(input.DateCheckIn, input.DateCheckOut) > li[j].getMinPrice(input.DateCheckIn, input.DateCheckOut))
                        {
                            Hotel a = li[i];
                            li[i] = li[j];
                            li[j] = a;
                        }
                    }
                }
                lvHotel.DataSource = li;
                lvHotel.DataBind();
            }
            else if (e.Item.Value == "cao-nhat")
            {
                Hotel[] li = _db.Hotels.Where(x => (input.KeyWord.Length == 0 || x.Name.Contains(input.KeyWord)) && (input.CityId == 0 || x.City.Id == input.CityId)
                    && (input.Star == 0 || input.Star == x.Star)).ToArray();
                for (int i = 0; i < li.Length - 1; i++)
                {
                    for (int j = i; j < li.Length; j++)
                    {
                        if (li[i].getMinPrice(input.DateCheckIn, input.DateCheckOut) < li[j].getMinPrice(input.DateCheckIn, input.DateCheckOut))
                        {
                            Hotel a = li[i];
                            li[i] = li[j];
                            li[j] = a;
                        }
                    }
                }
                lvHotel.DataSource = li;
                lvHotel.DataBind();
            }
            else if (e.Item.Value == "sao")
            {
                lvHotel.DataSource = _db.Hotels.Where(x => (input.KeyWord.Length == 0 || x.Name.Contains(input.KeyWord)) && (input.CityId == 0 || x.City.Id == input.CityId)
                    && (input.Star == 0 || input.Star == x.Star)).OrderByDescending(x => x.Star).ToList();
                lvHotel.DataBind();
            }
        }

        protected void lvHotel_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Literal litFeature = e.Item.FindControl("litFeature") as Literal;
            if (litFeature != null)
            {
                int sId = int.Parse(Request["sId"]);
                input = _db.SearchInputs.Find(sId);
                int hotelId = int.Parse(DataBinder.Eval(e.Item.DataItem, "Id").ToString());
                List<HotelFeature> htfs = _db.HotelFeatures.Where(x => x.HotelRoomTypes.Where(y => y.Hotel.Id == hotelId).Count() > 0).ToList();
                foreach (HotelFeature hf in htfs)
                    litFeature.Text += "<div class='divFeatured'><b>" + hf.Name + "</b> miễn phí</div>";
                Hotel hotel = _db.Hotels.Find(hotelId);
                Literal litPrice = e.Item.FindControl("litPrice") as Literal;
                litPrice.Text = FormatHelper.FormatPrice(hotel.getMinPrice(input.DateCheckIn, input.DateCheckOut).ToString());
            }
        }

        protected void lvHotel_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dtpHotel.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            LoadData();
        }
    }
}