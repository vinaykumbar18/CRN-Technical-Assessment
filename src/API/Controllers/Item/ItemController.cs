using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product_Management.src.Application.DTOs.Item;
using Product_Management.src.Application.Interfaces;

namespace Product_Management.src.API.Controllers.Item
{
        [Route("api/[controller]")]
        [ApiController]
        [Authorize]
        public class ItemController : ControllerBase
        {
            private readonly IItemService _itemService;

            public ItemController(IItemService itemService)
            {
                _itemService = itemService;
            }

            [HttpGet]
            [Authorize(Roles = "Admin,User")]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await _itemService.GetAllAsync());
            }

            [HttpGet("{id}")]
            [Authorize(Roles = "Admin,User")]
            public async Task<IActionResult> GetById(int id)
            {
                var item = await _itemService.GetByIdAsync(id);

                if (item == null)
                    return NotFound();

                return Ok(item);
            }

            [HttpPost]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> Create(ItemCreateDto dto)
            {
                await _itemService.CreateAsync(dto);
                return Ok("Item created successfully.");
            }

            [HttpPut("{id}")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> Update(int id, ItemUpdateDto dto)
            {
                await _itemService.UpdateAsync(id, dto);
                return Ok("Item updated successfully.");
            }

            [HttpDelete("{id}")]
            [Authorize(Roles = "Admin")]
            public async Task<IActionResult> Delete(int id)
            {
                await _itemService.DeleteAsync(id);
                return Ok("Item deleted successfully.");
            }
        }
    }
