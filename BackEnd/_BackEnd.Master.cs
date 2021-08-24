using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackEnd
{
    public partial class _BackEnd : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litNotify.Text = "";
            if(Session["NotifyMsg"]!=null)
            {
                litNotify.Text = Session["NotifyMsg"].ToString();
                Session["NotifyMsg"] = null;
            }
        }
        public void LoadNotify(string text)
        {
            litNotify.Text = text;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
        }
    }
}