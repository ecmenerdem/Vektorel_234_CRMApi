using CRM.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Entity.DTO.Group
{
    public class GroupDTORequest
    {
        public string GrupAdi { get; set; }
        public Guid? Guid { get; set; }
        public string Comments { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
