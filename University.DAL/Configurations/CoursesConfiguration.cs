using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University.DAL.Models;

namespace University.DAL.Configurations;

public class CoursesConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses")
                .HasMany(c => c.Groups)
                .WithOne(g => g.Course)
                .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(c => c.Name)
                .IsUnique();
    }
}
