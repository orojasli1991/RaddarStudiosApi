using Raddar.ProductsApi.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Raddar.ProductsApi.Domain.Entities;

namespace Raddar.ProductsApi.Infrastructure.Repository
{
    public  class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var sql = "SELECT * FROM Product";
            return await _dbConnection.QueryAsync<Product>(sql);
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Products WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
        }
        public async Task<int> AddAsync(Product product)
        {
            var sql = @"INSERT INTO Products (Nombre, Descripcion, Precio, Stock, FechaCreacion) 
                    VALUES (@Nombre, @Descripcion, @Precio, @Stock, @FechaCreacion);
                    SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = await _dbConnection.QuerySingleAsync<int>(sql, product);
            return id;
        }
        public async Task<int> UpdateAsync(Product product)
        {
            var sql = @"UPDATE Products SET 
                    Nombre = @Nombre,
                    Descripcion = @Descripcion,
                    Precio = @Precio,
                    Stock = @Stock,
                    FechaCreacion = @FechaCreacion
                    WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, product);
        }
        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Products WHERE Id = @Id";
            return await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
