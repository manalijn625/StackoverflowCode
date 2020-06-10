using StackOverFlow.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOverFlow.Controllers
{
    public class AnswerInfoController : Controller
    {
        AnswerInfoRepository answerInfoRepository = new AnswerInfoRepository(new StackOverFlowDbContext());

        [HttpGet]
        public ActionResult AnswerInfoEdit(int id)
        {
            Answer ansdetail = answerInfoRepository.GetAnswerDetail(id);
            return View(ansdetail);
        }
        [HttpPost]
        public ActionResult AnswerInfoEdit(Answer adetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    answerInfoRepository.UpdateAnswer(adetail);
                   // return view("/QuestionDetail", new { id = adetail.QuestionId });
                    return RedirectToAction("QuestionDetail", "QuestionInfo", new { id = adetail.QuestionId });
                }
                else
                {
                    return View();
                }

               
            }
            catch (Exception ex)
            {
                ex.ToString();
                return View();
            }
        }

        public ActionResult SaveComment(CommentPayload data)
        {
            answerInfoRepository.SaveComment(data.AnswerId, data.NewComment);

            return new JsonResult { Data = new { status = true } };
        }
        // GET: AnswerInfo
        public ActionResult Index()
        {
            return View();
        }

        // GET: AnswerInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnswerInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnswerInfo/Create
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

        // GET: AnswerInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnswerInfo/Edit/5
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

        // GET: AnswerInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnswerInfo/Delete/5
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
    public class CommentPayload
    {
        public int AnswerId { get; set; }
        public string NewComment { get; set; }

    }
}
