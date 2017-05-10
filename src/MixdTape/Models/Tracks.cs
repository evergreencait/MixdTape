using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MixdTape.Models
{
    [Table("Tracks")]
    public class Track
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public int Length { get; set; }

        public ICollection<PlaylistsTracks> PlaylistsTracks { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}