using Cloneio.DAL;
using Cloneio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cloneio.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CloneioDbContext _dbContext;
        private readonly DbSet<T> _entitiySet;

        public GenericRepository(CloneioDbContext storeDbContext)
        {
            _dbContext = storeDbContext;
            _entitiySet = _dbContext.Set<T>();
        }

        

        public IEnumerable<T> GetAll()
        {
            return  _entitiySet.AsNoTracking().AsEnumerable();
        }

        public T GetById(int id)
        {
            T item =  _entitiySet.Find(id);
            if (id == null)
            {

                throw new InvalidOperationException($"Entity of type {typeof(T).Name} with ID {id} not found in database.");

            }
            return item;
        }

        

        public void Add(T item)
        {
            _entitiySet.Add(item);
        }

        public void Delete(T item)
        {
            _entitiySet.Remove(item);
        }

        public void Update(T item)
        {
            _entitiySet.Update(item);
            // We are not doing save changes at repo level becaus ewe do single save transaction
            //at unitofwork if we do save changes here there unit of work savechanges have no meaning to use 
            //and if we want to implement rollback it will not
            //_dbContext.SaveChanges();
        }
    }
}
