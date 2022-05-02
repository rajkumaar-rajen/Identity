using Newtonsoft.Json;

namespace Identity.Authorization
{
    public class JwtToken
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }
    }
}
