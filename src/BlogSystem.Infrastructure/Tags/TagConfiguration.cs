using BlogSystem.Domain.Posts;
using BlogSystem.Domain.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSystem.Infrastructure.Tags;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");

        builder.HasKey(t => t.Id);

        builder.OwnsOne(x => x.Name, nameBuilder =>
        {
            nameBuilder.Property(x => x.Value)
                      .HasColumnName("Name")
                      .HasMaxLength(50)
                      .IsRequired();

            nameBuilder.HasIndex(h => h.Value).IsUnique();
        });

        builder.HasMany<PostTag>()
        .WithOne()
        .HasForeignKey(x => x.TagId);
    }
}