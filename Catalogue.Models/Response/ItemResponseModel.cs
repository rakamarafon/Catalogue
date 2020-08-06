using Newtonsoft.Json;

namespace Catalogue.Models.Response
{
    public class ItemResponseModel
    {
        [JsonProperty("ItemName")]
        public string ItemName { get; set; }

        [JsonProperty("ItemUPC")]
        public int ItemUPC { get; set; }

        [JsonProperty("Quantity")]
        public int Quantity { get; set; }

        [JsonProperty("ItemPrice")]
        public decimal ItemPrice { get; set; }
    }
}
