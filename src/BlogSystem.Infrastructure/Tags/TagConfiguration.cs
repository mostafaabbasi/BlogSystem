using BlogSystem.Domain.Posts;
using BlogSystem.Domain.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSystem.Infrastructure.Tags;

internal sealed class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");

        builder.HasKey(t => t.Id);
        
        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => value);

        builder.OwnsOne(x => x.Name, nameBuilder =>
        {
            nameBuilder.Property(x => x.Value)
                      .HasColumnName("Name")
                      .HasMaxLength(50)
                      .IsRequired();

            nameBuilder.HasIndex(h => h.Value).IsUnique();
        });
    }
}