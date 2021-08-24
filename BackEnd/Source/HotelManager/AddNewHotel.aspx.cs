using BackEnd.Source.Account;
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
    public partial class AddNewHotel : System.Web.UI.Page
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
            if(BackEndAuthentication.GetCurrentUserLogin(_db).ManagerPermission.Permission!=Permission.Admin)
            {
                Notify.ShowMessageErrorFromAnotherPage("Bạn không có quyền thêm khách sạn mới !");
                Response.Redirect("ManagerHotel.aspx");
            }
        }
    }
}