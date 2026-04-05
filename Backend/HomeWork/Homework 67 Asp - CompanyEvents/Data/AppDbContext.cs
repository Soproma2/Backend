using Homework_67_Asp___CompanyEvents.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework_67_Asp___CompanyEvents.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email).IsUnique();

            // Registration: ერთი მომხმარებელი ერთ ღონისძიებაზე ერთხელ
            modelBuilder.Entity<Registration>()
                .HasIndex(r => new { r.UserId, r.ActivityId }).IsUnique();

            // TeamMember: ერთი მომხმარებელი ერთ გუნდში ერთხელ
            modelBuilder.Entity<TeamMember>()
                .HasIndex(tm => new { tm.TeamId, tm.UserId }).IsUnique();

            // Donation decimal precision
            modelBuilder.Entity<Donation>()
                .Property(d => d.Amount)
                .HasColumnType("decimal(18,2)");

            // Activity -> Team (cascade delete)
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Activity)
                .WithMany(a => a.Teams)
                .HasForeignKey(t => t.ActivityId)
                .OnDelete(DeleteBehavior.Cascade);

            // Team Captain არ წაიშლება cascade-ით
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Captain)
                .WithMany()
                .HasForeignKey(t => t.CaptainUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Activity)
                .WithMany(a => a.Registrations)
                .HasForeignKey(r => r.ActivityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Registration>()
                .HasOne(r => r.User)
                .WithMany(u => u.Registrations)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
