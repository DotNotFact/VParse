namespace VParse.Application.DTOs;

public class UserDto
{
    public Guid Id { get; set; }
    public string VKId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int SwipesLeft { get; set; }
    public bool IsPremium { get; set; }
}