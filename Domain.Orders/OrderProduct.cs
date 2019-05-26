using Domain.Products.Contracts;
using Domain.ValueTypes;

namespace Domain.Orders
{
    public class OrderProduct
    {
        public OrderProduct(ProductId productId, Money price, int quantity)
        {
            ProductId = productId;
            Price = price;
            Quantity = quantity;
            TotalPrice = new Money(Price.Amount * quantity, Price.Currency);
        }

        public ProductId ProductId { get; private set; }
        public Money Price { get; private set; }
        public int Quantity { get; private set; }
        public Money TotalPrice { get; private set; }
    }
}