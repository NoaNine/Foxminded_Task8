using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using University.DAL.Models;

namespace University.DAL.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups")
            .HasMany(g => g.Students)
            .WithOne(s => s.Group)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(g => g.Name)
            .IsUnique();
        builder.HasOne(g => g.Tutor)
            .WithOne(t => t.Group)
            .HasForeignKey<Teacher>(t => t.GroupId)
            .IsRequired(false);
    }
}
