using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Management.src.Domain.Entities
{
        public class Item
        {
            [Key]
            public int Id { get; set; }

            public int ProductId { get; set; }

            public int Quantity { get; set; }

            [ForeignKey("ProductId")]
            public Product Product { get; set; }
        }
}


