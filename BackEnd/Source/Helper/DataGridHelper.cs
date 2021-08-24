using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BackEnd.Source.Helper
{
    public class DataGridHelper
    {
        public static void SetStyle(DataGrid grd)
        {
            grd.FooterStyle.CssClass = "footer-grd-stdtable";
            grd.HeaderStyle.CssClass = "head-grd-stdtable";
            grd.CssClass = "grd-stdtable";
        }
    }
}