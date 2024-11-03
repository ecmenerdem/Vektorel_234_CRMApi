using CRM.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Entity.DTO.User
{
    public class UserDTORequest
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sifre { get; set; }
        public string EPosta { get; set; }
        public Guid GrupGUID { get; set; }
    }
}
