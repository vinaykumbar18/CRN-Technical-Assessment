using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product_Management.src.Application.DTOs.Product;
using Product_Management.src.Application.Interfaces;

namespace Product_Management.src.API.Controllers.Product
{
        [Route("api/[controller]")]
        [ApiController]
        [Authorize]
        public class ProductController : ControllerBase
        {
            private readonly IProductService _productService;

            public ProductController(IProductService productService)
            {
                _productService = productService;
            }

            [HttpGet]
            [Authorize(Roles = "Admin,User")]
            public async Task<IActionResult> GetAll()
            {
                var products = await _productService.GetAllAsync();
                return Ok(products);
            }

            [HttpGet("{id}")]
            [Authorize(Roles = "Admin,User")]
            public async Task<IActionResult> GetById(int id)
            {
                var product = await _productService.GetByIdAsync(id);

                if (product == null)
                    return NotFound();

                return Ok(product);
            }

            [HttpPost]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> Create(ProductCreateDto dto)
            {
                await _productService.CreateAsync(dto);
                return Ok("Product created successfully.");
            }

            [HttpPut("{id}")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> Update(int id, ProductUpdateDto dto)
            {
                await _productService.UpdateAsync(id, dto);
                return Ok("Product updated successfully.");
            }

            [HttpDelete("{id}")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> Delete(int id)
            {
                await _productService.DeleteAsync(id);
                return Ok("Product deleted successfully.");
            }
        }
    }

