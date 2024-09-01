namespace VParse.Domain.Entities;

public class VKUser(string vkId, string name, List<string> photoUrls)
{
    public string VKId { get; private set; } = vkId;
    public string Name { get; private set; } = name;
    public List<string> PhotoUrls { get; private set; } = photoUrls;
}
