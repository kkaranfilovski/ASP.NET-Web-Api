using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SEDC.WebApi.Class06.Domain.Models
{
    public partial class MovieManager_DBContext : DbContext
    {
        public MovieManager_DBContext()
        {
        }

        public MovieManager_DBContext(DbContextOptions<MovieManager_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; } = null!;
        public virtual DbSet<MovieUser> MovieUsers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=MovieManager_DB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieUser>(entity =>
            {
                entity.ToTable("MovieUser");

                entity.HasIndex(e => e.MovieId, "IX_MovieUser_MovieId");

                entity.HasIndex(e => e.UserId, "IX_MovieUser_UserId");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieUsers)
                    .HasForeignKey(d => d.MovieId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MovieUsers)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
