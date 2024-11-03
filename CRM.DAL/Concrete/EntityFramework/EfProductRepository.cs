using CRM.DAL.Abstract;
using CRM.DAL.Concrete.EntityFramework.DataManagement;
using CRM.Entity.Poco;
using Microsoft.EntityFrameworkCore;

namespace CRM.DAL.Concrete.EntityFramework
{
    public class EfProductRepository : EfRepository<Product>, IProductRepository
    {
        public EfProductRepository(DbContext context) : base(context)
        {
        }
    }
}
