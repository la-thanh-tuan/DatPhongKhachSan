using BackEnd.Source.Helper;
using DAO.Source;
using DAO.Source.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackEnd.Source.HotelManager
{
    public partial class EditPrices : System.Web.UI.Page
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
            int id = int.Parse(Request["roomTypeId"]);
            dtgPrice.DataSource = _db.Prices.Where(x => x.HotelRoomType.Id == id).OrderBy(x=>x.StartDate).ToList();
            dtgPrice.DataBind();
            DataGridHelper.SetStyle(dtgPrice);
        }

        protected void dtgPrice_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dtgPrice.CurrentPageIndex = e.NewPageIndex;
            LoadData();
        }

        protected void dtgPrice_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

        }

        protected void dtgPrice_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            int id = 0;
            if (e.CommandName == "save")
            {
                try
                {
                    int roomTypeId = int.Parse(Request["roomTypeId"]);
                    id = int.Parse(e.CommandArgument.ToString());
                    RoomPrice rp = _db.Prices.Find(id);
                    rp.StartDate = DateTime.Parse(((TextBox)e.Item.FindControl("txtStartDate")).Text,CultureInfo.GetCultureInfo("en-Gb"));
                    rp.EndDate = DateTime.Parse(((TextBox)e.Item.FindControl("txtEndDate")).Text, CultureInfo.GetCultureInfo("en-Gb"));
                    if (rp.EndDate <= rp.StartDate)
                    {
                        Notify.ShowMessageError("Ngày kết thúc nhỏ hơn ngày bắt đầu !", Page);
                        return;
                    }
                    if (_db.Prices.Where(x => x.HotelRoomType.Id == roomTypeId&& x.Id!=rp.Id
                        && ((x.StartDate <= rp.StartDate && x.EndDate >= rp.StartDate) || (x.StartDate <= rp.EndDate && x.EndDate >= rp.EndDate))
                        ).Count() > 0)
                    {
                        Notify.ShowMessageError("Khoảng giá bị trùng !", Page);
                        return;
                    }
                    rp.Price = int.Parse(((TextBox)e.Item.FindControl("txtPrice")).Text);
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
                    RoomPrice rp = _db.Prices.Find(id);
                    _db.Prices.Remove(rp);
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
                    int roomTypeId = int.Parse(Request["roomTypeId"]);
                    RoomPrice rp = new RoomPrice();
                    rp.StartDate = DateTime.Parse(((TextBox)e.Item.FindControl("txtStartDate")).Text, CultureInfo.GetCultureInfo("en-Gb"));
                    rp.EndDate = DateTime.Parse(((TextBox)e.Item.FindControl("txtEndDate")).Text, CultureInfo.GetCultureInfo("en-Gb"));
                    if (rp.EndDate <= rp.StartDate)
                    {
                        Notify.ShowMessageError("Ngày kết thúc nhỏ hơn ngày bắt đầu !", Page);
                        return;
                    }
                    if(_db.Prices.Where(x=>x.HotelRoomType.Id==roomTypeId 
                        &&((x.StartDate<=rp.StartDate && x.EndDate>=rp.StartDate)||(x.StartDate<=rp.EndDate&&x.EndDate>=rp.EndDate))
                        ).Count()>0)
                    {
                        Notify.ShowMessageError("Khoảng giá bị trùng !", Page);
                        return;
                    }
                    rp.Price = int.Parse(((TextBox)e.Item.FindControl("txtPrice")).Text);
                    rp.HotelRoomType = _db.HotelRoomTypes.Find(roomTypeId);
                    _db.Prices.Add(rp);
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
    }
}