using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StackOverFlow.Controllers
{
    public class SignInController : Controller
    {
       
        
        public StackOverFlowDbContext se = new StackOverFlowDbContext();
        // GET: SignIn

        [HttpGet]
        public ActionResult SignIn()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(User login, string ReturnUrl)
        {
            if (ReturnUrl!=null &&  ReturnUrl.Contains(",AnswerId"))
            {
                string starturl= ReturnUrl.Split(',')[0];
                string[] tokens = ReturnUrl.Split(',');
                string a = tokens[tokens.Length - 1]; 
                tokens =a.Split(':');
                string aid = tokens[tokens.Length - 1];
                ReturnUrl = starturl + "#" + aid;
            }
            //if (login.Password == "3")
            //{
            //    login.Email = "manali.jain@radixweb.com"; 
            //    login.Password = "3";
            //}
            //else
            //{
            //    login.Email = "rita@test.com";
            //    login.Password = "2";
            //}
            var result = se.Users.FirstOrDefault(x => x.Email.ToLower() == login.Email.ToLower() && x.Password == login.Password);
            if (result != null)
            {
                Session.Add("User", result);
                FormsAuthentication.SetAuthCookie(login.Name, false);
                if(ReturnUrl == null)
                {
                    return Redirect("/Home/Index");
                }
                return Redirect(ReturnUrl);
            }
            else
            {
                return View(login);
            }

        }

        // GET: Login/Details/5
        public ActionResult SignOut()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();

            return Redirect("/Home/Index");
        }
    }
}
