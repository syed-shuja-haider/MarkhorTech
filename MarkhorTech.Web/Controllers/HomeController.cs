using MarkhorTech.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MarkhorTech.Web.Controllers
{
    public class HomeController : Controller
    {
        private EmailService _emailService;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult BoardOfDirectors()
        {
            return View();
        }

        //public ActionResult ManagementTeam()
        //{

        //    return View();

        //}

        public ActionResult Testimonial()
        {

            return View();

        }

        public ActionResult CustomSoftwareDevelopment()
        {
            return View();
        }

        //public ActionResult Blog()
        //{
        //    MarkhorBlog markhorBlog = new MarkhorBlog();

        //    List<MarkhorBlog> list = markhorBlog.InitalizePostData1();
        //    List<MarkhorPostViewModel> modelList = new List<MarkhorPostViewModel>();
        //    foreach(var item in list)
        //    {
        //        MarkhorPostViewModel markhorPostViewModel = new MarkhorPostViewModel();
        //        markhorPostViewModel.ShortDescription = item.ShortDescription;
        //        markhorPostViewModel.ImageURL = item.ImageURL;
        //        markhorPostViewModel.PostName = item.PostName;
        //        markhorPostViewModel.UrlSlug = item.UrlSlug;
        //        markhorPostViewModel.PostURL = item.PostURL;

        //        modelList.Add(markhorPostViewModel);

        //    }

        //    return View(modelList);

        //}



        //public ActionResult Post(string UrlSlug)
        //{
        //    MarkhorBlog markhorBlog = new MarkhorBlog();
        //    List<MarkhorBlog> list = markhorBlog.InitalizePostData1();

        //    MarkhorBlog item = list.Where(a => a.UrlSlug == UrlSlug).FirstOrDefault();
        //    MarkhorPostViewModel markhorPostViewModel = new MarkhorPostViewModel();
        //    markhorPostViewModel.PostName = item.PostName;
        //    markhorPostViewModel.ShortDescription = item.ShortDescription;
        //    markhorPostViewModel.UrlSlug = item.UrlSlug;

        //    return View(markhorPostViewModel);
        //}


        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Contact(ContactViewModel contactViewModel)
        {
            try
            {
                _emailService = new EmailService();
                ViewBag.Message = "Your contact page.";
                string body;
                body = string.Format(CreateMessageBody(ConfigurationManager.AppSettings["WebsiteURl"] + "Content/EmailTemplates/UserEmailTemplate.txt"),
                   ConfigurationManager.AppSettings["WebsiteURl"], contactViewModel.Name);
                await _emailService.SendEmailAsync(contactViewModel, body,
                   "Thank you to contact us - Markhor Technologies", contactViewModel.Email);
                body = string.Format(CreateMessageBody(ConfigurationManager.AppSettings["WebsiteURl"] + "Content/EmailTemplates/AdminEmailTemplate.txt"),
                   ConfigurationManager.AppSettings["WebsiteURl"], contactViewModel.Name, contactViewModel.Email, contactViewModel.Phone,
                   contactViewModel.Subject, contactViewModel.Message);
                await _emailService.SendEmailAsync(contactViewModel, body,
                   "Client Message from Website", ConfigurationManager.AppSettings["email"]);
                return Json(new
                {
                    success = true
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    errors = "Unable to Send Message. Please try again later."
                });
            }

        }

        public string CreateMessageBody(string url)
        {
            WebClient webClient = new WebClient();
            Stream stream = webClient.OpenRead(url);
            StreamReader streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }

        public ActionResult Career()
        {
            MarkhorBlog markhorBlog = new MarkhorBlog();
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

            return View();
        }
    }
}