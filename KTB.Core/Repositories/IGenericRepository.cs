using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KTB.Core.Repositories
{
    //generic repository design patterns
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        /*
         * CRUD Operations
         * */
        Task<TEntity> GetByIdAsync(int Id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        //find multiple result
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
        //find single result
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        void Remove(TEntity entity);

        TEntity Update(TEntity entity);
    }
}
