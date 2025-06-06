using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Raddar.ProductsApi.Application.Dto;
using Raddar.ProductsApi.Application.Services;
using System.Reflection.Metadata.Ecma335;

namespace RaddarStudios.Controller
{
    [ApiController]
    [Route("api/")]
    [Authorize]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _service;

        public ProductController(IProductService productServcies) {
            _service = productServcies;
        }
        [HttpGet("productos")]
        public async Task<IActionResult> GetAll()
        {
           return Ok(await _service.GetAllProductAsync());
        }
        [HttpGet("productos/{id}")]
        public async Task<IActionResult> Get(int id) {
            return Ok(await _service.GetByProductIdAsync(id));
        }
        [HttpPost("productos")]
        public async Task<IActionResult> Create([FromBody] ProductDto dto)
        {
           var result = await _service.CreateProductAsync(dto);
            return result == 0 ? NotFound(): Ok();
        }

        [HttpPut("productos/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDto dto)
        {
           var result = await _service.UpdateProductAsync(id, dto);
            return result == 0 ? NotFound() : Ok();
        }
        [HttpDelete("productos/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           var result =  await _service.DeleteProductAsync(id);
            return result == 0 ? NotFound() : Ok();
        }

    }
}
