using StackOverFlow.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverFlow.Models.Repository
{
    public class UsersRepository : GenericModel<User>, IUsers
    {
        public UsersRepository(StackOverFlowDbContext db) : base(db)
        {

        }

        public List<CustomUser> GetTopUsers()
        {
            IEnumerable<User> ulist = this.GetAll();
            List<CustomUser> cUserList = new List<CustomUser>();
            foreach (var user in ulist)
            {
                CustomUser cu = new CustomUser
                {
                    Name = user.Name,
                    Email = user.Email,
                    UserId = user.UserId,
                    Gender = user.Gender,
                    MobileNumber = user.MobileNumber,
                    ImageName = user.ImageName,
                    ReputaionPoints = user.ReputaionPoints
                };

                int points = 0;
                if ((user.Questions != null && user.Questions.Any()))
                {
                    points += user.Questions.Count() * 50;
                    foreach (var q in user.Questions)
                    {
                        if (q.Answers != null && q.Answers.Any())
                        {
                            points += q.Answers.Count() * 10;
                            foreach (var a in q.Answers)
                            {
                                points += a.UpDownVote.Value;

                            }
                        }
                    }
                }

                cu.UserPoints = points;
                cUserList.Add(cu);

            }
            cUserList = cUserList.OrderByDescending(x => x.UserPoints).Take(5).ToList();

                return cUserList;
        }
        public override IEnumerable<User> GetAll()
        {
            IEnumerable<User> ulist = context.Users.ToList();
            foreach (var user in ulist)
            {
                user.ImageName = string.IsNullOrWhiteSpace(user.ImageName) ? "DefaultProfile.png" : user.ImageName;
            }
            return ulist;

        }
        public override User GetById(int id)
        {
            var user = context.Set<User>().Find(id);
            if (user != null)
            {
                user.ImageName = string.IsNullOrWhiteSpace(user?.ImageName) ? "DefaultProfile.png" : user.ImageName;
            }

            return (user);
        }

    }
}