using ControlMesh.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlMesh.Database
{
    public class ControlMeshDataContext : DbContext
    {
        public ControlMeshDataContext(DbContextOptions<ControlMeshDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Message>()
                .HasOne(m => m.MessageSystemProperties)
                .WithOne(m => m.Message)
                .HasForeignKey<MessageSystemProperties>(m => m.MessageForeignKey)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
              .Entity<Message>()
              .HasOne(m => m.MessageCustomProperties)
              .WithOne(m => m.Message)
              .HasForeignKey<MessageCustomProperties>(m => m.MessageForeignKey)
              .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Message> Messages { get; set; } = default!;
    }
}