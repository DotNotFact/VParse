namespace VParse.Domain.Entities;

public class FilterSettings(Guid userId, int? minAge, int? maxAge, string city)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid UserId { get; private set; } = userId;
    public int? MinAge { get; private set; } = minAge;
    public int? MaxAge { get; private set; } = maxAge;
    public string City { get; private set; } = city;

    public void UpdateSettings(int? minAge, int? maxAge, string city)
    {
        MinAge = minAge;
        MaxAge = maxAge;
        City = city;
    }
}
