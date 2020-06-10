using StackOverFlow.Models.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOverFlow.Controllers
{

    public class MyProfileController : Controller
    {
        UsersRepository userrepo = new UsersRepository(new StackOverFlowDbContext());
        // GET: MyProfile
        public ActionResult Index()
        {
            return View();
        }

        // GET: MyProfile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyProfile/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyProfile/Edit/5
        public ActionResult Edit(int? UserId)
        {
            //ViewBag.uid = ((User)Session["User"]).UserId;

            if (UserId == null || UserId.Value == 0)
            {
                UserId = ((User)Session["User"]).UserId;
            }
            if (((User)Session["User"]).Role == "Admin" || ((User)Session["User"]).UserId == UserId)
            {
                var user = userrepo.GetById(UserId.Value);
                CustomUser u = new CustomUser
                {
                    Name = user.Name,
                    Email = user.Email,
                    UserId = user.UserId,
                    Gender = user.Gender,
                    MobileNumber = user.MobileNumber,
                    ImageName = user.ImageName,
                    Role = user.Role,
                    ReputaionPoints=user.ReputaionPoints

                };
                return View(u);
            }
            else
            {
                return RedirectToAction("Edit", "MyProfile",new { UserId = ((User)Session["User"]).UserId });
            }

        }

        // POST: MyProfile/Edit/5
        [HttpPost]
        public ActionResult Edit(CustomUser user)
        {
            try
            {
                string OriginalFileName = "";
                if (user.attachment != null)
                {
                    //Use Namespace called :  System.IO  
                    // string OriginalFileName = Path.GetFileNameWithoutExtension(user.attachment.FileName);

                    //To Get File Extension  
                    string FileExtension = Path.GetExtension(user.attachment.FileName);

                    //Add Current Date To Attached File Name  
                    OriginalFileName = Guid.NewGuid() + "_" + user.UserId + "_" + "profileimage" + FileExtension;

                    //Get Upload path from Web.Config file AppSettings.  
                    string UploadPath = ("C:/Users/radix/source/repos/StackOverFlow/images/").ToString();

                    //Its Create complete path to store in server.  
                    user.ImageName = UploadPath + OriginalFileName;

                    //To copy and save file into server.  
                    user.attachment.SaveAs(user.ImageName);

                }

                User u = userrepo.GetById(user.UserId);

                u.Name = user.Name;
                u.Email = user.Email;
                u.Gender = user.Gender;
                u.MobileNumber = user.MobileNumber;
                if (((User)Session["User"]).Role == "Admin")
                {
                    u.Role = user.Role;
                }



                if (OriginalFileName != "")
                {
                    u.ImageName = OriginalFileName;
                }
                userrepo.Update(u);
                return RedirectToAction("Edit", new { UserId = user.UserId });
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult getSessionValue()
        {
            var UserId = ((User)Session["User"]).UserId;
            return RedirectToAction("Edit", new { UserId = UserId });
        }
        // GET: MyProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyProfile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
