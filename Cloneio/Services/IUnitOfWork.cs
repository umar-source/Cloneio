using Cloneio.Interfaces;

namespace Cloneio.Services
{
    public interface IUnitOfWork
    {
        public IProductRepository ProductRepo { get; }



        void Commit();
        void Rollback();
    }
}
