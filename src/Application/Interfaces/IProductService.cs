using Product_Management.src.Application.DTOs.Product;

namespace Product_Management.src.Application.Interfaces
{
        public interface IProductService
        {
            Task<IEnumerable<ProductResponseDto>> GetAllAsync();

            Task<ProductResponseDto?> GetByIdAsync(int id);

            Task CreateAsync(ProductCreateDto dto);

            Task UpdateAsync(int id, ProductUpdateDto dto);

            Task DeleteAsync(int id);
        }
    }

