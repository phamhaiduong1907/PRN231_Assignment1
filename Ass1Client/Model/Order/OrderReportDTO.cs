﻿using System.Text.Json.Serialization;
using System;

namespace Ass1Client.Model.Order
{
    public class OrderReportDTO
    {
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("ProductName")]
        public string ProductName { get; set; }
        [JsonPropertyName("ShippedDate")]
        public DateTime ShippedDate { get; set; }
        [JsonPropertyName("UnitPrice")]
        public double UnitPrice { get; set; }
        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("Discount")]
        public double Discount { get; set; }
        [JsonPropertyName("Price")]
        public double Price { get; set; }
    }
}
