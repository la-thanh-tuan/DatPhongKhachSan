using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackEnd
{
    public partial class _PopUp : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litNotify.Text = "";
        }

        internal void LoadNotify(string text)
        {
            litNotify.Text = text;
        }
    }
}