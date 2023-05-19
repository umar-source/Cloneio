using Cloneio.DAL;
using Cloneio.Interfaces;
using Cloneio.Models;

namespace Cloneio.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(CloneioDbContext storeDbContext) : base(storeDbContext)
        {
        }
    }
}
