using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MosqueProj.Configurations.Roles;

namespace MosqueProj.Data;

public class MosqueDbContext : IdentityDbContext<Users>
{
    public MosqueDbContext(DbContextOptions option) : base(option) { }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Relationships
        builder.Entity<Year>()
            .HasMany(g => g.Groups)
            .WithOne(y => y.Years)
            .HasForeignKey(f => f.YearId);

        builder.Entity<Group>()
            .HasMany(s => s.Students)
            .WithOne(g => g.Groups)
            .HasForeignKey(f => f.GroupId);

        builder.Entity<Subject>()
            .HasMany(t => t.Teachers)
            .WithOne(s => s.Subjects)
            .HasForeignKey(f => f.SubjectId);

        //Many-To-Many Relationship
        builder.Entity<Group_Teacher>().HasKey(sc => new { sc.TeacherId, sc.GroupId });

        builder.Entity<Group_Teacher>()
            .HasOne(t => t.Teachers)
            .WithMany(g => g.Groups_Teachers)
            .HasForeignKey(f => f.TeacherId);

        builder.Entity<Group_Teacher>()
            .HasOne(t => t.Groups)
            .WithMany(g => g.Groups_Teachers)
            .HasForeignKey(f => f.GroupId);
        #endregion

        builder.Entity<Student>().Property(p => p.FullName).HasComputedColumnSql("[FirstName] + ' ' + [FatherName] + ' ' + [LastName]");
        builder.Entity<Teacher>().Property(p => p.FullName).HasComputedColumnSql("[FirstName] + ' ' + [LastName]");


        builder.ApplyConfiguration(new RoleConfiguration());


    }


    public DbSet<Group> Groups { get; set; }
    public DbSet<Year> Years { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Group_Teacher> Groups_Teachers { get; set; }

}
