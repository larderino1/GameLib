using DbManager.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Mode> Modes { get; set; }

        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Game>(en =>
            {
                en.ToTable(nameof(Game)).HasKey(key => key.Id);

                en.Property(a => a.Id).ValueGeneratedOnAdd();

                en.Property(a => a.Name).IsRequired();
                en.Property(a => a.Studio).IsRequired();
                en.Property(a => a.Author).IsRequired();
                en.Property(a => a.Country).IsRequired();
                en.Property(a => a.AnonceDate).IsRequired();
                en.Property(a => a.Name).IsRequired();

                en.HasOne(a => a.Category)
                .WithMany()
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

                en.HasOne(a => a.Genre)
                .WithMany()
                .HasForeignKey(a => a.GenreId)
                .OnDelete(DeleteBehavior.Cascade);

                en.HasOne(a => a.Mode)
                .WithMany()
                .HasForeignKey(a => a.ModeId)
                .OnDelete(DeleteBehavior.Cascade);

                en.HasOne(a => a.Platform)
                .WithMany()
                .HasForeignKey(a => a.PlatformId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Category>(en =>
            {
                en.ToTable(nameof(Category)).HasKey(key => key.Id);

                en.Property(a => a.Id).ValueGeneratedOnAdd();

                en.Property(a => a.Name).IsRequired();
            });

            builder.Entity<Genre>(en =>
            {
                en.ToTable(nameof(Genre)).HasKey(key => key.Id);

                en.Property(a => a.Id).ValueGeneratedOnAdd();

                en.Property(a => a.Name).IsRequired();
            });

            builder.Entity<Mode>(en =>
            {
                en.ToTable(nameof(Mode)).HasKey(key => key.Id);

                en.Property(a => a.Id).ValueGeneratedOnAdd();

                en.Property(a => a.Name).IsRequired();
            });

            builder.Entity<Platform>(en =>
            {
                en.ToTable(nameof(Platform)).HasKey(key => key.Id);

                en.Property(a => a.Id).ValueGeneratedOnAdd();

                en.Property(a => a.Name).IsRequired();
            });

            base.OnModelCreating(builder);
        }
    }
}
