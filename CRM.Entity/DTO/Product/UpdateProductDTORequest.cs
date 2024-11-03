namespace CRM.Entity.DTO.Product
{
    public class UpdateProductDTORequest
    {
        public Guid ProductGUID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CategoryGUID { get; set; }

        public string ProductImage { get; set; }
    }
}
