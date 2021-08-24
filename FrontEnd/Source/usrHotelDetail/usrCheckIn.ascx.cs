using DAO.Source;
using DAO.Source.Model;
using FrontEnd.Source.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd.Source.usrHotelDetail
{
    public partial class usrCheckIn : System.Web.UI.UserControl
    {
        private DatPhongKhachSanDbContext _db = new DatPhongKhachSanDbContext();
        private Hotel _hotel;
        private SearchInput _input;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            int id = int.Parse(Page.RouteData.Values["hotelId"].ToString());
            _hotel = _db.Hotels.Find(id);
            int sId = 0;
            if (int.TryParse(Request["sId"], out sId))
            {
                _input = _db.SearchInputs.Find(sId);
                ngay_den.Text = _input.DateCheckIn.ToString("dd/MM/yyyy");
                ngay_di.Text = _input.DateCheckOut.ToString("dd/MM/yyyy");
                lvRoomDetail.DataSource = _hotel.getListHotelRoomType(_input.DateCheckIn, _input.DateCheckOut);
                lvRoomDetail.DataBind();
            }
            else
            {
                btnOrder.Visible = false;
            }
        }

        protected void kiemtragia_Click(object sender, EventArgs e)
        {
            try
            {
                string CheckInTime = ngay_den.Text;
                if (CheckInTime == "")
                {
                    return;
                }
                string CheckOutTime = ngay_di.Text;
                if (CheckOutTime == "")
                {
                    litError.Text = "Chon ngay tra phong";
                    return;
                }
                SearchInput input;
                int id;
                if (int.TryParse(Request["sId"], out id))
                {
                    input = _db.SearchInputs.Find(id);
                    input.DateCheckIn = DateTime.Parse(CheckInTime, CultureInfo.GetCultureInfo("en-Gb"));
                    input.DateCheckOut = DateTime.Parse(CheckOutTime, CultureInfo.GetCultureInfo("en-Gb"));
                }
                else
                {
                    input = new SearchInput
                    {
                        KeyWord = "",
                        DateCheckIn = DateTime.Parse(CheckInTime, CultureInfo.GetCultureInfo("en-Gb")),
                        DateCheckOut = DateTime.Parse(CheckOutTime, CultureInfo.GetCultureInfo("en-Gb"))
                    };
                    _db.SearchInputs.Add(input);
                    _db.SaveChanges();
                    Response.Redirect("/chi-tiet-khach-san-" + Page.RouteData.Values["hotelId"] + "?sId=" + input.Id);

                }
            }
            catch
            {
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.OrderHotelRoomTypes = new List<OrderHotelRoomType>();
            int sId = int.Parse(Request["sId"]);
            _input = _db.SearchInputs.Find(sId);
            order.StartDate = _input.DateCheckIn;
            order.EndDate = _input.DateCheckOut;
            order.Price = 0;
            order.OrderHotelRoomTypes = new List<OrderHotelRoomType>();
            if (lvRoomDetail.Items.Count > 0)
            {
                foreach (ListViewDataItem it in lvRoomDetail.Items)
                {
                    HiddenField hidRoomTypeId = it.FindControl("hidRoomTypeId") as HiddenField;
                    HotelRoomType htrt = _db.HotelRoomTypes.Find(int.Parse(hidRoomTypeId.Value));
                    DropDownList ddlRoomCount = it.FindControl("ddlRoomCount") as DropDownList;
                    if (int.Parse(ddlRoomCount.SelectedValue) > 0)
                    {
                        Literal litPrice = it.FindControl("litPrice") as Literal;
                        order.Price += int.Parse(ddlRoomCount.SelectedValue) * int.Parse(litPrice.Text.Replace(".",""));

                        OrderHotelRoomType type = new OrderHotelRoomType();
                        type.HotelRoomType = htrt;
                        type.NumOfRoom = int.Parse(ddlRoomCount.SelectedValue);
                        TextBox txtPeople = it.FindControl("txtPeople") as TextBox;
                        int num;
                        if (int.TryParse(txtPeople.Text,out num)&&num>0)
                        {
                            type.NumOfPeople = num;
                        }
                        else
                        {
                            litError.Text = "cần phải nhập số người cho các phòng được chọn !";
                            return;
                        }
                        order.OrderHotelRoomTypes.Add(type);
                    }
                }
            }
            if(order.Price==0)
            {
                litError.Text = "cần chọn ít nhất một phòng !";
                return;
            }
            OrderContact contact = new OrderContact();
            contact.Name = txtName.Text;
            contact.Phone = txtPhone.Text;
            contact.Adress = txtAdress.Text;
            contact.Email = txtEmail.Text;
            contact.BirthDay = order.StartDate;
            order.OrderContact = contact;
            order.OrderDate = DateTime.Now;
            order.State = OrderStateEnum.NEW;
            _db.Orders.Add(order);
            _db.SaveChanges();
            //Response.Redirect("http://google.com.vn");
        }

        protected void lvRoomDetail_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            DropDownList ddlRoomCount = e.Item.FindControl("ddlRoomCount") as DropDownList;
            if (ddlRoomCount != null)
            {
                int sId = int.Parse(Request["sId"]);
                _input = _db.SearchInputs.Find(sId);
                int id = int.Parse(DataBinder.Eval(e.Item.DataItem, "Id").ToString());
                HotelRoomType htrt = _db.HotelRoomTypes.Find(id);
                int max = htrt.MaxPeople - _db.GetNumOfRoomTypeOrder(_input.DateCheckIn,_input.DateCheckOut,htrt.Id);

                for (int i = 0; i < max; i++)
                {
                    ddlRoomCount.Items.Add(new ListItem(i + " Phòng", i.ToString()));
                }
                Literal litPrice = e.Item.FindControl("litPrice") as Literal;
                litPrice.Text =FormatHelper.FormatPrice( htrt.getTotalPrice(_input.DateCheckIn, _input.DateCheckOut).ToString());
            }
        }
    }
}