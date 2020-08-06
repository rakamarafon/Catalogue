using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalogue.DAL.Model
{
    public class Orders : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public OrderStatus Status { get; set; }
        public OrderStatus? PreviousStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? StatusChangedAt { get; set; }
        public virtual ICollection<Items> Items { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Orders")]
        public virtual Users User { get; set; }

        public Orders()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
