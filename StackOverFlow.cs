namespace StackOverFlow
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StackOverFlowDbContext : DbContext
    {
        public StackOverFlowDbContext()
            : base("name=StackOverFlow")
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<TagMaster> TagMasters { get; set; }
        public virtual DbSet<TagQuestion> TagQuestions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
