using BackEnd.Source.Helper;
using DAO.Source;
using DAO.Source.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackEnd.Source.HotelManager.usr
{
    public partial class usrHotelImage : System.Web.UI.UserControl
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
            LabelListImage.Text = "";
            try
            {
                int hotelId = int.Parse(Request["hotelId"]);
                foreach (HotelImage imht in _db.Hotels.Find(hotelId).Images)
                {
                    string name = imht.Url;
                    name = name.Substring(name.LastIndexOf(@"/") + 1);
                    LabelListImage.Text +=
                        "<li id=" + imht.Id + "><a class='image' href=" + imht.Url +
                        "> <span class='img'><img src='" + imht.Url + "' alt='' style='width:150px;height:150px;'/></span>" +
                        "<span class='filename'>" + name + "</span></a> </li>";
                }
            }
            catch { }
        }
        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            string avatar = "";
            Hotel hotel=_db.Hotels.Find(int.Parse(Request["hotelId"]));
            foreach (HttpPostedFile file1 in FileUploadAvatar.PostedFiles)
            {
                avatar = System.IO.Path.GetFileName(file1.FileName);
                int i = 0;
                avatar = avatar.Replace(' ','.');
                FileInfo files;
                do
                {
                    i++;
                    avatar = i + avatar;
                    files = new FileInfo(Server.MapPath("~/images/preview/") + avatar);
                } while (files.Exists);
                string ext = System.IO.Path.GetExtension(file1.FileName);
                if ((ext == ".jpg") || (ext == ".png") || (ext == ".gif"))
                {
                    try
                    {
                        file1.SaveAs(Server.MapPath("~/Images/HotelImages/") + avatar);
                        avatar = "/Images/HotelImages/" + avatar;
                        HotelImage hi = new HotelImage { Url = avatar };
                        _db.HotelImages.Add(hi);
                        _db.SaveChanges();
                        hotel.Images.Add(hi);
                    }
                    catch { }
                }
            }
            _db.SaveChanges();
            LoadData();
        }
    }
}