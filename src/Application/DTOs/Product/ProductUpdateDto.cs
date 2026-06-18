using System.ComponentModel.DataAnnotations;

namespace Product_Management.src.Application.DTOs.Product
{
        public class ProductUpdateDto
        {
            [Required]
            [StringLength(255)]
            public string ProductName { get; set; }
        }
    }

