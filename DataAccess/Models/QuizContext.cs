using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class QuizContext : IdentityDbContext
{
    public QuizContext()
    {
    }

    public QuizContext(DbContextOptions<QuizContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Choice> Choices { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }
    public virtual DbSet<UserData> UserDatas { get; set; }
    public virtual DbSet<QuizAnswer> QuizAnswers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Quiz;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuizAnswer>()
            .HasKey(q => new { q.QuizId, q.QuestionId, q.Email });

        base.OnModelCreating(modelBuilder);


        //modelBuilder.Entity<Answer>(answer =>
        //{
        //    answer.HasKey(a => a.Email);
        //    answer.OwnsMany(a => a.AnswerValue, myPair =>
        //    {
        //        myPair.WithOwner().HasForeignKey("AnswerEmail");
        //        myPair.HasKey("AnswerEmail", nameof(MyPair.QuestionId));
        //        myPair.Property<string>("AnswerEmail")
        //              .HasColumnName("AnswerEmail");
        //    });
        //});

        //modelBuilder.Entity<MyPair>(entity =>
        //{
        //    entity.HasKey(p => new {p.UserEmail ,p.QuestionId});
        //});

        modelBuilder.Entity<Choice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Choice__3214EC0744673E6D");

            entity.ToTable("Choice");

            entity.Property(e => e.Text)
                .HasMaxLength(250)
                .HasDefaultValue("");

            entity.HasOne(d => d.Question).WithMany(p => p.Choices)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__Choice__Question__31EC6D26");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC07E7F40DC7");

            entity.ToTable("Question");

            entity.Property(e => e.Text)
                .HasMaxLength(500)
                .HasDefaultValue("");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("FK__Question__QuizId__2D27B809");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quiz__3214EC07E1D83FE5");

            entity.ToTable("Quiz");

            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasDefaultValue("");
            entity.Property(e => e.ImageName)
                .HasMaxLength(250)
                .HasDefaultValue("");
            entity.Property(e => e.ImageType)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasDefaultValue("");
        });

        OnModelCreatingPartial(modelBuilder);

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
