using BlogSystem.Domain.Abstractions;
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

        builder.OwnsOne(x => x.Name, nameBuilder =>
        {
            nameBuilder.Property(x => x.Value)
                      .HasColumnName("Name")
                      .HasMaxLength(50)
                      .IsRequired();
        });

        builder.HasMany(h => h.Posts)
            .WithMany(w => w.Tags);

        builder.Navigation(x => x.Posts)
            .Metadata.SetField(FiledSchema.PostsField);
    }
}