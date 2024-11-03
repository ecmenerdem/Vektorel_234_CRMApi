using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Entity.DTO.User
{
    public class UserDTOModel:UserDTORequest
    {
        public string KullaniciAdi { get; set; }
        public Guid GUID { get; set; }
        public int? GrupID { get; set; }
    }
}
