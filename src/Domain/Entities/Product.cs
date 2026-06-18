using System.ComponentModel.DataAnnotations;

namespace Product_Management.src.Domain.Entities
{
        public class Product
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public string ProductName { get; set; }

            public string CreatedBy { get; set; }

            public DateTime CreatedOn { get; set; }

            public string? ModifiedBy { get; set; }

            public DateTime? ModifiedOn { get; set; }

            public ICollection<Item> Items { get; set; }
        }
    }

