using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Catalogue.Models.Request
{
    public class LoadOrdersRequestModel
    {
        [JsonProperty("SearchText")]
        [Required(ErrorMessage = "Search text is required")]
        [StringLength(250, ErrorMessage = "Search text must be from 1 to 250 symbols", MinimumLength = 1)]
        public string SearchText { get; set; }
    }
}
