using CRM.DAL.Abstract;
using CRM.DAL.Concrete.EntityFramework.DataManagement;
using CRM.Entity.Poco;
using Microsoft.EntityFrameworkCore;

namespace CRM.DAL.Concrete.EntityFramework
{
    public class EfGroupRepository : EfRepository<Group>, IGroupRepository
    {
        public EfGroupRepository(DbContext context) : base(context)
        {
        }
    }

}
