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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Quiz;Trusted_Connection=True;TrustServerCertificate=True;");
        optionsBuilder.UseSqlServer("Server=db14191.public.databaseasp.net; Database=db14191; User Id=db14191; Password=Ri5+p8!W3Yn=; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
        base.OnConfiguring(optionsBuilder);
    }

    public virtual DbSet<Choice> Choices { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }
    public virtual DbSet<UserData> UserDatas { get; set; }
    public virtual DbSet<QuizAnswer> QuizAnswers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<QuizAnswer>()
            .HasKey(q => new { q.UserDataEmail, q.QuizId, q.QuestionId });

        base.OnModelCreating(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
