using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace BackEnd.Source.Helper
{
    public class Notify
    {
        public static void ShowMessageSuccess(string messageSuccess, Page page)
        {
            string msg = string.Format("<div class='notibar msgsuccess'><a class='close'></a><p>{0}</p></div>", messageSuccess);
            if (page.Controls[0] is _BackEnd)
                ((_BackEnd)page.Controls[0]).LoadNotify(msg);
            else
                ((_PopUp)page.Controls[0]).LoadNotify(msg);
        }
        public static void ShowMessageError(string messageError, Page page)
        {
            string msg = string.Format("<div class='notibar msgerror'><a class='close'></a><p>{0}</p></div>", messageError);
            if (page.Controls[0] is _BackEnd)
                ((_BackEnd)page.Controls[0]).LoadNotify(msg);
            else
                ((_PopUp)page.Controls[0]).LoadNotify(msg);
        }
        public static void ShowMessageSuccessFromAnotherPage(string messageSuccess)
        {
            string msg = string.Format("<div class='notibar msgsuccess'><a class='close'></a><p>{0}</p></div>", messageSuccess);
            HttpContext.Current.Session["NotifyMsg"] = msg;
        }
        public static void ShowMessageErrorFromAnotherPage(string messageError)
        {
            string msg = string.Format("<div class='notibar msgerror'><a class='close'></a><p>{0}</p></div>", messageError);
            HttpContext.Current.Session["NotifyMsg"] = msg;
        }
    }
}