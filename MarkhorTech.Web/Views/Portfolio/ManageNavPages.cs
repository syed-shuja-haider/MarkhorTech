using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarkhorTech.Web.Views.Portfolio
{
    public static class ManageNavPages
    {
        public static string ActivePageKey => "ActivePage";

        public static string MovingTrend => "MovingTrend";
        public static string EdgeTours => "EdgeTours";
        public static string MultiSmsSender => "MultiSmsSender";
        public static string PursaDrive => "PursaDrive";

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
        public static string MovingTrendNavClass(ViewContext viewContext) => PageNavClass(viewContext, MovingTrend);
        public static string EdgeToursNavClass(ViewContext viewContext) => PageNavClass(viewContext, EdgeTours);
        public static string MultiSmsSenderNavClass(ViewContext viewContext) => PageNavClass(viewContext, MultiSmsSender);
        public static string PursaDriveNavClass(ViewContext viewContext) => PageNavClass(viewContext, PursaDrive);
        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "background:#f7941e; color: #fff;" : null;
        }
    }
}