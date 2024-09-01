using VParse.Domain.Exceptions;

namespace VParse.Domain.Entities;

public class User(string vkId, string name, string email)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string VKId { get; private set; } = vkId;
    public string Name { get; private set; } = name;
    public string Email { get; private set; } = email;
    public int SwipesLeft { get; private set; } = 20; // Default number of swipes
    public DateTime LastSwipeReset { get; private set; } = DateTime.UtcNow;
    public bool IsPremium { get; private set; } = false;

    public void ResetSwipes()
    {
        if (DateTime.UtcNow.Subtract(LastSwipeReset).TotalHours >= 24)
        {
            SwipesLeft = IsPremium ? 100 : 20;
            LastSwipeReset = DateTime.UtcNow;
        }
    }

    public bool CanSwipe()
    {
        ResetSwipes();
        return SwipesLeft > 0;
    }

    public void Swipe()
    {
        if (CanSwipe())
        {
            SwipesLeft--;
        }
        else
        {
            throw new DomainException("No swipes left");
        }
    }

    public void UpgradeToPremium()
    {
        IsPremium = true;
        SwipesLeft = 100;
    }
}
