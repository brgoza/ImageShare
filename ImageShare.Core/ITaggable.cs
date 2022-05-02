using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageShare.Core
{
    public interface ITaggable
    {
        List<Tag> Tags { get; set; }
    }
}
