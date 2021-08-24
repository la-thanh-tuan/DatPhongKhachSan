using BackEnd.Source.Helper;
using DAO.Source;
using DAO.Source.Model;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackEnd.Source.Account
{
    public partial class EditProfile : System.Web.UI.Page
    {
        private DatPhongKhachSanDbContext _db = new DatPhongKhachSanDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Manager mn = BackEndAuthentication.GetCurrentUserLogin(_db);
                    lblUserName.Text = lblUserName1.Text = mn.UserName;
                    imgAvatar.ImageUrl = mn.Image.Url;
                }
                catch { }
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                Manager mn = BackEndAuthentication.GetCurrentUserLogin(_db);
                if(fileAvatar.PostedFile!=null && fileAvatar.PostedFile.ContentLength>0)
                {
                    fileAvatar.PostedFile.SaveAs(Server.MapPath("/Images/HotelImages/"+fileAvatar.PostedFile.FileName));
                    HotelImage hi=new HotelImage{Url="/Images/HotelImages/"+fileAvatar.PostedFile.FileName};
                    _db.HotelImages.Add(hi);
                    _db.SaveChanges();
                    mn.Image = hi;
                    _db.SaveChanges();
                    Response.Redirect(Request.Url.ToString());
                    Notify.ShowMessageSuccess("Lưu thành công !", Page);
                }
            }
            catch
            {
                Notify.ShowMessageError("đã xảy ra lỗi !", Page);
            }
            
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            try
            {
                Manager mn = BackEndAuthentication.GetCurrentUserLogin(_db);
                if(txtOldPassword.Text.Length==0)
                {
                    Notify.ShowMessageError("Nhập vào mật khẩu cũ !", Page);
                }
                if (txtNewPassword.Text.Length==0 || txtNewPassword.Text != txtNewPassword1.Text)
                {
                    Notify.ShowMessageError("Mật khẩu mới không khớp !", Page);
                }
                if (MyEncryption.Decrypt(mn.Password) == txtOldPassword.Text)
                {
                    mn.Password = MyEncryption.Encrypt(txtNewPassword.Text);
                    
                    _db.SaveChanges();
                    Notify.ShowMessageSuccess("Thay đổi mật khẩu thành công !", Page);
                }
                else
                {
                    Notify.ShowMessageError("Sai mật khẩu không khớp !", Page);
                }
            }
            catch
            {
                Notify.ShowMessageError("đã xảy ra lỗi !", Page);
            }
            
        }
    }
}