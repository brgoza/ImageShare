using ImageShare.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageShare.Data.Configurations
{
    public class CollectionConfiguration : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            builder.HasMany(c => c.Images).WithMany(i => i.Collections)
                .UsingEntity("CollectionImage").ToTable("CollectionImages");
            builder.HasMany(c => c.Albums).WithMany(a => a.Collections)
                .UsingEntity("CollectionAlbum").ToTable("CollectionAlbums");
        }
    }
}
