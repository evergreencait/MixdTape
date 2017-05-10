﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MixdTape.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<PlaylistsTracks> PlaylistsTracks { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaylistsTracks>()
                 .HasKey(t => new { t.PlaylistId, t.TrackId });

            modelBuilder.Entity<PlaylistsTracks>()
                .HasOne(pt => pt.Playlist)
                .WithMany(p => p.PlaylistsTracks)
                .HasForeignKey(pt => pt.PlaylistId);

            modelBuilder.Entity<PlaylistsTracks>()
               .HasOne(pt => pt.Track)
               .WithMany(p => p.PlaylistsTracks)
               .HasForeignKey(pt => pt.TrackId);
            base.OnModelCreating(modelBuilder);
        }
    }
}