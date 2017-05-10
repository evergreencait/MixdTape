using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MixdTape.Models
{
    [Table("PlaylistsTracks")]
    public class PlaylistsTracks
    {
        [Key]
        public int PlaylistId { get; set; }

        public virtual Playlist Playlist { get; set; }

        public int TrackId { get; set; }
        public virtual Track Track { get; set; }
    }
}