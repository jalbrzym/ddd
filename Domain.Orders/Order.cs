using System.Collections.Generic;
using System.Linq;
using Domain.Abstractions;
using Domain.Customers.Contracts;
using Domain.Orders.Contracts;
using Domain.Orders.Contracts.Events;
using Domain.Products.Contracts;
using Domain.ValueTypes;
using MediatR;

namespace Domain.Orders
{
    public class Order : Entity, IAggregateRoot
    {
        private readonly List<OrderProduct> _products;

        private Order(OrderId id, CustomerId customerId)
        {
            Id = id;
            CustomerId = customerId;
            _products = new List<OrderProduct>();
        }

        public OrderId Id { get; private set; }
        public CustomerId CustomerId { get; private set; }

        public static Order Create(CustomerId customerId, IMediator mediator)
        {
            var created = new Order(OrderId.Generate(), customerId);
            //TODO: Publish should be executed after commiting aggregate to db..
            mediator.Publish(new OrderCreated(created.Id, created.CustomerId));
            return created;
        }

        public void AddProduct(ProductId productId, Money price, int quantity)
        {
            _products.Add(new OrderProduct(productId, price, quantity));
        }

        public void ConfirmAndPay()
        {
            //TODO: Change current status etc
            //TODO: Publish should be executed after commiting aggregate to db..
            RaiseEvent(new OrderPaymentRequested(Id, _products.Select(product => product.TotalPrice).Aggregate((left, right) => left + right)));
        }

        public void PaymentStarted()
        {
            //TODO: Change current status etc
        }

        public void SuccessfullyPaid()
        {
            //TODO: Change current status etc
        }
    }
}