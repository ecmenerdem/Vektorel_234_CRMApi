using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Entity.DTO.User
{
    public class UserUpdateDTORequest:UserDTORequest
    {
        public Guid UserGUID { get; set; }


    }
}
