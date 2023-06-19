using System.Text.Json.Serialization;

namespace Ass1Server.Models.Member
{
    public class MemberInfoDTO
    {
        [JsonPropertyName("MemberId")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int MemberId { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("CompanyName")]
        public string CompanyName { get; set; }
        [JsonPropertyName("City")]
        public string City { get; set; }
        [JsonPropertyName("Country")]
        public string Country { get; set; }
        [JsonPropertyName("Password")]
        public string Password { get; set; }
    }
}
