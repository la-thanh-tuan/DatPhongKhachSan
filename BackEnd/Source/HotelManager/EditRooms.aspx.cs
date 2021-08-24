using BackEnd.Source.Helper;
using DAO.Source;
using DAO.Source.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackEnd.Source.HotelManager
{
    public partial class EditRooms : System.Web.UI.Page
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
            dtgRoom.DataSource = _db.HotelRooms.Where(x => x.HotelRoomType.Id == id).ToList();
            dtgRoom.DataBind();
            DataGridHelper.SetStyle(dtgRoom);
        }

        protected void dtgRoom_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dtgRoom.CurrentPageIndex = e.NewPageIndex;
            LoadData();
        }

        protected void dtgRoom_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DropDownList ddlManager = (DropDownList)e.Item.FindControl("ddlManager");
            if (ddlManager != null)
            {
                ddlManager.DataSource = _db.Managers.Where(x => x.ManagerPermission.Permission == Permission.RoomManager).ToList();
                ddlManager.DataTextField = "UserName";
                ddlManager.DataValueField = "Id";
                ddlManager.DataBind();
                ddlManager.Items.Insert(0, new ListItem("Chọn người quản lý", "0"));
                try
                {
                    ddlManager.SelectedValue = ((Manager)DataBinder.Eval(e.Item.DataItem, "Manager")).Id.ToString();
                }
                catch
                { }
            }
        }

        protected void dtgRoom_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            int id = 0;
            if (e.CommandName == "save")
            {
                try
                {
                    id = int.Parse(e.CommandArgument.ToString());
                    HotelRoom hr = _db.HotelRooms.Find(id);
                    hr.No = int.Parse(((TextBox)e.Item.FindControl("txtNo")).Text);
                    int managerId = int.Parse(((DropDownList)e.Item.FindControl("ddlManager")).SelectedValue);
                    hr.Manager = _db.Managers.Find(managerId);
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
                    HotelRoom hr = _db.HotelRooms.Find(id);
                    _db.HotelRooms.Remove(hr);
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
                    HotelRoom hr = new HotelRoom();
                    hr.HotelRoomType = _db.HotelRoomTypes.Find(roomTypeId);
                    hr.No = int.Parse(((TextBox)e.Item.FindControl("txtNo")).Text);
                    int managerId = int.Parse(((DropDownList)e.Item.FindControl("ddlManager")).SelectedValue);
                    hr.Manager = _db.Managers.Find(managerId);
                    _db.HotelRooms.Add(hr);
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