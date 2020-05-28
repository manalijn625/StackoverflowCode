namespace StackOverFlow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Answer
    {
        public int AnswerId { get; set; }

        public int QuestionId { get; set; }

        [Required]
        public string Text { get; set; }

        public int AnswerByUser { get; set; }

        public DateTime? AnsweredOn { get; set; }

        public int? UpDownVote { get; set; }

        public virtual Question Question { get; set; }

        public virtual User User { get; set; }
    }

    
}
