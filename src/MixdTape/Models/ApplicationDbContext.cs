using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MixdTape.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                 .HasKey(t => new { t.PostId });

            modelBuilder.Entity<Categories>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.Categories)
                .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<Categories>()
               .HasOne(pt => pt.Post)
               .WithMany(p => p.Categories);
            base.OnModelCreating(modelBuilder);
        }
    }
}