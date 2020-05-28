using StackOverFlow.Models;
using StackOverFlow.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOverFlow.Controllers
{
    
    public class HomeController : Controller
    {
        QuestionInfoRepository questionInfoRepository = new QuestionInfoRepository(new StackOverFlowDbContext());
        TagsRepository tagsrepository = new TagsRepository(new StackOverFlowDbContext());
        UsersRepository userReporsitory = new UsersRepository(new StackOverFlowDbContext());
        [Authorize]
        public ActionResult Index()
        {
            TopInfo t = new TopInfo();
            ViewData["Uname"] = User.Identity.Name;
            //List<QuestionInfo> qinfo;
            t.Questions = questionInfoRepository.GetQuestionList(0,0,"");
            t.Questions = t.Questions.OrderByDescending(x=>x.question.ViewCount).Take(5).ToList();

            t.Tags = tagsrepository.TopTags();

            
            t.Users = userReporsitory.GetTopUsers();




            return View(t);
            
        }

       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}