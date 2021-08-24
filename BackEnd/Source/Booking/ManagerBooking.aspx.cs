using BackEnd.Source.Account;
using BackEnd.Source.Helper;
using DAO.Source;
using DAO.Source.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackEnd.Source.Booking
{
    public partial class ManagerBooking : System.Web.UI.Page
    {
        private DatPhongKhachSanDbContext _db = new DatPhongKhachSanDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
                DataGridHelper.SetStyle(dtgOrder);
            }
        }

        private void LoadData()
        {
            dtgOrder.DataSource = _db.GetListOrder(BackEndAuthentication.GetCurrentUserLogin(_db)).OrderByDescending(x=>x.Id).ToList();
            dtgOrder.DataBind();
        }
        protected void dtgOrder_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            Label lblState = e.Item.FindControl("lblState") as Label;
            if (lblState != null)
            {
                OrderStateEnum state = (OrderStateEnum)DataBinder.Eval(e.Item.DataItem, "State");
                if(state==OrderStateEnum.NEW)
                {
                    lblState.Text = "Đơn hàng mới";
                    lblState.ForeColor = Color.Green;
                }
                else if (state ==OrderStateEnum.PROCESSING)
                {
                    lblState.Text = "Đơn hàng đang xử lí";
                    lblState.ForeColor = Color.Blue;
                }
                else if (state ==OrderStateEnum.CANCEL)
                {
                    lblState.Text = "Đơn hàng huỷ";
                    lblState.ForeColor = Color.Red;
                }
                else if (state == OrderStateEnum.COMPLETE)
                {
                    lblState.Text = "Đơn hàng đã hoàn thành";
                    lblState.ForeColor = Color.HotPink;
                }
            }
        }

        protected void dtgOrder_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if(e.CommandName=="delete")
            {
                try
                {
                    int orderId = int.Parse(e.CommandArgument.ToString());
                    _db.Orders.Remove(_db.Orders.Find(orderId));
                    _db.SaveChanges();
                    Notify.ShowMessageSuccess("Thanh cong",Page);
                    LoadData();
                }
                catch
                {
                    Notify.ShowMessageError("Loi", Page);
                }
                
            }
        }

        protected void dtgOrder_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dtgOrder.CurrentPageIndex = e.NewPageIndex;
            LoadData();
        }
    }
}