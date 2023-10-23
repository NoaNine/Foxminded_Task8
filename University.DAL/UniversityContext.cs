using Microsoft.EntityFrameworkCore;
using University.DAL.Extensions;
using University.DAL.Models;
using System.Reflection;

namespace University.DAL;

public class UniversityContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

    public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Seed(); //delete
    }
}