namespace VParse.Domain.Entities;

public class LikedUser(Guid userId, string likedVKId)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid UserId { get; private set; } = userId;
    public string LikedVKId { get; private set; } = likedVKId;
    public DateTime LikedAt { get; private set; } = DateTime.UtcNow;
}
