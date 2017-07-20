using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MixdTape.Models
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}