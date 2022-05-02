using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageShare.Core
{
    public class Tag
    {
        [Key, StringLength(255)]
        public string TagText { get; set; } = null!;
        public List<Image> Images { get; set; } = null!;
        public List<Album> Albums { get; set; } = null!;
        public List<Collection> Collections { get; set; } = null!;
    }
}
