using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Entity.DTO.Product
{
    public class AddProductDTORequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CategoryGUID { get; set; }

        public string ProductImage { get; set; }
    }
}
