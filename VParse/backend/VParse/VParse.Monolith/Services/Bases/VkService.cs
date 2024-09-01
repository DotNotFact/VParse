using Microsoft.Extensions.Options;
using VParse.Monolith.Models;
using Newtonsoft.Json.Linq;

namespace VParse.Monolith.Services.Bases;

public class VkService(HttpClient httpClient, IOptions<VkSettings> vkSettings)
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly VkSettings _vkSettings = vkSettings.Value;

    public async Task<string> GetAccessTokenAsync(string code)
    {
        var response = await _httpClient.GetAsync($"https://oauth.vk.com/access_token?client_id={_vkSettings.ClientId}&client_secret={_vkSettings.ClientSecret}&redirect_uri={_vkSettings.RedirectUri}&code={code}");

        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var json = JObject.Parse(content);
        return json["access_token"].ToString();
    }

    public async Task<JObject> GetUserInfoAsync(string accessToken)
    {
        var response = await _httpClient.GetAsync($"https://api.vk.com/method/users.get?access_token={accessToken}&v=5.131");

        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JObject.Parse(content);
    }
}