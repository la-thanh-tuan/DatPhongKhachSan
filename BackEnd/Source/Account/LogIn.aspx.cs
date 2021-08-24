using DAO.Source;
using DAO.Source.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infrastructure;

namespace BackEnd.Source.Account
{
    public partial class LogIn : System.Web.UI.Page
    {
        private DatPhongKhachSanDbContext _db = new DatPhongKhachSanDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (BackEndAuthentication.isLogedIn(_db))
                {
                    String returnUrl = Request.QueryString["ReturnUrl"];
                    if (Request.QueryString["ReturnUrl"] == null)
                        returnUrl = "~/Source/Hotelmanager/ManagerHotel.aspx";
                    Response.Redirect(returnUrl);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Manager manager=_db.Managers.ToList().Where(x=>x.UserName==txtUserName.Text.Trim() && MyEncryption.Decrypt(x.Password) ==txtPassword.Text.Trim()
                && x.Active==true).FirstOrDefault();
            if (manager!=null)
            {
                var ticket = new FormsAuthenticationTicket(
                    1,
                    manager.UserName, 
                    DateTime.Now,
                    DateTime.Now.AddDays(1),
                    chkKeepMeLogIn.Checked,
                    manager.Id.ToString()
                    );
                var encryptedTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                if (ticket.IsPersistent)
                    cookie.Expires = ticket.Expiration;
                cookie.Path = FormsAuthentication.FormsCookiePath;                
                Response.Cookies.Add(cookie);
                String returnUrl = Request.QueryString["ReturnUrl"]; 
                if (Request.QueryString["ReturnUrl"] == null)
                    returnUrl = "~/Source/Hotelmanager/ManagerHotel.aspx"; 
                Response.Redirect(returnUrl);
            }
            else
            {
                pnlLoginError.Visible = true;
            }
        }
    }
}