using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raddar.ProductsApi.Application.Dto;
using Raddar.ProductsApi.Domain.Entities;
using Raddar.ProductsApi.Domain.Interface;

namespace Raddar.ProductsApi.Application.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
        {
            var products = await _repository.GetAllProductAsync();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock

            });
        }
        public async Task<ProductDto> GetByProductIdAsync(int id)
        {
            var p = await _repository.GetByIdProductAsync(id);
            return new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock

            };
        }
        public async Task<int> CreateProductAsync(ProductDto dto)
        {
            if (dto.Price <= 0 || dto.Stock <= 0)
                throw new ArgumentException("Precio y Stock deben ser mayores a cero");

            var producto = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock,
                CreationDate = DateTime.UtcNow
            };
           return await _repository.CreateProductAsync(producto);
        }
        public async Task<int> UpdateProductAsync(int id, ProductDto dto)
        {
            var producto = new Product
            {
                Id = id,
                Name = dto.Name,
                Description= dto.Description,
                Price = dto.Price,
                Stock = dto.Stock
            };
           return await _repository.UpdateProductAsync(producto);
        }
        public async Task<int> DeleteProductAsync(int id) {
           return await _repository.DeleteProductAsync(id);
        } 
    }
}
