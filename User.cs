namespace StackOverFlow
{
    using StackOverFlow.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Answers = new HashSet<Answer>();
            Questions = new HashSet<Question>();
        }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string ConfirmPassword { get; set; }

        [StringLength(50)]
        public string MobileNumber { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(100)]
        public string ImageName { get; set; }

        [StringLength(10)]
        public string Role { get; set; }
        public int ReputaionPoints { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }
    }

    public class CustomUser
    {

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string ConfirmPassword { get; set; }

        [StringLength(50)]
        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [StringLength(100)]
        [DisplayName("Upload File")]
        public string ImageName { get; set; }

        [StringLength(10)]
        public string Role { get; set; }
        public int ReputaionPoints { get; set; }

        public int UserPoints { get; set; }

        //[DataType(DataType.Upload)]
        [DisplayName("Profile Image")]
        public HttpPostedFileBase attachment { get; set; }
        public List<QuestionInfo> QuestionInfo { get; set; }
        public List<QuestionTag> TagList { get; set; }

    }
}
