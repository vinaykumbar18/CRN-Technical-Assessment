using System.ComponentModel.DataAnnotations;
namespace Product_Management.src.Application.DTOs.Product
{
  public class ProductCreateDto
        {
            [Required]
            [StringLength(255)]
            public string ProductName { get; set; }
        }
    }

