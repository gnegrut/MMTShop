using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTShop.Api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly MMTShopConfiguration _configuration;
        private readonly IMMTShopService _shopService;

        public ProductController(ILogger<ProductController> logger, MMTShopConfiguration configuration, IMMTShopService service)
        {
            _logger = logger;
            _configuration = configuration;
            _shopService = service;
        }

        /// <summary>
        /// Returns featured products
        /// </summary>
        /// <returns></returns>
        [HttpGet("featured", Name = "GetFeaturedProducts")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetFeaturedProducts()
        {
            try
            {
                var featuredProducts = await _shopService.GetFeaturedProducts();

                return Ok(featuredProducts ?? Enumerable.Empty<ProductDto>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        /// <summary>
        /// Returns the available products for a specified category Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("{categoryId}", Name = "GetProductsByCategoryId")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByCategoryId(string categoryId)
        {
            if (string.IsNullOrWhiteSpace(categoryId))
            {
                return BadRequest("The CategoryId has not been specified");
            }

            var response = Enumerable.Empty<ProductDto>();

            try
            {
                int.TryParse(categoryId, out int categoryIdInteger);

                if (categoryIdInteger > 0)
                {
                    var products = await _shopService.GetProductsByCategoryId(categoryIdInteger);
                    response = products;
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
