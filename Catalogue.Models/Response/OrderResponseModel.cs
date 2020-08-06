using Newtonsoft.Json;
using System.Collections.Generic;

namespace Catalogue.Models.Response
{
    public class OrderResponseModel
    {
        [JsonProperty("OrderId")]
        public int  OrderId { get; set; }

        [JsonProperty("CustomerId")]
        public string CustomerId { get; set; }

        [JsonProperty("TotalAmount")]
        public decimal TotalAmount { get; set; }

        [JsonProperty("Items")]
        public IEnumerable<ItemResponseModel> Item { get; set; }
    }
}
