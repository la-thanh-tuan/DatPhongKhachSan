using BackEnd.Source.Account;
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

namespace BackEnd.Source.Booking
{
    public partial class BookingDetail : System.Web.UI.Page
    {
        private Order _order { get; set; }
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
            try
            {
                //kiem tra quyen
                Manager currentUser=  BackEndAuthentication.GetCurrentUserLogin(_db);
                 int orderId = int.Parse(Request["orderId"]);
                _order = _db.Orders.Find(orderId);
                if (currentUser.IsManagerOfHotel(_order.OrderHotelRoomTypes.First().HotelRoomType.Hotel) ||
                    currentUser.IsManagerOfHotel(_order.OrderHotelRoomTypes))
                {


                    litOrderId.Text = _order.Id.ToString();
                    litStartDate.Text = _order.StartDate.ToString("dd/MM/yyyy");
                    litEndDate.Text = _order.EndDate.ToString("dd/MM/yyyy");
                    litPrice.Text = _order.Price.ToString();
                    lblName.Text = _order.OrderContact.Name;
                    lblAdress.Text = _order.OrderContact.Adress;
                    lblPhone.Text = _order.OrderContact.Phone;
                    lblEmail.Text = _order.OrderContact.Email;
                    litOrderDate.Text = _order.OrderDate.ToString("dddd dd/MM/yyyy HH:mm",CultureInfo.GetCultureInfo("vi-Vn"));
                    Hotel hotel = _order.OrderHotelRoomTypes.First().HotelRoomType.Hotel;
                    litHotel.Text = hotel.Name + " - địa chỉ :" + hotel.Adress;
                    ddlState.SelectedValue = ((int)_order.State).ToString();

                    dtgOrderRoom.DataSource = _order.OrderHotelRoomTypes.ToList();
                    dtgOrderRoom.DataBind();
                    DataGridHelper.SetStyle(dtgOrderRoom);
                }
                else
                {
                    Notify.ShowMessageErrorFromAnotherPage("Bạn không có quyền xem đơn hàng này !");
                    Response.Redirect("ManagerBooking.aspx");
                }
            }
            catch { }
        }

        protected void dtgHotelRoom_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
        }

        protected void dtgOrderRoom_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
        }

        protected void btnState_Click(object sender, EventArgs e)
        {
            try
            {
                int state = int.Parse(ddlState.SelectedValue);
                int orderId = int.Parse(Request["orderId"]);
                _order = _db.Orders.Find(orderId);
                _order.State = (OrderStateEnum)state;
                _db.SaveChanges();
                Notify.ShowMessageSuccess("Lưu trạng thái thành công !", Page);
            }
            catch
            {
                Notify.ShowMessageError("Đã xảy ra lỗi. Vui lòng thử lại !", Page);
            }
        }
    }
}