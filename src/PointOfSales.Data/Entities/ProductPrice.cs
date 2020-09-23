namespace PointOfSale.Data.Entities
{
    public class ProductPrice
    {
        public char Code { get; set; }
        public double Price { get; set; }
        public ProductSale Sale { get; set; }
    }
}
