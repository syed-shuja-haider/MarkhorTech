using MarkhorTech.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarkhorTech.Web.Controllers
{
    public class BlogController : Controller
    {

        public ActionResult Post(string UrlSlug)
        {
            MarkhorBlog markhorBlog = new MarkhorBlog();
            List<MarkhorBlog> list = markhorBlog.InitializeData();

            MarkhorBlog item = list.Where(a => a.UrlSlug == UrlSlug).FirstOrDefault();

            MarkhorPostViewModel markhorPostViewModel = new MarkhorPostViewModel();
            markhorPostViewModel.PostTitle = item.PostTitle;
            markhorPostViewModel.ShortDescription = item.ShortDescription;
            markhorPostViewModel.DetailDescription = item.DetailDescription;
            markhorPostViewModel.ImageUrl = item.ImageUrl;
            markhorPostViewModel.DateTime = item.DateTime;
            markhorPostViewModel.PostUrl = item.PostUrl;

            List<MarkhorBlog> listOfPosts = markhorBlog.InitializeData().OrderBy(x => Guid.NewGuid()).Take(3).ToList();
            List<MarkhorPostViewModel> modelList = new List<MarkhorPostViewModel>();
            foreach (var post in listOfPosts)
            {
                MarkhorPostViewModel postViewModel = new MarkhorPostViewModel();
                postViewModel.PostTitle = post.PostTitle;
                postViewModel.ShortDescription = post.ShortDescription;
                postViewModel.DetailDescription = post.DetailDescription;
                postViewModel.ImageUrl = post.ImageUrl;
                postViewModel.DateTime = post.DateTime;
                postViewModel.PostUrl = post.PostUrl;
                modelList.Add(postViewModel);
            }
            ViewData["TopPosts"] = modelList;

            return View(markhorPostViewModel);
        }

        public ActionResult Blog()
        {
            MarkhorBlog markhorBlog = new MarkhorBlog();
            List<MarkhorBlog> list = markhorBlog.InitializeData();
            List<MarkhorPostViewModel> modelList = new List<MarkhorPostViewModel>();
            foreach (var item in list)
            {
                MarkhorPostViewModel markhorPostViewModel = new MarkhorPostViewModel();
                markhorPostViewModel.PostTitle = item.PostTitle;
                markhorPostViewModel.ShortDescription = item.ShortDescription;
                markhorPostViewModel.DetailDescription = item.DetailDescription;
                markhorPostViewModel.ImageUrl = item.ImageUrl;
                markhorPostViewModel.DateTime = item.DateTime;
                markhorPostViewModel.PostUrl = item.PostUrl;
                modelList.Add(markhorPostViewModel);
            }
            return View(modelList);
        }

    }
}