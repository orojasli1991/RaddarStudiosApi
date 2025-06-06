using Raddar.ProductsApi.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raddar.ProductsApi.Application.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<ProductDto> GetByProductIdAsync(int id);
        Task<int> CreateProductAsync(ProductDto dto);
        Task<int> UpdateProductAsync(int id, ProductDto dto);
        Task<int> DeleteProductAsync(int id);
    }
}
