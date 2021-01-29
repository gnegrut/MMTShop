using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository
    {
        Task<IEnumerable<Product>> GetFeaturedProducts();

        Task<IEnumerable<Category>> GetAllCategories();

        Task<IEnumerable<Product>> GetProductsByCategoryId(int categoryId);
    }
}
