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
    public class AnswerInfoRepository : GenericModel<Answer>, IAnswer
    {
        UsersRepository userrepository = null;
        public AnswerInfoRepository(StackOverFlowDbContext db) : base(db)
        {
            userrepository = new UsersRepository(db);

        }

        public Answer GetAnswerDetail(int id)
        {

            Answer a = base.GetById(id);

            Answer adetail = new Answer();
            adetail.QuestionId = a.QuestionId;
            adetail.AnswerId = a.AnswerId;
            adetail.Text = a.Text;

            adetail.Question = new Question();
            adetail.Question.QuestionId = a.Question.QuestionId;//base.context.Questions.FirstOrDefault(x => x.QuestionId == a.QuestionId);
            adetail.Question.Title = a.Question.Title;
            adetail.Question.Description = a.Question.Description;
            adetail.Question.CreatedOn = a.Question.CreatedOn;
            adetail.Question.IsOpen = a.Question.IsOpen;


            return adetail;


        }
        public void UpdateAnswer(Answer answer)
        {
            try
            {
                var a =  this.GetById(answer.AnswerId);
                a.Text = answer.Text;
                //Answer adetail = new Answer
                //{
                //    AnswerId = answer.AnswerId,
                //    Text=answer.Text
                //};
                this.Update(a);
            }
            catch (Exception ex)
            {

            }
        }

        public bool SaveComment(int answerid, string newcomment)
        {
            var a = base.context.AnswersComments;
            if (a != null)
            {
                a.Add(new StackOverFlow.AnswersComment {AnswerId=answerid, Comment= newcomment});
               
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}