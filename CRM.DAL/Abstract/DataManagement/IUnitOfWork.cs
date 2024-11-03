using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Abstract.DataManagement
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IGroupRepository GroupRepository { get; }
        public ICategoryRepository CategoryRepository { get;}

        Task<int> SaveChangeAsync();
    }
}
