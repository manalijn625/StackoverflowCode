using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverFlow.Models
{
    public class TopInfo
    {
        public List<QuestionInfo> Questions { get; set; }
        public List<QuestionTag> Tags { get; set; }
        public List<CustomUser> Users { get; set; }
    }
}