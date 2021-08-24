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
    public partial class usrHotelRoomType : System.Web.UI.UserControl
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
            int hotelId = int.Parse(Request["hotelId"]);
            dtgHotelRoomType.DataSource = _db.HotelRoomTypes.Where(x=>x.Hotel.Id==hotelId).ToList();
            dtgHotelRoomType.DataBind();
            DataGridHelper.SetStyle(dtgHotelRoomType);
        }

        protected void dtgHotelRoomType_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dtgHotelRoomType.CurrentPageIndex = e.NewPageIndex;
            LoadData();
        }

        protected void dtgHotelRoomType_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            int id = 0;
            if (e.CommandName == "save")
            {
                try
                {
                    id = int.Parse(e.CommandArgument.ToString());
                    HotelRoomType hrt = _db.HotelRoomTypes.Find(id);
                    hrt.Name = ((TextBox)e.Item.FindControl("txtName")).Text;
                    hrt.MaxPeople = int.Parse(((TextBox)e.Item.FindControl("txtMaxPeople")).Text);
                    FileUpload fileAvatar=e.Item.FindControl("fileAvatar") as FileUpload;
                    if(fileAvatar.PostedFile!=null&&fileAvatar.PostedFile.ContentLength>0)
                    {
                        fileAvatar.PostedFile.SaveAs(Server.MapPath("/Images/HotelImages/" + fileAvatar.PostedFile.FileName));
                        HotelImage hi = new HotelImage { Url = "/Images/HotelImages/" + fileAvatar.PostedFile.FileName };
                        _db.HotelImages.Add(hi);
                        hrt.Avatar = hi;
                    }
                    _db.SaveChanges();
                    Notify.ShowMessageSuccess("Lưu thành công !", Page);
                }
                catch
                {
                    Notify.ShowMessageError("đã xảy ra lỗi !", Page);
                }
            }
            else if (e.CommandName == "delete")
            {
                try
                {
                    id = int.Parse(e.CommandArgument.ToString());
                    HotelRoomType hrt = _db.HotelRoomTypes.Find(id);
                    _db.HotelRoomTypes.Remove(hrt);
                    _db.SaveChanges();
                    Notify.ShowMessageSuccess("Xóa thành công !", Page);
                }
                catch
                {
                    Notify.ShowMessageError("đã xảy ra lỗi !", Page);
                }
            }
            else if (e.CommandName == "add")
            {
                try
                {
                    int hotelId = int.Parse(Request["hotelId"]);
                    HotelRoomType hrt = new HotelRoomType();
                    hrt.Hotel = _db.Hotels.Find(hotelId);
                    hrt.Name = ((TextBox)e.Item.FindControl("txtName")).Text;
                    hrt.MaxPeople = int.Parse(((TextBox)e.Item.FindControl("txtMaxPeople")).Text);
                    FileUpload fileAvatar = e.Item.FindControl("fileAvatar") as FileUpload;
                    if (fileAvatar.PostedFile != null && fileAvatar.PostedFile.ContentLength > 0)
                    {
                        fileAvatar.PostedFile.SaveAs(Server.MapPath("/Images/HotelImages/" + fileAvatar.PostedFile.FileName));
                        HotelImage hi = new HotelImage { Url = "/Images/HotelImages/" + fileAvatar.PostedFile.FileName };
                        _db.HotelImages.Add(hi);
                        hrt.Avatar = hi;
                    }
                    _db.HotelRoomTypes.Add(hrt);
                    _db.SaveChanges();
                    Notify.ShowMessageSuccess("Thêm thành công !", Page);
                }
                catch
                {
                    Notify.ShowMessageError("đã xảy ra lỗi !", Page);
                }
            }
            LoadData();
        }

        protected void dtgHotelRoomType_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            Image imgAvatar = e.Item.FindControl("imgAvatar") as Image;
            if(imgAvatar!=null)
            {
                int id=int.Parse(DataBinder.Eval(e.Item.DataItem,"Id").ToString());
                HotelRoomType hrt=_db.HotelRoomTypes.Find(id);
                if (hrt.Avatar != null)
                    imgAvatar.ImageUrl = hrt.Avatar.Url;
            }
        }
    }
}