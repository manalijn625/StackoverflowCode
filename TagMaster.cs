namespace StackOverFlow
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TagMaster")]
    public partial class TagMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TagMaster()
        {
            TagQuestions = new HashSet<TagQuestion>();
        }

        [Key]
        public int TagId { get; set; }

        [Required]
        [StringLength(50)]
        public string TagDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TagQuestion> TagQuestions { get; set; }
    }
}
