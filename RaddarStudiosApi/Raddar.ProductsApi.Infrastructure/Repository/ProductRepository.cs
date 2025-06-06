using Raddar.ProductsApi.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Raddar.ProductsApi.Domain.Entities;
using Raddar.ProductsApi.Application.Dto;
using System.Data.Common;
using System.Threading.Tasks;

namespace Raddar.ProductsApi.Infrastructure.Repository
{
    public  class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _dbConnection.QueryAsync<Product>("sp_GetAllProduct", commandType: CommandType.StoredProcedure);
            
        }
        public async Task<Product> GetByIdProductAsync(int id)
        {
            return await _dbConnection.QueryFirstAsync<Product>("sp_GetProductById", new { id = id}, commandType: CommandType.StoredProcedure);
        }
        public async Task<int> CreateProductAsync(Product product)
        {
            return await _dbConnection.ExecuteAsync(
            "sp_CreateProduct",
            new
            {
                product.Name,
                product.Description,
                product.Price,
                product.Stock,
                CreateDate = DateTime.UtcNow
            },
            commandType: CommandType.StoredProcedure);
        }
        public async Task<int> UpdateProductAsync(Product product)
        {
           return await _dbConnection.ExecuteAsync(
            "sp_UpdateProduct",
            new
            {
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.Stock,
                CreateDate = DateTime.UtcNow

            },
            commandType: CommandType.StoredProcedure);
        }
        public async Task<int> DeleteProductAsync(int id)
        {
           return await _dbConnection.ExecuteAsync(
           "sp_DeleteProduct",
           new { Id = id },
           commandType: CommandType.StoredProcedure);
        }
    }
}
