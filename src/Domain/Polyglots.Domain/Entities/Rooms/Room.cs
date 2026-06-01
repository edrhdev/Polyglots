using Polyglots.Domain.Entities.Users;

namespace Polyglots.Domain.Entities.Rooms;

public class Room
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    // Creator Relationship
    public Guid CreatorId { get; set; }
    public User? Creator { get; set; }

    // Navigation properties
    public ICollection<RoomMember> Members { get; set; } = [];
}