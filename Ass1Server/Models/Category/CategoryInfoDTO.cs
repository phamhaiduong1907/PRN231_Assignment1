using System.Text.Json.Serialization;

namespace Ass1Server.Models.Category
{
    public class CategoryInfoDTO
    {
        [JsonPropertyName("CategoryId")]
        public int CategoryId { get; set; }
        [JsonPropertyName("CategoryName")]
        public string CategoryName { get; set; }
    }
}
