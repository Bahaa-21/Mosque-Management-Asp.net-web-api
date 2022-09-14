using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MosqueProj.Configurations.Roles;
using MosqueProj.Entities;
using System;

namespace MosqueProj.Data
{
    public class MosqueDbContext : IdentityDbContext<ApiUsers>
    {
        public MosqueDbContext(DbContextOptions option) : base(option) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
        

        public DbSet<Group> Groups { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
