namespace Domain.Products.Contracts
{
    public class ProductId
    {
        private ProductId() { }

        public ProductId(long id)
        {
            Id = id;
        }

        public long Id { get; private set; }

        public static ProductId Generate()
        {
            return new ProductId(-1);
        }
    }
}