using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarkhorTech.Web.Views.Products
{
    public static class ManageNavPages
    {

        public static string ActivePageKey => "ActivePage";

        public static string TourAndTravelManagement => "TourAndTravelManagement";

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;

        public static string TourAndTravelManagementNavClass(ViewContext viewContext) => PageNavClass(viewContext, TourAndTravelManagement);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "background:#f7941e; color: #fff;" : null;
        }
    }
}