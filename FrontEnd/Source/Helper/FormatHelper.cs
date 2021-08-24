using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace FrontEnd.Source.Helper
{
    public class FormatHelper
    {
        public static string FormatPrice(object price)
        {
            try
            {
                if (Convert.ToDecimal(price) == 0) return "0";
                return String.Format(new CultureInfo("vi-VN"), "{0:0,##}", Convert.ToDecimal(price));
            }
            catch
            {
                return "0";
            }
        }
    }
}