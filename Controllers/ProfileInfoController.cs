using StackOverFlow.Models;
using StackOverFlow.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOverFlow.Controllers
{
    public class ProfileInfoController : Controller
    {
        UsersRepository userrepo = new UsersRepository(new StackOverFlowDbContext());
        QuestionInfoRepository questionInfoRepository = new QuestionInfoRepository(new StackOverFlowDbContext());
        TagsRepository tagsrepository =new TagsRepository(new StackOverFlowDbContext());
        // GET: ProfileInfo
        public ActionResult List()
        {
            return View();
        }

        // GET: ProfileInfo/Details/5
        public ActionResult ProfileInfo(int? UserId)
        {
            if (UserId == null || UserId.Value == 0)
            {
                UserId = ((User)Session["User"]).UserId;
            }

            var user = userrepo.GetById(UserId.Value);
            if (user == null)
            {
                UserId = ((User)Session["User"]).UserId;
                user = userrepo.GetById(UserId.Value);

            }
            List<QuestionInfo> info = questionInfoRepository.GetQuestionList(0, UserId.Value, "");
            CustomUser u = new CustomUser
            {
                Name = user.Name,
                Email = user.Email,
                UserId = user.UserId,
                Gender = user.Gender,
                MobileNumber = user.MobileNumber,
                ImageName = user.ImageName,
                QuestionInfo= info,
                TagList= tagsrepository.GetTagsByUserId(UserId.Value),
                 ReputaionPoints = user.ReputaionPoints
            };
            
            //List<QuestionInfo> info = questionInfoRepository.GetQuestionList(0, UserId, "");
            //info = info.OrderByDescending(x => x.question.ViewCount).Take(5).ToList();
            return View(u);
        }

        // GET: ProfileInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileInfo/Create
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

        // GET: ProfileInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfileInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfileInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfileInfo/Delete/5
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
