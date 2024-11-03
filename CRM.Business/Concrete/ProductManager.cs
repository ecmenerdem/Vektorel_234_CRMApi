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
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Product> AddAsync(Product Entity)
        {
            await _uow.ProductRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task DeleteAsync(Product Entity)
        {
            await _uow.ProductRepository.DeleteAsync(Entity);

            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>> Filter = null, params string[] IncludeParameters)
        {
           return await _uow.ProductRepository.GetAllAsync(Filter, IncludeParameters);
        }

        public Task<Product> GetAsync(Expression<Func<Product, bool>> Filter, params string[] IncludeParameters)
        {
            return _uow.ProductRepository.GetAsync(Filter, IncludeParameters);
        }

        public async Task UpdateAsync(Product Entity)
        {
            await _uow.ProductRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
