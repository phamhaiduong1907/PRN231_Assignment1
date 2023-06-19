using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Ass1Server.Models.Member
{
    public class MemberInfoDTO
    {
        [JsonPropertyName("MemberId")]
        public int MemberId { get; set; }
        [JsonPropertyName("Email")]
        [Required]
        public string Email { get; set; }
        [JsonPropertyName("CompanyName")]
        [Required]
        public string CompanyName { get; set; }
        [JsonPropertyName("City")]
        [Required]
        public string City { get; set; }
        [JsonPropertyName("Country")]
        [Required]
        public string Country { get; set; }
        [JsonPropertyName("Password")]
        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        public string Password { get; set; }
    }
}
