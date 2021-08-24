using DAO.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd.Source.Ajax
{
    public partial class HotelAutoSuggest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           //string a= GetAutoSuggest("0");
        }
        [WebMethod]
        public string GetAutoSuggest(string name)
        {
            DatPhongKhachSanDbContext db = new DatPhongKhachSanDbContext();
           return string.Join(",", db.Hotels.Where(x => x.Name.Contains(name)).ToList())+"a,a,a,a,a";
        }
    }
}