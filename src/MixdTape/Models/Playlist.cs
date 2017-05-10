using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MixdTape.Models
{
    [Table("Playlists")]
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Description { get; set; }

        public ICollection<PlaylistsTracks> PlaylistsTracks { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}