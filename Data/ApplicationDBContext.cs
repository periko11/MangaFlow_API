using Microsoft.EntityFrameworkCore;
using MangaFlow_API.Models;

namespace MangaFlow_API.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<user> user { get; set; }
        public DbSet<user_role> user_role { get; set; }
        public DbSet<user_preferences> user_preferences { get; set; }
        public DbSet<tag> tag { get; set; }
        public DbSet<series> series { get; set; }
        public DbSet<series_tag> series_tag { get; set; }
        public DbSet<series_group> series_group { get; set; }
        public DbSet<scanlation_group> scanlation_group { get; set; }
        public DbSet<role> role { get; set; }
        public DbSet<chapter> chapter { get; set; }
        public DbSet<chapter_work> chapter_work { get; set; }
        public DbSet<action> action { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<user_role>()
                .HasKey(ur => new { ur.user_id, ur.role_id });

            modelBuilder.Entity<series_tag>()
                .HasKey(st => new { st.series_id, st.tag_id });

            modelBuilder.Entity<chapter_work>()
                .HasKey(cw => new { cw.chapter_id, cw.role_id, cw.user_id });

            modelBuilder.Entity<user>()
                .HasOne(u => u.group)
                .WithMany()
                .HasForeignKey(u => u.group_id);

            modelBuilder.Entity<user_preferences>()
                .HasKey(up => up.user_id);
            modelBuilder.Entity<user_preferences>()
                .HasOne(up => up.user)
                .WithOne()
                .HasForeignKey<user_preferences>(up => up.user_id);

            modelBuilder.Entity<series_group>()
                .HasKey(sg => new { sg.series_id, sg.group_id });

            modelBuilder.Entity<chapter>()
                .HasOne(c => c.series)
                .WithMany()
                .HasForeignKey(c => c.series_id);

            modelBuilder.Entity<chapter_work>()
                .HasOne(cw => cw.chapter)
                .WithMany()
                .HasForeignKey(cw => cw.chapter_id);
            modelBuilder.Entity<chapter_work>()
                .HasOne(cw => cw.role)
                .WithMany()
                .HasForeignKey(cw => cw.role_id);
            modelBuilder.Entity<chapter_work>()
                .HasOne(cw => cw.user)
                .WithMany()
                .HasForeignKey(cw => cw.user_id);

            modelBuilder.Entity<action>()
                .HasOne(a => a.user)
                .WithMany()
                .HasForeignKey(a => a.user_id);
            modelBuilder.Entity<action>()
                .HasOne(a => a.chapter)
                .WithMany()
                .HasForeignKey(a => a.chapter_id);
            modelBuilder.Entity<action>()
                .HasOne(a => a.role)
                .WithMany()
                .HasForeignKey(a => a.role_id);
        }
    }
}
