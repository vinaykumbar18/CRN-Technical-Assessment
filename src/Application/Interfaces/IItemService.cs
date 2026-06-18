using Product_Management.src.Application.DTOs.Item;

namespace Product_Management.src.Application.Interfaces
{
    
        public interface IItemService
        {
            Task<IEnumerable<ItemResponseDto>> GetAllAsync();

            Task<ItemResponseDto?> GetByIdAsync(int id);

            Task CreateAsync(ItemCreateDto dto);

            Task UpdateAsync(int id, ItemUpdateDto dto);

            Task DeleteAsync(int id);
        }
    }
