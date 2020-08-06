using System.ComponentModel.DataAnnotations.Schema;

namespace Catalogue.DAL.Model
{
    public class Items : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UPC { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("OrdersId")]
        public int OrdersId { get; set; }
    }
}
