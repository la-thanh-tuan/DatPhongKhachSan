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
    public partial class ManagerFeature : System.Web.UI.Page
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
            dtgFeature.DataSource = _db.HotelFeatures.ToList();
            DataGridHelper.SetStyle(dtgFeature);
            dtgFeature.DataBind();
        }

        protected void dtgFeature_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dtgFeature.CurrentPageIndex = e.NewPageIndex;
            LoadData();
        }

        protected void dtgFeature_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            int id = 0;
            if(e.CommandName=="save")
            {
                try
                {
                    id = int.Parse(e.CommandArgument.ToString());
                    HotelFeature hf = _db.HotelFeatures.Find(id);
                    hf.Name = ((TextBox)e.Item.FindControl("txtName")).Text;
                    _db.SaveChanges();
                    Notify.ShowMessageSuccess("Lưu thành công !", Page);
                }
                catch
                {
                    Notify.ShowMessageError("đã xảy ra lỗi !", Page);
                }
            }
            else if(e.CommandName=="delete")
            {
                try
                {
                    id = int.Parse(e.CommandArgument.ToString());
                    HotelFeature hf = _db.HotelFeatures.Find(id);
                    _db.HotelFeatures.Remove(hf);
                    _db.SaveChanges();
                    Notify.ShowMessageSuccess("Xóa thành công !", Page);
                }
                catch
                {
                    Notify.ShowMessageError("đã xảy ra lỗi !", Page);
                }
            }
            else if(e.CommandName=="add")
            {
                try
                {
                    HotelFeature hf = new HotelFeature();
                    hf.Name = ((TextBox)e.Item.FindControl("txtName")).Text;
                    _db.HotelFeatures.Add(hf);
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

        protected void dtgFeature_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            ImageButton imbtDelete = e.Item.FindControl("imbtDelete") as ImageButton;
            if(imbtDelete!=null)
            {
                imbtDelete.OnClientClick = "javascript : return confirm('Bạn có chắc chắn muốn xóa  " + DataBinder.Eval(e.Item.DataItem, "Name") + "không ?')";
            }
        }
    }
}