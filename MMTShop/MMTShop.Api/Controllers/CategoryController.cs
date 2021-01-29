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
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IMMTShopService _shopService;

        public CategoryController(ILogger<CategoryController> logger, IMMTShopService service)
        {
            _logger = logger;
            _shopService = service;
        }

        /// <summary>
        /// Returns available categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            try
            {
                var categories = await _shopService.GetAllCategories();

                return Ok(categories?? Enumerable.Empty<string>());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
