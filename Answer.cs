namespace StackOverFlow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Answer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Answer()
        {
            AnswersComments = new HashSet<AnswersComment>();
        }

        public int AnswerId { get; set; }

        public int QuestionId { get; set; }

        [Required]
        public string Text { get; set; }

        public int AnswerByUser { get; set; }

        public DateTime? AnsweredOn { get; set; }

        public int? UpDownVote { get; set; }

        public virtual Question Question { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnswersComment> AnswersComments { get; set; }
    }
}
