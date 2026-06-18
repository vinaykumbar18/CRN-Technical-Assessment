using System.ComponentModel.DataAnnotations;

namespace Product_Management.src.Application.DTOs.Item
{
        public class ItemUpdateDto
        {
            [Required]
            [Range(1, int.MaxValue)]
            public int Quantity { get; set; }
        }
    }

