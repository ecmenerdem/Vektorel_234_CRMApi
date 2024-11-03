using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Entity.Base
{
    public class BaseEntity
    {
        public BaseEntity()
        {
          guid= Guid.NewGuid();
        }

        public int id { get; set; }
        public Guid? guid { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string Comments { get; set; }
    }
}
