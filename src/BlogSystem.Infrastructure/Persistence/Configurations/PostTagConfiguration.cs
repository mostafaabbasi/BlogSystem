using BlogSystem.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogSystem.Infrastructure.Persistence.Configurations;

internal sealed class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
{
    public void Configure(EntityTypeBuilder<PostTag> builder)
    {
        builder.ToTable("PostTags");

        builder.HasKey(postTag => new { postTag.PostId, postTag.TagId });

        builder.HasOne(h => h.Post)
        .WithMany(w => w.PostTags)
        .HasForeignKey(h => h.PostId);

        builder.HasOne(h => h.Tag)
        .WithMany(w => w.PostTags)
        .HasForeignKey(h => h.TagId);
    }
}