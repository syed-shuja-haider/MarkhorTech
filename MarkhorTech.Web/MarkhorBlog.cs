using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace MarkhorTech.Web
{
    public class MarkhorBlog
    {
        public string PostTitle { get; set; }
        public string ShortDescription { get; set;}

        public string DetailDescription { get; set; }
        public DateTime DateTime { get; set; }

        public string ImageUrl { get; set; }

        public string PostUrl { get; set; }
        public string UrlSlug { get; set; }

        public List<MarkhorBlog> InitializeData()
        {
            string testURLSlug;
            List<MarkhorBlog> list = new List<MarkhorBlog>();

            MarkhorBlog markhorBlogOne = new MarkhorBlog
            {
                PostTitle = "We're living in the golden age of software development",
                ShortDescription = "With an unprecedented choice of tools, languages, platforms, and architectural styles, developers are creating a wildly inventive, software-defined world",
                DateTime = DateTime.Now,
                ImageUrl = "/Images/Resource/sd11.jpeg"

            };

            markhorBlogOne.DetailDescription= GetPostDescription("Post1");           
            markhorBlogOne.PostUrl = CreateUrl(out testURLSlug, markhorBlogOne.PostTitle);
            markhorBlogOne.UrlSlug = testURLSlug;

            list.Add(markhorBlogOne);

            //*******************************************************************

            MarkhorBlog markhorBlogTwo = new MarkhorBlog
            {
                PostTitle = "Open source continues to shape our world",
                ShortDescription = "For decades open source software has made it possible for us to innovate from operating systems to programming languages. ",
                DetailDescription = "",
                DateTime = DateTime.Now,
                ImageUrl = "/Images/Resource/OpenSource.jpg"
            };

            markhorBlogTwo.DetailDescription = GetPostDescription("Post2");
            markhorBlogTwo.PostUrl = CreateUrl(out testURLSlug, markhorBlogTwo.PostTitle);
            markhorBlogTwo.UrlSlug = testURLSlug;
            list.Add(markhorBlogTwo);

            //*******************************************************************

            MarkhorBlog markhorBlogThree = new MarkhorBlog
            {
                PostTitle = "Software development is business development",
                ShortDescription = "You are transforming how enterprise is run from the software on up—providing data to stakeholders to make better informed decisions",
                DetailDescription = "",
                DateTime = DateTime.Now,
                ImageUrl = "/Images/Resource/SoftwareDevelopment.png"
            };

            markhorBlogThree.DetailDescription = GetPostDescription("Post3");
            markhorBlogThree.PostUrl = CreateUrl(out testURLSlug, markhorBlogThree.PostTitle);
            markhorBlogThree.UrlSlug = testURLSlug;
            list.Add(markhorBlogThree);

            //*******************************************************************

            MarkhorBlog markhorBlogFour = new MarkhorBlog
            {
                PostTitle = "Infrastructure disruption and re-assembly remakes an enterprise",
                ShortDescription = " If you take care of that system, you can generally ensure a long, healthy life for yourself, and the same goes with any enterprise.",
                DetailDescription = "",
                DateTime = DateTime.Now,
                ImageUrl = "/Images/Resource/infrastructure.jpg"
            };

            markhorBlogFour.DetailDescription = GetPostDescription("Post4");
            markhorBlogFour.PostUrl = CreateUrl(out testURLSlug, markhorBlogFour.PostTitle);
            markhorBlogFour.UrlSlug = testURLSlug;
            list.Add(markhorBlogFour);

            //*******************************************************************

            MarkhorBlog markhorBlogFive = new MarkhorBlog
            {
                PostTitle = "Start having your computer think (differently)",
                ShortDescription = "OpenAI (Elon Musk), Watson (IBM), TensorFlow (Google), & CNTK (Microsoft) have given rise to a wealth of excitement around new products & paradigms.",
                DetailDescription = "",
                DateTime = DateTime.Now,
                ImageUrl = "/Images/Resource/start.jpg"
            };

            markhorBlogFive.DetailDescription = GetPostDescription("Post5");
            markhorBlogFive.PostUrl = CreateUrl(out testURLSlug, markhorBlogFive.PostTitle);
            markhorBlogFive.UrlSlug = testURLSlug;
            list.Add(markhorBlogFive);

            //*******************************************************************

            MarkhorBlog markhorBlogSix = new MarkhorBlog
            {
                PostTitle = "Putting the customer first leads to success every time",
                ShortDescription = "You must put the customer front and center as you embark on iterations and new projects; their experience will decide your success.",
                DetailDescription = "",
                DateTime = DateTime.Now,
                ImageUrl = "/Images/Resource/customer.png"
            };

            markhorBlogSix.DetailDescription = GetPostDescription("Post6");
            markhorBlogSix.PostUrl = CreateUrl(out testURLSlug, markhorBlogSix.PostTitle);
            markhorBlogSix.UrlSlug = testURLSlug;
            list.Add(markhorBlogSix);

            return list;
        }
        

        public string GetPostDescription(string path)
        {          
            WebClient webClient = new WebClient();
            StreamReader streamReader = new StreamReader(
                webClient.OpenRead(
                    HttpContext.Current.Server.MapPath(
                        "~/PostFiles/" + path + ".txt")));
            return streamReader.ReadToEnd(); 
        }

        public string CreateUrl(out string UrlSlug, string PostTitle)
        {
            UrlSlug = PostTitle.Replace(" ", "_");
            return "/Blog/Post/" + PostTitle.Replace(" ", "_");
        }

    }
}