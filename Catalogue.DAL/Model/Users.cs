using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalogue.DAL.Model
{
    public class Users : IEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string CustomerId { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
