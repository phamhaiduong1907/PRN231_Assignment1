using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ass1Client.Model.Category
{
    public class CategoryInfo
    {
        [JsonPropertyName("CategoryId")]
        public int CategoryId { get; set; }
        [JsonPropertyName("CategoryName")]
        public string CategoryName { get; set; }
    }
}
