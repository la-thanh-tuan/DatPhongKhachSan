using BackEnd.Source.Helper;
using DAO.Source;
using DAO.Source.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackEnd.Source.HotelManager.usr
{
    public partial class usrHotelBasic : System.Web.UI.UserControl
    {
        private DatPhongKhachSanDbContext _db = new DatPhongKhachSanDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            int id = 0;
            ddlCity.DataSource = _db.Cities.OrderBy(x => x.Name).ToList();
            ddlCity.DataValueField = "Id";
            ddlCity.DataTextField = "Name";
            ddlCity.DataBind();
            if (int.TryParse(Request["hotelId"], out id))
            {
                Hotel hotel = _db.Hotels.Find(id);
                if (hotel == null)
                    return;
                txtAdress.Text = hotel.Adress;
                txtDescription.Text = hotel.Description;
                txtEmail.Text = hotel.Email;
                txtHotelName.Text = hotel.Name;
                txtPhone.Text = hotel.Phone;
                ddlStar.SelectedValue = hotel.Star.ToString();
                if (hotel.Avatar != null)
                    imgAvatar.ImageUrl = hotel.Avatar.Url;
                
                try
                {
                    ddlCity.SelectedValue = hotel.City.Id.ToString();
                }
                catch { }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Hotel hotel;
                int id = 0;
                if (int.TryParse(Request["hotelId"], out id))
                {
                    hotel = _db.Hotels.Find(id);
                }
                else
                {
                    hotel = new Hotel();
                }
                hotel.Adress = txtAdress.Text;
                if (fileAvatar.PostedFile != null && fileAvatar.PostedFile.ContentLength > 0)
                {
                    fileAvatar.PostedFile.SaveAs(Server.MapPath("/Images/HotelImages/" + fileAvatar.PostedFile.FileName));
                    HotelImage hi = new HotelImage { Url = "/Images/HotelImages/" + fileAvatar.PostedFile.FileName };
                    _db.HotelImages.Add(hi);
                    _db.SaveChanges();
                    hotel.Avatar = hi;

                }
                hotel.Description = txtDescription.Text;
                hotel.Email = txtEmail.Text;
                hotel.Name = txtHotelName.Text;
                hotel.Phone = txtPhone.Text;
                hotel.Star = int.Parse(ddlStar.SelectedValue);
                hotel.City = _db.Cities.Find(int.Parse(ddlCity.SelectedValue));
                if (id == 0)
                    _db.Hotels.Add(hotel);
                _db.SaveChanges();
                Notify.ShowMessageSuccessFromAnotherPage("Đã lưu thông tin khách sạn thành công !");
                Response.Redirect("ManagerHotel.aspx");
            }
            catch
            {
                Notify.ShowMessageError("đã xảy ra lỗi !", Page);
            }
        }
    }
}