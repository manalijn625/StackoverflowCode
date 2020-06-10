namespace StackOverFlow
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;

    public partial class StackOverFlowDbContext : DbContext
    {
        public StackOverFlowDbContext()
            : base("name=StackOverFlow")
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AnswersComment> AnswersComments { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<TagMaster> TagMasters { get; set; }
        public virtual DbSet<TagQuestion> TagQuestions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual ObjectResult<User> getUser(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User>("getUser", userIDParameter);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasMany(e => e.AnswersComments)
                .WithRequired(e => e.Answer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.TagQuestions)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TagMaster>()
                .Property(e => e.TagDescription)
                .IsUnicode(false);

            modelBuilder.Entity<TagMaster>()
                .HasMany(e => e.TagQuestions)
                .WithRequired(e => e.TagMaster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ConfirmPassword)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.MobileNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ImageName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.AnswerByUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
