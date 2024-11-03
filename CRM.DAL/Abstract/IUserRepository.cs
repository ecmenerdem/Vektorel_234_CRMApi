using CRM.DAL.Abstract.DataManagement;
using CRM.Entity.Poco;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL.Abstract
{
    public interface IUserRepository:IRepository<User>
    {
       
    }
}
