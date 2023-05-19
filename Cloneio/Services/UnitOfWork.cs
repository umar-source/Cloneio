using Cloneio.DAL;
using Cloneio.Interfaces;

namespace Cloneio.Services
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly CloneioDbContext _cloneioDbContext;

        public UnitOfWork(
            CloneioDbContext cloneioDbContext,
            IProductRepository productRepository
            )
        {
            _cloneioDbContext = cloneioDbContext;
            ProductRepo = productRepository;
        }

        public IProductRepository ProductRepo { get; private set; }

        public void Commit()
        {
            _cloneioDbContext.SaveChanges();
        }

        public void Rollback()
        {
            _cloneioDbContext.Dispose();
        }
    }
}
