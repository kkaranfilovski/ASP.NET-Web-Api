using Microsoft.EntityFrameworkCore;
using SEDC.WebApi.Notes.DataModels.Models;
using System.Security.Cryptography;
using System.Text;

namespace SEDC.WebApi.Notes.DataAccess
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .ToTable("User")
                .HasKey(t => t.Id);

            builder.Entity<User>()
                .Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Entity<User>()
                .Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Entity<User>()
                .Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Entity<User>()
                .Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(500);

            // notes

            builder.Entity<Note>()
                .ToTable("Note")
                .HasKey(x => x.Id);

            builder.Entity<Note>()
                .HasOne(x => x.User)
                .WithMany(x => x.NoteList)
                .HasForeignKey(x => x.UserId);

            builder.Entity<Note>()
                .Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Entity<Note>()
                .Property(x => x.Color)
                .IsRequired()
                .HasMaxLength(20);

            builder.Entity<Note>()
                .Property(t => t.Tag)
                .IsRequired()
                .HasDefaultValue(5); // 5 is the value of Other in our enumeration

            #region Add initial data

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("123456sedc"));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            builder.Entity<User>()
            .HasData
            (
                new User
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    UserName = "bob007",
                    Password = hashedPassword
                }
            );

            builder.Entity<Note>()
                .HasData
                (
                new Note
                {
                    Id = 1,
                    Text ="Buy Juice",
                    Color = "Blue",
                    Tag = 4,
                    UserId = 1
                },

                new Note
                {
                    Id = 2,
                    Text = "Learn WebAPi",
                    Color = "red",
                    Tag = 3,
                    UserId = 1
                }
                );

            #endregion


        }
    }
}
