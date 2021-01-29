using Repository;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Dtos;

namespace Services
{
    public class MMTShopService : IMMTShopService
    {
        private readonly IRepository _repository;

        public MMTShopService(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// GetFeaturedProducts - returns the featured products from repository and returns product dtos
        /// Featured product SKU ranges are stored in FeaturedProductRange SQL table
        /// </summary>
        /// <returns>Task<IEnumerable<ProductDto>></returns>
        public async Task<IEnumerable<ProductDto>> GetFeaturedProducts()
        {
            var featuredProducts = await _repository.GetFeaturedProducts();

            return featuredProducts.Select(product => new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price
            });
        }

        /// <summary>
        /// GetAllCategories - returns the available categories from repository and returns category names
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetAllCategories()
        {
            var categories = await _repository.GetAllCategories();

            return categories.Select(category => category.Name);
        }

        /// <summary>
        /// GetProductsByCategoryId - returns the available products for a specified category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductDto>> GetProductsByCategoryId(int categoryId)
        {
            var products = await _repository.GetProductsByCategoryId(categoryId);

            return products.Select(product => new ProductDto
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price
            });
        }
    }
}
