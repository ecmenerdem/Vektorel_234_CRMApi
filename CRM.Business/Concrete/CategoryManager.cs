using CRM.Business.Abstract;
using CRM.DAL.Abstract.DataManagement;
using CRM.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        private readonly IUnitOfWork _uow;

        public CategoryManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Category> AddAsync(Category Entity)
        {
            await _uow.CategoryRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task DeleteAsync(Category Entity)
        {
            await _uow.CategoryRepository.DeleteAsync(Entity);

            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync(Expression<Func<Category, bool>> Filter = null, params string[] IncludeParameters)
        {
            return await _uow.CategoryRepository.GetAllAsync(Filter, IncludeParameters);
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> Filter, params string[] IncludeParameters)
        {
            return await _uow.CategoryRepository.GetAsync(Filter, IncludeParameters);
        }

        public async Task UpdateAsync(Category Entity)
        {
            await _uow.CategoryRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
