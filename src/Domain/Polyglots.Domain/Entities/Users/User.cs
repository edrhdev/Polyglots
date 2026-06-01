using Polyglots.Domain.Entities.Rooms;

namespace Polyglots.Domain.Entities.Users;

public class User
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public bool IsActive { get; set; } = true;
    public string Username { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    // Navigation properties
    public ICollection<UserRole> UserRoles { get; set; } = [];
    public ICollection<Room> CreatedRooms { get; set; } = [];
    public ICollection<RoomMember> RoomMembers { get; set; } = [];
}
