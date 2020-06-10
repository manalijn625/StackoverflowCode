using StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverFlow.Models.Repository;
using System.Runtime.InteropServices;

namespace StackOverFlow.Controllers
{
    public class QuestionInfoController : Controller
    {
        QuestionInfoRepository questionInfoRepository = new QuestionInfoRepository(new StackOverFlowDbContext());
        // GET: StackInfo
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult QuestionInfoEdit(int id)
        {

            //ViewBag.UserList = questionInfoRepository.context.Users.ToList();
            //// id = 10001;
            //TempData["QuestionId"] = id;
            QuestionInfo info = questionInfoRepository.GetQuestionDetail(id);

            //info.Answers = info.Answers == null ? new List<Answer>() : info.Answers;

            //Question q = questionInfoRepository.GetById(id);
            //q.ViewCount = q.ViewCount + 1;
            //questionInfoRepository.Update(q);

            //  TempData["QuestionInfo"] = info;
            string tagvalue = "";
            if(info.Tags!=null)
                {
                foreach (var item in info.Tags)
                {
                    tagvalue += item.TagDescription + ",";

                }
            }
            info.CommaSeperatedTags = tagvalue;
            return View(info);
        }
        [HttpPost]
        public ActionResult QuestionInfoEdit(QuestionInfo quesinfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    quesinfo.CurrentUser = (User)Session["User"];
                    questionInfoRepository.Update(quesinfo);
                    return RedirectToAction("QuestionDetail", new { id = quesinfo.question.QuestionId });
                }
                else
                {
                    return  View(quesinfo);
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
                return View();
            }
        }

        


        [HttpGet]
        public ActionResult AskQuestion()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AskQuestion(QuestionInfo quesinfo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //if (string.IsNullOrEmpty(quesinfo.CommaSeperatedTags))
                    //{
                    //    return View(quesinfo);
                    //}
                    quesinfo.CurrentUser = (User)Session["User"];
                    questionInfoRepository.Create(quesinfo);
                    return RedirectToAction("QuestionList",0);
                }
                else
                {
                    return View(quesinfo);
                }


            }
            catch (Exception ex)
            {
                ex.ToString();
                return View();
            }
        }

        [HttpGet]
        public ActionResult QuestionDetail(int id)
        {
            
            ViewBag.UserList = questionInfoRepository.context.Users.ToList();
            // id = 10001;
            TempData["QuestionId"] = id;
            QuestionInfo info = questionInfoRepository.GetQuestionDetail(id);

            info.Answers = info.Answers == null ? new List<Answer>() : info.Answers;
            
            Question q =  questionInfoRepository.GetById(id);
            q.ViewCount = q.ViewCount + 1;
            questionInfoRepository.Update(q);

            //  TempData["QuestionInfo"] = info;
            return View(info);
        }


        [HttpPost]
        public ActionResult QuestionDetail(QuestionInfo quesinfo)
        {
            if (string.IsNullOrWhiteSpace(quesinfo.NewAnswer))
            {
                return RedirectToAction("QuestionDetail", quesinfo.QuestionId);
            }
            else
            {
                //ViewBag["UserList"] = questionInfoRepository.context.Users.ToList();
                quesinfo.QuestionId = Convert.ToInt32(TempData["QuestionId"].ToString());
                QuestionInfo sessionQuestionInfo = (QuestionInfo)TempData["QuestionInfo"];
                quesinfo.UserId = ((User)Session["User"]).UserId;
                questionInfoRepository.SubmitAnswer(quesinfo);


                var qInfoUpdated =  questionInfoRepository.GetQuestionDetail(quesinfo.QuestionId);

                var email = qInfoUpdated.QuestionUser.Email;
                EmailInfo einfo = new EmailInfo();
                einfo.SendEmail(email, "Received answer","You have received on answer");
                return RedirectToAction("QuestionDetail", quesinfo.QuestionId);
            }
        }

        [HttpGet]
        public ActionResult QuestionList(int? TagId, int? UserId, string searchvalue = "")
        {
           
            List<QuestionInfo> info = questionInfoRepository.GetQuestionList(TagId == null ? 0: TagId.Value, UserId == null ? 0 : UserId.Value, searchvalue == null ? "" : searchvalue);
            return View(info);
        }
        [HttpGet]
        public ActionResult QuestionListByUSer()
        {
            var UserId = ((User)Session["User"]).UserId;
            //List<QuestionInfo> info = questionInfoRepository.GetQuestionListByUser(UserId);
            return RedirectToAction("QuestionList", new { TagId=0,UserId= UserId });
        }

        public JsonResult UpdateVote(VotePayload data)
        {
            int CurrentUser = ((User)Session["User"]).UserId;
            bool ustatus = questionInfoRepository.UpdateVote(data.AnswerId, data.Type, CurrentUser);

            return new JsonResult { Data = new { status = ustatus } };
        }


    }

    public class VotePayload
    {
       
        public int AnswerId { get; set; }
        public string Type { get; set; }


    }

}

