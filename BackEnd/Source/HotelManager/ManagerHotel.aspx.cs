using BackEnd.Source.Helper;
using DAO.Source;
using DAO.Source.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackEnd.Source.HotelManager
{
    public partial class ManagerHotel : System.Web.UI.Page
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
            DataGridHotel.DataSource = _db.Hotels.ToList();
            DataGridHotel.DataBind();
            DataGridHelper.SetStyle(DataGridHotel);
            //goi y ten khach san
            StringBuilder names = new StringBuilder("");
            foreach (Hotel dr in _db.Hotels.ToList())
            {
                names.Append(dr.Name+",");
            }
            HiddenFieldHotelNames.Value = names.ToString();                        
        }
        protected void btnAddNewHotel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Source/HotelManager/AddNewHotel.aspx");
        }

        protected void DataGridHotel_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "save")
            {
                string name = (e.Item.FindControl("TextBoxHotelName") as TextBox).Text;
                string address = (e.Item.FindControl("TextBoxAddress") as TextBox).Text;
                int hotelId =int.Parse( e.CommandArgument.ToString());
                Hotel hotel = _db.Hotels.Where(x=>x.Id==hotelId).First();
                hotel.Name=name.Trim();
                hotel.Adress= address.Trim();
                try
                {
                    _db.SaveChanges();
                    LoadData();
                    Notify.ShowMessageSuccess("Đã lưu thành công !", Page);
                }
                catch
                {
                    Notify.ShowMessageError("Đã xảy ra lỗi !", Page);
                }
            }
            else if (e.CommandName == "delete")
            {
                DataGridHotel.CurrentPageIndex = 0;
                int hotelId =int.Parse( e.CommandArgument.ToString());
                Hotel hotel = _db.Hotels.Where(x => x.Id == hotelId).First();
                try
                {
                    _db.Hotels.Remove(hotel);
                    _db.SaveChanges();
                    LoadData();
                    Notify.ShowMessageSuccess("Đã xóa thành công !", Page);
                }
                catch { }
            }
        }

        protected void DataGridHotel_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DataGridHotel.CurrentPageIndex = e.NewPageIndex;
            DataGridHotel.DataSource = _db.Hotels.ToList();
            DataGridHotel.DataBind();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string name = TextBoxHotelName.Text;
            int star =int.Parse( DropDownListStar.SelectedValue);
            DataGridHotel.DataSource = _db.Hotels.Where(x=>(name.Length==0 || x.Name.Contains(name)) &&(star==0 || x.Star==star)).ToList();
            DataGridHotel.CurrentPageIndex = 0;
            DataGridHotel.DataBind();
        }

        protected void DataGridHotel_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            HyperLink lnkHotelAvata = e.Item.FindControl("lnkHotelAvata") as HyperLink;
            if(lnkHotelAvata!=null)
            {
                lnkHotelAvata.ImageUrl = (HotelImage)DataBinder.Eval(e.Item.DataItem, "Avatar") == null ? "" : ((HotelImage)DataBinder.Eval(e.Item.DataItem, "Avatar")).Url;
                if (lnkHotelAvata.ImageUrl == "")
                    lnkHotelAvata.Text = "Edit";
            }
        }
    }
}