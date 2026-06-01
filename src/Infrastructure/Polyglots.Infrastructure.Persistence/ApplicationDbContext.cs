using Microsoft.EntityFrameworkCore;
using Polyglots.Domain.Entities.Rooms;
using Polyglots.Domain.Entities.Users;

namespace Polyglots.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<RoomMember> RoomMembers => Set<RoomMember>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Composite Key for UserRole
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        // Composite Key for RoomMember
        modelBuilder.Entity<RoomMember>()
            .HasKey(rm => new { rm.RoomId, rm.UserId });

        modelBuilder.Entity<RoomMember>()
            .HasOne(rm => rm.Room)
            .WithMany(r => r.Members)
            .HasForeignKey(rm => rm.RoomId);

        modelBuilder.Entity<RoomMember>()
            .HasOne(rm => rm.User)
            .WithMany(u => u.RoomMembers)
            .HasForeignKey(rm => rm.UserId);

        // Room Creator Relationship
        modelBuilder.Entity<Room>()
            .HasOne(r => r.Creator)
            .WithMany(u => u.CreatedRooms)
            .HasForeignKey(r => r.CreatorId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascade cycles
    }
}