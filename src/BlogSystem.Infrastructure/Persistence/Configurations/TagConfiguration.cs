using BlogSystem.Domain.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSystem.Infrastructure.Persistence.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
        .HasConversion(name => name.Value, value => new Name(value))
        .HasMaxLength(50)
        .IsRequired()
        .IsUnicode();

        builder.HasMany(h => h.Posts);

        builder.Navigation(x => x.Posts)
            .Metadata.SetField("_posts");
    }
}