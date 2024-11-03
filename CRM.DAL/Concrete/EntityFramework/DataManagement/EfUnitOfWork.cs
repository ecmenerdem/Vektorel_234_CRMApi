using CRM.DAL.Abstract;
using CRM.DAL.Abstract.DataManagement;
using CRM.Entity.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Concrete.EntityFramework.DataManagement
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly CRMContext _context;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public EfUnitOfWork(CRMContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;

            UserRepository=new EfUserRepository(context);
            ProductRepository = new EfProductRepository(context);
            GroupRepository = new EfGroupRepository(context);
            CategoryRepository = new EfCategoryRepository(context);
        }

        public IUserRepository UserRepository { get; }
        public IProductRepository ProductRepository { get;}
        public IGroupRepository GroupRepository { get; }
        public ICategoryRepository CategoryRepository { get; }

        public async Task<int> SaveChangeAsync()
        {
            foreach (var item in _context.ChangeTracker.Entries<AuditableEntity>())
            {
                if (item.State==EntityState.Added)
                {
                    item.Entity.AddedTime=DateTime.Now;
                    item.Entity.AddedIP = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    item.Entity.AddedUser = 1;

                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.UpdatedIP = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    item.Entity.UpdatedUser = 1;

                    if (item.Entity.IsActive==null)
                    {
                        item.Entity.IsActive = true;
                    }
                    item.Entity.IsDeleted = false;

                }
                else if(item.State==EntityState.Modified)
                {
                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.UpdatedIP = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    item.Entity.UpdatedUser = 1;
                }
            }
           
          return await _context.SaveChangesAsync();
        }
    }
}
