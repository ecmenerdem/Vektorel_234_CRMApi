﻿namespace CRM.Entity.DTO.Product
{
    public class ProductDTOResponse()
    {
        public Guid? GUID { get; set; }
        public string Ad { get; set; }

        public string KategoriAdi { get; set; }
        public Guid? KategoriGUID { get; set; }
        public string Aciklama { get; set; }

        public string OneCikanGorsel { get; set; }
    }
}
