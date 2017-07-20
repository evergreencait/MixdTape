using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MixdTape.Models
{
    [Table("Posts")]
    public class Post
    {
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Description { get; set; }
        public int CategoryId { get; set; }

        public ICollection<Category> Categories { get; set; }
        public virtual ApplicationUser User { get; set; }

        public override bool Equals(System.Object otherPost)
        {
            if (!(otherPost is Post))
            {
                return false;
            }
            else
            {
                Post newPost = (Post)otherPost;
                return this.PostId.Equals(newPost.PostId);
            }
        }

        public override int GetHashCode()
        {
            return this.PostId.GetHashCode();
        }
    }
}
    }
}