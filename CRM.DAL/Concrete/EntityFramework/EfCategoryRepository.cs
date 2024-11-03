using CRM.DAL.Abstract;
using CRM.DAL.Concrete.EntityFramework.DataManagement;
using CRM.Entity.Poco;
using Microsoft.EntityFrameworkCore;

namespace CRM.DAL.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(DbContext context) : base(context)
        {
           
        }
    }

}
