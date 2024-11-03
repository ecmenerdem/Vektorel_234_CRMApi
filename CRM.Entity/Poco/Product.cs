using CRM.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Entity.Poco
{
    public class Product : AuditableEntity
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryID { get; set; }

        public string ProductImage { get; set; }

        public virtual Category Category { get; set; }

    }
}
