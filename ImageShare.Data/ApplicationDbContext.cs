using ImageShare.Core;
using ImageShare.Core.Models;
using ImageShare.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ImageShare.Data;

public class ApplicationDbContext : IdentityUserContext<AppUser,Guid>
{
    public DbSet<Image> Images { get; set; } = null!;
    public DbSet<Album> Albums { get; set; } = null!;
    public DbSet<Library> Libraries { get; set; } = null!;
    public DbSet<Tag> Tags { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new AppUserConfiguration());
        builder.ApplyConfiguration(new LibraryConfiguration());
        builder.ApplyConfiguration(new ImageConfiguration());
        builder.ApplyConfiguration(new TagConfiguration());
    }
}

