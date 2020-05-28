using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackOverFlow.Models.IRepository;
using System.Data.Entity;
using StackOverFlow.Models.Repository;
using System.Web.Mvc;

namespace StackOverFlow.Models.Repository
{
    public class QuestionInfoRepository : GenericModel<Question>, IQuestionInfo
    {
        UsersRepository userrepository = null;
        
        public QuestionInfoRepository(StackOverFlowDbContext db) : base(db)
        {
            userrepository = new UsersRepository(db);

        }

        public void Create(Models.QuestionInfo questioninfo)
        {
            try
            {
                //var uid = se.Users.FirstOrDefault(x => x.Name.ToLower() == User.Identity.Name.ToLower());
                Question question = new Question();

                question.UserId = questioninfo.CurrentUser.UserId;
                question.Title = questioninfo.Title;
                question.Description = questioninfo.Description;
                question.CreatedOn = DateTime.Now;
                question.UpdatedOn = DateTime.Now;
                question.ViewCount = 0;
                question.IsOpen = true;

                string[] UITags = questioninfo.CommaSeperatedTags.Split(',');

                List<TagMaster> tagsMasters = context.TagMasters.ToList();

                List<TagMaster> newItems = new List<TagMaster>();
                List<TagMaster> existingTags = new List<TagMaster>();



                List<TagQuestion> qTags = new List<TagQuestion>();



                foreach (var item in UITags)
                {
                    if (tagsMasters.Any(x => x.TagDescription == item.Trim()))
                    {
                        TagMaster T = tagsMasters.FirstOrDefault(x => x.TagDescription == item.Trim());

                        existingTags.Add(T);
                        qTags.Add(new TagQuestion { TagId = T.TagId });
                    }
                    else
                    {
                        TagMaster newTag = new TagMaster { TagDescription = item.Trim() };
                        newItems.Add(newTag);
                    }
                }
                context.TagMasters.AddRange(newItems);

                context.SaveChanges();

                foreach (var item in newItems)
                {
                    qTags.Add(new TagQuestion { TagId = item.TagId });
                }

                question.TagQuestions = qTags;
                context.Questions.Add(question);


                // context.TagQuestions.AddRange(qTags);

                context.SaveChanges();
                // return RedirectToAction("List");


            }
            catch (Exception ex)
            {
                ex.ToString();

            }
        }


        public Models.QuestionInfo GetQuestionDetail(int id)
        {

            Question q = base.GetById(id);
            Models.QuestionInfo qInfo = new QuestionInfo { question = q, QuestionUser = userrepository.GetById(q.UserId) };
            if (q.TagQuestions.Any())
            {
                IEnumerable<TagQuestion> tq = q.TagQuestions.ToList();
                qInfo.Tags = new List<QuestionTag>();
                foreach (var item in tq)
                {
                    qInfo.Tags.Add(new QuestionTag { TagId = item.TagId, TagDescription = item.TagMaster.TagDescription });
                }

                
               
               
            }
            qInfo.QuestionId = q.QuestionId;
            qInfo.Answers = q.Answers.ToList();
            qInfo.UserName = q.User.Name;
            qInfo.Title = q.Title;
            qInfo.ViewCount = (int)q.ViewCount;

            qInfo.QuestionVotes = qInfo.Answers.Sum(x => x.UpDownVote.Value);
            return qInfo;


        }

        public void SubmitAnswer(Models.QuestionInfo questioninfo)
        {
            Answer a = new Answer();
            a.Text = questioninfo.NewAnswer;
            a.AnswerByUser = questioninfo.UserId;
            a.AnsweredOn = DateTime.Now;
            a.QuestionId = questioninfo.QuestionId;
            a.UpDownVote = 0;
            base.context.Answers.Add(a);
            base.context.SaveChanges();



        }
       
        public List<Models.QuestionInfo> GetQuestionList(int TagId,int UserId,string SearchValue)
        {
            List<Models.QuestionInfo> infoList = new List<QuestionInfo>();
            List<Question> qList ;
            List<Question> allquestion = base.GetAll().ToList();
            if (TagId != 0)
            {
                qList = allquestion.Where(x => x.TagQuestions != null && x.TagQuestions.Any(y => y.TagId == TagId)).ToList();
            }
            else
            {
                qList = allquestion;
            }

            if (UserId != 0)
            {
                qList = qList.Where(x => x.UserId == UserId).ToList();
            }
            if (SearchValue != "")
            {
                qList = allquestion.Where(x => x.Title.Contains(SearchValue) || x.Description.Contains(SearchValue) || (x.TagQuestions != null && x.TagQuestions.Any(y => y.TagId == this.GetTagId(SearchValue)))).ToList();
            }
           

            foreach (var q in qList)
            {
                infoList.Add(GetQuestionDetail(q.QuestionId));
            }


            return infoList;


        }

        public int GetTagId(string description)
        {
            var a = context.TagMasters.FirstOrDefault(x => x.TagDescription.ToLower() == description.ToLower());
            if (a != null)
            {
                return a.TagId;
            }
            else
            {
                return 0;
            }
        }

        public Boolean UpdateVote(int id , string vote)
        {
            var a = base.context.Answers.FirstOrDefault(x => x.AnswerId == id);
            if (a != null)
            {
                a.UpDownVote = vote == "up" ? a.UpDownVote + 1 : a.UpDownVote - 1;
                context.Entry(a).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }  
        }


        //public List<Models.QuestionInfo> GetQuestionListByUser(int UserId)
        //{
        //    List<Models.QuestionInfo> infoList = new List<QuestionInfo>();
        //    List<Question> qList;

        //    qList = base.GetAll().Where(x => x.UserId == UserId).ToList();
        //    foreach (var q in qList)
        //    {
        //        infoList.Add(GetQuestionDetail(q.QuestionId));
        //    }
        //    return infoList;


        //}
    }
}