using Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface  IMMTShopService
    {
        Task<IEnumerable<ProductDto>> GetFeaturedProducts();

        Task<IEnumerable<string>> GetAllCategories();

        Task<IEnumerable<ProductDto>> GetProductsByCategoryId(int categoryId);
    }
}
