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
    internal class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");
                   
            builder.HasMany(i=>i.Albums).WithMany(i => i.Images)
                .UsingEntity("AlbumImage").ToTable("AlbumImages");
            builder.HasOne(i => i.Owner).WithMany(u => u.Images);
        }
    }
}
