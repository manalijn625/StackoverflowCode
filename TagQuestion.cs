namespace StackOverFlow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TagQuestion
    {
   
        public int Id { get; set; }

        public int TagId { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public virtual TagMaster TagMaster { get; set; }
    }
}
