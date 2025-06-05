using Microsoft.AspNetCore.Mvc;
using Raddar.ProductsApi.Application.Services;

namespace RaddarStudios.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllProductsAsync());

    }
}
