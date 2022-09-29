using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MosqueProj.Configurations.Roles;

namespace MosqueProj.Data;

public class MosqueDbContext : IdentityDbContext<Users>
{
    public MosqueDbContext(DbContextOptions option) : base(option) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Relationships
        modelBuilder.Entity<Year>()
            .HasMany(g => g.Groups)
            .WithOne(y => y.Years)
            .HasForeignKey(f => f.YearId);

        modelBuilder.Entity<Group>()
            .HasMany(s => s.Students)
            .WithOne(g => g.Groups)
            .HasForeignKey(f => f.GroupId);

        modelBuilder.Entity<Subject>()
            .HasMany(t => t.Teachers)
            .WithOne(s => s.Subjects)
            .HasForeignKey(f => f.SubjectId);

        //Many-To-Many Relationship
        modelBuilder.Entity<Group_Teacher>().HasKey(sc => new { sc.TeacherId, sc.GroupId });

        modelBuilder.Entity<Group_Teacher>()
            .HasOne(t => t.Teachers)
            .WithMany(g => g.Groups_Teachers)
            .HasForeignKey(f => f.TeacherId);
        
        modelBuilder.Entity<Group_Teacher>()
            .HasOne(t => t.Groups)
            .WithMany(g => g.Groups_Teachers)
            .HasForeignKey(f => f.GroupId);
        #endregion

        modelBuilder.Entity<Student>().Property(p => p.FullName).HasComputedColumnSql("[FirstName] + ' ' + [FatherName] + ' ' + [LastName]");
        modelBuilder.ApplyConfiguration(new RoleConfiguration());


    }


    public DbSet<Group> Groups { get; set; }
    public DbSet<Year> Years { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Group_Teacher> Groups_Teachers { get; set; }

}
