using ImageShare.Core;
using ImageShare.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImageShare.Data.Configurations
{
    public class LibraryConfiguration : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.HasMany(c => c.Albums).WithMany(a => a.Libraries)
                .UsingEntity<LibraryAlbum>().ToTable("LibraryAlbums").HasKey("LibraryId", "AlbumId");
        }
    }
}
