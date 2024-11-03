using CRM.Business.Abstract;
using CRM.DAL.Abstract.DataManagement;
using CRM.DAL.Concrete.EntityFramework;
using CRM.DAL.Concrete.EntityFramework.DataManagement;
using CRM.Entity.Poco;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<User> AddAsync(User Entity)
        {
          var existsUser_userName =  await _uow.UserRepository.GetAsync(q => q.Username == Entity.Username);

          var existsUser_EMail =  await _uow.UserRepository.GetAsync(q => q.Email == Entity.Email);

            if (existsUser_userName is null && existsUser_EMail is null)
            {
                await _uow.UserRepository.AddAsync(Entity);
                await _uow.SaveChangeAsync();
            }
            else if (existsUser_userName is not null)
            {
                throw new Exception("Bu Kullanıcı Adı Sistemde Mevcuttur.");
            }
            else if(existsUser_EMail is not null) {
                throw new Exception("Bu E-Posta Adresi Sistemde Mevcuttur.");
            }
            
            return Entity;
        }

        public async Task DeleteAsync(User Entity)
        {
            await _uow.UserRepository.DeleteAsync(Entity);

            await _uow.SaveChangeAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> Filter = null, params string[] IncludeParameters)
        {
            return await _uow.UserRepository.GetAllAsync(Filter, IncludeParameters);
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> Filter, params string[] IncludeParameters)
        {
            return await _uow.UserRepository.GetAsync(Filter, IncludeParameters);
        }

        public async Task UpdateAsync(User Entity)
        {
            var existsUser_email = await _uow.UserRepository.GetAsync(q => q.Email.ToLower() == Entity.Email.ToLower());

            if (existsUser_email is null || Entity.id==existsUser_email.id)
            {
                await _uow.UserRepository.UpdateAsync(Entity);
                await _uow.SaveChangeAsync();
            }
            else
            {
                throw new Exception("Bu E-Posta Adresi Sistemde Mevcuttur.");
            }
           

        }
    }
}
