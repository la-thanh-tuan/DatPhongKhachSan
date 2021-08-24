using DAO.Source;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackEnd.Source.Account
{
    public partial class usrUserInfo : System.Web.UI.UserControl
    {
        private DatPhongKhachSanDbContext _db = new DatPhongKhachSanDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var userLogin = BackEndAuthentication.GetCurrentUserLogin(_db);
                    litUserName.Text = litUserName2.Text = userLogin.UserName;
                    litEmail.Text = userLogin.Email;
                   // _db.Entry(userLogin).Reference(x => x.Image).Load();
                   if(userLogin.Image!=null)
                    imgAvatar.ImageUrl = imgAvatar2.ImageUrl = userLogin.Image.Url;
                }
                catch
                { }

            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }
    }
}