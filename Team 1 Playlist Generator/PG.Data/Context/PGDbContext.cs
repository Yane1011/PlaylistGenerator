﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PG.Data.Configurations;
using PG.Models;

namespace PG.Data.Context
{
    public class PGDbContext : IdentityDbContext
    {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PlaylistsSongs> PlaylistSongs { get; set; }
        public DbSet<Album> Albums { get; set; }

        public PGDbContext(DbContextOptions<PGDbContext> options) : base(options)
        {

        }
        public PGDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PlaylistsSongsConfig());

            base.OnModelCreating(builder);
        }
    }
}
