using Dev4Side_sheshan.Models;
using Microsoft.EntityFrameworkCore;

namespace Dev4Side_sheshan.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<ListEntity> Lists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListEntity>()
                        .HasOne(c => c.UserEntity)
                        .WithMany(u => u.listEntities)
                        .HasForeignKey(f => f.UserId);
            modelBuilder.Entity<TaskEntity>()
                        .HasOne(c => c.ListEntity)
                        .WithMany(t => t.taskEntities)
                        .HasForeignKey(f => f.ListId);
                        
        }
    }
}
