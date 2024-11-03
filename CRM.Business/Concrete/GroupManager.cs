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
    public class GroupManager : IGroupService
    {
        private readonly IUnitOfWork _uow;

        public GroupManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Group> AddAsync(Group Entity)
        {
            await _uow.GroupRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task DeleteAsync(Group Entity)
        {
            await _uow.GroupRepository.DeleteAsync(Entity);

            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<Group>> GetAllAsync(Expression<Func<Group, bool>> Filter = null, params string[] IncludeParameters)
        {
           
            return await _uow.GroupRepository.GetAllAsync(Filter, IncludeParameters);
        }

        public async Task<Group> GetAsync(Expression<Func<Group, bool>> Filter, params string[] IncludeParameters)
        {
            return await _uow.GroupRepository.GetAsync(Filter, IncludeParameters);
        }

        public async Task UpdateAsync(Group Entity)
        {
            await _uow.GroupRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
