using ImageShare.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImageShare.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");

            builder.HasMany(u => u.Images)
                .WithOne(i => i.Owner)
                .HasForeignKey(i => i.OwnerId)
                .IsRequired();

            builder.HasMany(u => u.SubscribedAlbums)
                   .WithMany(g => g.Subscribers).UsingEntity<AlbumSubscriber>(
                      j => j
                         .HasOne(gs => gs.Album)
                         .WithMany(g => g.AlbumSubscribers)
                         .HasForeignKey(gs => gs.AlbumId),
                     j => j
                         .HasOne(gs => gs.Subscriber)
                         .WithMany(s => s.AlbumSubscribers)
                         .HasForeignKey(gs => gs.SubscriberId),
                     j =>
                     {
                         j.HasKey(t => new { t.AlbumId, t.SubscriberId });
                         j.ToTable("AlbumSubscribers");
                     });

            builder.HasMany(u => u.SubscribedLibraries)
                   .WithMany(c => c.Subscribers).UsingEntity<LibrarySubscriber>(
                    j => j
                       .HasOne(cs => cs.Library)
                       .WithMany(c => c.LibrarySubscribers)
                       .HasForeignKey(cs => cs.LibraryId),
                   j => j
                       .HasOne(cs => cs.Subscriber)
                       .WithMany(s => s.LibrarySubscribers)
                       .HasForeignKey(cs => cs.SubscriberId),
                   j =>
                   {
                       j.HasKey(t => new { t.LibraryId, t.SubscriberId });
                       j.ToTable("LibrarySubscribers");
                   });
        }
    }
}
