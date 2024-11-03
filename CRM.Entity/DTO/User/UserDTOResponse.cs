using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Entity.DTO.User
{
    public class UserDTOResponse
    {
        public Guid? GUID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string EPosta { get; set; }

        public string GrupAdi { get; set; }
        public Guid? GrupGUID { get; set; }
    }
}
