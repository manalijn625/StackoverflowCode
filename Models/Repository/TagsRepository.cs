using StackOverFlow.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackOverFlow.Models.Repository;


namespace StackOverFlow.Models.Repository
{
    public class TagsRepository : GenericModel<TagMaster>, ITag
    {
        public TagsRepository(StackOverFlowDbContext db) : base(db)
        {

        }
        public override IEnumerable<TagMaster> GetAll()
        {
            return context.TagMasters.ToList();
        }

      public  List<Models.QuestionTag> GetTagsByUserId(int UserId)
        {


            List<Models.QuestionTag> a = new List<QuestionTag>();
            List<Question> qList = context.Questions.Where(x => x.UserId == UserId).ToList();

            foreach (var item in qList)
            {
                List<TagQuestion> qTags = context.TagQuestions.Where(x => x.QuestionId == item.QuestionId).ToList();

                foreach (var tq in qTags)
                {
                    if (a.Any(x => x.TagId == tq.TagId))
                    {
                        a.FirstOrDefault(x => x.TagId == tq.TagId).Appearance += 1;
                    }
                    else
                    {
                        Models.QuestionTag qtag = new QuestionTag
                        {
                            TagId = tq.TagId,
                            TagDescription = context.TagMasters.FirstOrDefault(x => x.TagId == tq.TagId).TagDescription,
                            Appearance = 1
                        };

                        a.Add(qtag);
                    }
                }
               
                   
            }


           a= a.OrderByDescending(x => x.Appearance).Take(5).ToList();

            return a;
        }

        public List<Models.QuestionTag> TopTags()
        {


            List<Models.QuestionTag> a = new List<QuestionTag>();
            List<Question> qList = context.Questions.ToList();

            foreach (var item in qList)
            {
                List<TagQuestion> qTags = context.TagQuestions.Where(x => x.QuestionId == item.QuestionId).ToList();

                foreach (var tq in qTags)
                {
                    if (a.Any(x => x.TagId == tq.TagId))
                    {
                        a.FirstOrDefault(x => x.TagId == tq.TagId).Appearance += 1;
                    }
                    else
                    {
                        Models.QuestionTag qtag = new QuestionTag
                        {
                            TagId = tq.TagId,
                            TagDescription = context.TagMasters.FirstOrDefault(x => x.TagId == tq.TagId).TagDescription,
                            Appearance = 1
                        };

                        a.Add(qtag);
                    }
                }


            }


            a = a.OrderByDescending(x => x.Appearance).Take(5).ToList();

            return a;
        }

    }
}