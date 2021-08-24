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
    public partial class EditFeature : System.Web.UI.Page
    {
        private DatPhongKhachSanDbContext _db = new DatPhongKhachSanDbContext();
        private HotelRoomType _hotelRoomType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            chkFeature.DataSource = _db.HotelFeatures.ToList();
            chkFeature.DataTextField = "Name";
            chkFeature.DataValueField = "Id";
            chkFeature.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["roomTypeId"]);
                _hotelRoomType = _db.HotelRoomTypes.Find(id);
                foreach (ListItem li in chkFeature.Items)
                {
                    if (li.Selected)
                    {
                        int idFeature = int.Parse(li.Value);
                        if (_hotelRoomType.HotelFeatures.Where(x => x.Id == idFeature).Count() == 0)
                        {
                            _hotelRoomType.HotelFeatures.Add(_db.HotelFeatures.Find(idFeature));
                        }
                    }
                    else
                    {
                        int idFeature = int.Parse(li.Value);
                        if (_hotelRoomType.HotelFeatures.Where(x => x.Id == idFeature).Count() > 0)
                        {
                            _hotelRoomType.HotelFeatures.Remove(_db.HotelFeatures.Find(idFeature));
                        }
                    }
                }
                _db.SaveChanges();
                Notify.ShowMessageSuccess("Thanh cong !", Page);
            }
            catch
            {
                Notify.ShowMessageError("Loi !", Page);
            }
        }

        protected void chkFeature_DataBound(object sender, EventArgs e)
        {
            int id = int.Parse(Request["roomTypeId"]);
                _hotelRoomType = _db.HotelRoomTypes.Find(id);
            foreach (ListItem li in chkFeature.Items)
            {
                int idFeature = int.Parse(li.Value);
                if (_hotelRoomType.HotelFeatures.Where(x => x.Id == idFeature).Count() > 0)
                {
                    li.Selected = true;
                }
                else
                    li.Selected = false;
            }
        }
    }
}