using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarkhorTech.Web.Models
{
    public class MarkhorPostViewModel
    {

        public string PostTitle { get; set; }
        public string ShortDescription { get; set; }
        public string DetailDescription { get; set; }
        public DateTime DateTime { get; set; }
        public string ImageUrl { get; set; }

        public string PostUrl { get; set; }

        public string UrlSlug { get; set; }


    }
}