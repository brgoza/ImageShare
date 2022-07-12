using ImageShare.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImageShare.Data.Configurations
{
    internal class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags")
                   .HasKey(t => t.TagText);
            builder.HasMany(t => t.Images).WithMany(i => i.Tags)
                .UsingEntity("ImageTag").ToTable("ImageTags");
            builder.HasMany(t => t.Albums).WithMany(g => g.Tags)
                .UsingEntity("AlbumTag").ToTable("AlbumTags");
            builder.HasMany(t => t.Libraries).WithMany(c => c.Tags)
                .UsingEntity("LibraryTag").ToTable("LibraryTags");

        }
    }
}
