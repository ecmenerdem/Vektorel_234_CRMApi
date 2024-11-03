using CRM.Entity.Base;
using CRM.Entity.Poco;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRM.DAL.Abstract.DataManagement
{
    public interface IRepository<T> where T : AuditableEntity
    {
        Task<T> GetAsync(Expression<Func<T,bool>>Filter,params string[] IncludeParameters);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Filter=null, params string[] IncludeParameters);

        Task<EntityEntry<T>> AddAsync(T Entity);

        Task UpdateAsync(T Entity);

        Task DeleteAsync(T Entity);


    }
}
