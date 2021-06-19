using KTB.Core.Entities;
using KTB.Core.Repositories;
using KTB.Core.Services;
using KTB.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KTB.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity:class
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IGenericRepository<TEntity> _repository;
        public Service(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository) 
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAysnc();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity updatedEntity=_repository.Update(entity);
            _unitOfWork.Commit();
            return updatedEntity;
        }
    }
}
