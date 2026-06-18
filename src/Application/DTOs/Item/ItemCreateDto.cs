using System.ComponentModel.DataAnnotations;

namespace Product_Management.src.Application.DTOs.Item
{
        public class ItemCreateDto
        {
            [Required]
            public int ProductId { get; set; }

            [Required]
            [Range(1, int.MaxValue)]
            public int Quantity { get; set; }
        }
    }

