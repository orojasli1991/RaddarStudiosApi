using Microsoft.Extensions.Caching.Memory;
using Moq;
using Raddar.ProductsApi.Application.Services;
using Raddar.ProductsApi.Domain.Entities;
using Raddar.ProductsApi.Domain.Interface;
using Xunit;

namespace RaddarStudios.Application
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly Mock<IMemoryCache> _mockCache;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _service = new ProductService(_mockRepo.Object);
        }
        [Fact]
        public async Task DeleteAsync_ReturnsTrue_WhenProductExists()
        {
            var product = new Product { Id = 1 };
            _mockRepo.Setup(r => r.GetByIdProductAsync(1)).ReturnsAsync(product);
            _mockRepo.Setup(r => r.DeleteProductAsync(1)).ReturnsAsync(1);

            var result = await _service.DeleteProductAsync(1);

            Assert.Equal(1,result);
        }
        public async Task GetAllProductsAsync()
        {

            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product A", Description = "Description A", Price = 10.5M, Stock = 5, CreationDate = DateTime.UtcNow },
                new Product { Id = 2, Name = "Product B", Description = "Description B", Price = 20.0M, Stock = 10, CreationDate = DateTime.UtcNow }
            };

            _mockRepo.Setup(r => r.GetAllProductAsync()).ReturnsAsync(products);
            var result = await _service.GetAllProductAsync();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Product A", result.First().Name);
        }

    }

}
