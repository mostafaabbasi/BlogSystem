using BlogSystem.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSystem.Infrastructure.Posts;

internal sealed class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");

        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Title, nameBuilder =>
        {
            nameBuilder.Property(x => x.Value)
                    .HasColumnName("Title")
                    .HasMaxLength(100)
                    .IsRequired();
        });

        builder.OwnsOne(x => x.Content, nameBuilder =>
        {
            nameBuilder.Property(x => x.Value)
                      .HasColumnName("Content")
                      .HasMaxLength(5000)
                      .IsRequired();
        });

        builder.OwnsOne(x => x.Summary, nameBuilder =>
        {
            nameBuilder.Property(x => x.Value)
                      .HasColumnName("Summary")
                      .HasMaxLength(200)
                      .IsRequired();
        });

        builder.OwnsOne(x => x.Author, nameBuilder =>
        {
            nameBuilder.Property(x => x.Value)
                      .HasColumnName("Author")
                      .HasMaxLength(100)
                      .IsRequired();
        });

        builder.HasMany(h=>h.PostTags)
        .WithOne(w=>w.Post)
        .HasForeignKey(w=>w.PostId);
    }
}