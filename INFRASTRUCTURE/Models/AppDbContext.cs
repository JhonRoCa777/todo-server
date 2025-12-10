using System.Xml.Linq;
using DOMAIN.Enums;
using Microsoft.EntityFrameworkCore;

namespace INFRASTRUCTURE.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<UserModel> UserModel { get; set; }

        public DbSet<TodoModel> TodoModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.Property(e => e.Created_At).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.Role).HasDefaultValue(Role.USER);
                entity.HasIndex(e => e.Email).IsUnique();
            });

            modelBuilder.Entity<TodoModel>(entity =>
            {
                entity.Property(e => e.Created_At).HasDefaultValueSql("GETUTCDATE()");
                entity.Property(e => e.Estado).HasDefaultValue(Estado.PENDIENTE);
            });
        }
    }
}
