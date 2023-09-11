using Microsoft.EntityFrameworkCore;
using University.DAL.Extensions;
using University.DAL.Models;

namespace University.DAL;

public class UniversityContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Course> Courses { get; set; }

    public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(c =>
        {
            c.ToTable("Courses")
                .HasMany(c => c.Groups)
                .WithOne(g => g.Course)
                .OnDelete(DeleteBehavior.Cascade);
            c.HasIndex(c => c.Name)
                .IsUnique();
        });

        modelBuilder.Entity<Group>(g =>
        {
            g.ToTable("Groups")
                .HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .OnDelete(DeleteBehavior.Cascade);
            g.HasIndex(g => g.Name)
                .IsUnique();
        });

        modelBuilder.Entity<Teacher>(g =>
        {
            g.ToTable("Teachers")
                .HasMany(t => t.Groups)
                .WithMany(g => g.Teachers);
        });

        modelBuilder.Entity<Student>(s =>
        {
            s.ToTable("Students");
        });

        modelBuilder.Seed();
    }
}