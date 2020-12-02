namespace Insurance.Infrastructure.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SalesPrice { get; set; }
        public int ProductTypeId { get; set; }
    }
}
