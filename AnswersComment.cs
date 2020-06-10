namespace StackOverFlow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnswersComment")]
    public partial class AnswersComment
    {
        [Key]
        public int CommentId { get; set; }

        public int AnswerId { get; set; }

        public string Comment { get; set; }

        public virtual Answer Answer { get; set; }
    }
}
