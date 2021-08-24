using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace FrontEnd
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            //settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
            routes.MapPageRoute("HotelDetail", "chi-tiet-khach-san-{hotelId}", "~/Source/HotelDetail.aspx");
            routes.MapPageRoute("HotelRoot", "khach-san", "~/Source/HotelList.aspx");
            routes.MapPageRoute("Root", "", "~/Source/Home.aspx");
            routes.MapPageRoute("GioiThieu", "gioi-thieu", "~/Source/Home.aspx");
            routes.MapPageRoute("LienHe", "lien-he", "~/Source/Home.aspx");
            routes.MapPageRoute("Search", "tim-kiem", "~/Source/HotelResult.aspx");
        }
    }
}
