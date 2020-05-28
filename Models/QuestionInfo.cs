using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StackOverFlow.Models
{
    //should represent sigle question
    public class QuestionInfo
    {
        public Question question { get; set;}
        public User QuestionUser { get; set; }

        //UserInfo
        public string UserName { get; set; }
        public string Email { get; set; }

        public string NewAnswer { get; set; } //set answer for a question
        public List<Answer> Answers { get; set; } //answer of question

        //public List<Tags> Answers { get; set; }
        [Required]
        public string CommaSeperatedTags { get; set; } //tags when question created
        public List<QuestionTag> Tags { get; set; } //tags of the qustion

        public User CurrentUser { get; set; }

        //QuestionInfo
        public int QuestionVotes { get; set; }

        public int QuestionId { get; set; }        
        public int UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int ViewCount { get; set; }
        public Boolean IsOpen { get; set; }      
    }
    public class QuestionTag
    {
        
        public int TagId { get; set; }
        public string TagDescription { get; set; }

        public int Appearance { get; set; }

    }
}