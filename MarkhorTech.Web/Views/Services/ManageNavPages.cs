using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarkhorTech.Web.Views.Services
{
    public static class ManageNavPages
    {

        public static string ActivePageKey => "ActivePage";

        public static string CustomSoftwareDevelopment => "CustomSoftwareDevelopment";

        public static string WebDevelopment => "WebDevelopment";

        public static string MobileAppDevelopment => "MobileAppDevelopment";

        public static string DtabaseDevelpment => "DatabaseDevelopment";

        public static string POSSolutions => "POSSolutions";
        public static string ERPSolutions => "ERPSolutions";
        public static string CRMSolutions => "CRMSolutions";


        public static string MobileAppDevelopmentNavClass(ViewContext viewContext) => PageNavClass(viewContext, MobileAppDevelopment); 

        public static string CustomSoftwareDevelopmentNavClass(ViewContext viewContext) => PageNavClass(viewContext, CustomSoftwareDevelopment);

        public static string WebDevelopmentNavClass(ViewContext viewContext) => PageNavClass(viewContext, WebDevelopment);

        public static string DatabaseDevelopmentNavClass(ViewContext viewContext) => PageNavClass(viewContext, DtabaseDevelpment);

        public static string POSSolutionsNavClass(ViewContext viewContext) => PageNavClass(viewContext, POSSolutions);
        public static string ERPSolutionsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ERPSolutions);
        public static string CRMSolutionsNavClass(ViewContext viewContext) => PageNavClass(viewContext, CRMSolutions);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "background:#f7941e; color: #fff;" : null;
        }

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}