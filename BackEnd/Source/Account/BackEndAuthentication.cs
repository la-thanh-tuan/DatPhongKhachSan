using DAO.Source;
using DAO.Source.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BackEnd.Source.Account
{
    public class BackEndAuthentication
    {
        public static Manager GetCurrentUserLogin(DatPhongKhachSanDbContext db)
        {
            try
            {
                var formIdentity = (FormsIdentity)HttpContext.Current.User.Identity;
                int id = Convert.ToInt32(formIdentity.Ticket.UserData);
                var user = db.Managers.Where(x => x.Id == id).First();
                return user;
            }
            catch
            {
                FormsAuthentication.SignOut();
                HttpContext.Current.Response.Redirect("~/Source/Account/Login.aspx");
                return null;
            }
        }
        public static bool isLogedIn(DatPhongKhachSanDbContext db)
        {
            try
            {
                var formIdentity = (FormsIdentity)HttpContext.Current.User.Identity;
                int id = Convert.ToInt32(formIdentity.Ticket.UserData);
                var user = db.Managers.Where(x => x.Id == id).First();
                if (user != null)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}