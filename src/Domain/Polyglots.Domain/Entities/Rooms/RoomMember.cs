using Polyglots.Domain.Entities.Users;

namespace Polyglots.Domain.Entities.Rooms;

public class RoomMember
{
    public Guid RoomId { get; set; }
    public Room? Room { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public DateTimeOffset JoinedAt { get; set; } = DateTimeOffset.UtcNow;
}