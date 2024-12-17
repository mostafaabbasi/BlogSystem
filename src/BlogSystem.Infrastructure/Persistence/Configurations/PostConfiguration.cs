using BlogSystem.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSystem.Infrastructure.Persistence.Configurations;

internal sealed class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .HasConversion(title => title.Value, value => new Title(value))
            .IsRequired();

        builder.Property(x => x.Content)
            .HasMaxLength(5000)
            .HasConversion(content => content.Value, value => new Content(value))
            .IsRequired();

        builder.Property(x => x.Summary)
            .HasMaxLength(200)
            .HasConversion(summary => summary.Value, value => new Summary(value))
            .IsRequired();

        builder.Property(x => x.Author)
            .HasConversion(author => author.Value, value => new Author(value))
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(h => h.Tags)
            .WithMany(w => w.Posts)
            .UsingEntity<PostTag>();

        builder.Navigation(x => x.Tags)
            .Metadata.SetField("_tags");
    }
}