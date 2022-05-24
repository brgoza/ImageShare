using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageShare.Core.Models
{
    public class LibraryAlbum
    {
        public virtual Library Library { get; set; } = null!;
        public Guid LibraryId { get; set; }
        public virtual Album Album { get; set; } = null!;
        public Guid AlbumId { get; set; }

    }
}
