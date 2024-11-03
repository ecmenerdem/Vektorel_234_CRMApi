using CRM.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Entity.Poco
{
    public class Group : AuditableEntity
    {
        public Group()
        {
            Users = new HashSet<User>();
        }
        public string Name { get; set; }

        public virtual IEnumerable<User> Users { get; set; }


    }
}
