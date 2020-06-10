using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StackOverFlow.Models
{
    //should represent sigle question
    public class QuestionInfo
    {
        public int commentAnswer { get; set; }
        public Question question { get; set;}
        public User QuestionUser { get; set; }

        //UserInfo
        public string UserName { get; set; }
        public string Email { get; set; }

        [AllowHtml]
        public string NewAnswer { get; set; } //set answer for a question
        public List<Answer> Answers { get; set; } //answer of question

        public string NewComment { get; set; }// Add new comment for any answer
        [DisplayName("Comma Seperated Tags")]
        public string CommaSeperatedTags { get; set; } //tags when question created/edited
        public List<QuestionTag> Tags { get; set; } //tags of the qustion

       // public List<AnswersComment> Comments { get; set;} //Comments of one answer

        public User CurrentUser { get; set; }

        //QuestionInfo
        public int QuestionVotes { get; set; }

        public int QuestionId { get; set; } 
        
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Title { get; set; }

        //[Required]
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
    public class AnswersComment
    {

        public int CommentId { get; set; }
        public string Comment { get; set; }

        public int AnswerId { get; set; }

    }
}