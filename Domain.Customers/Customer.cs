using Domain.Customers.Contracts;
using Domain.ValueTypes;

namespace Domain.Customers
{
    public class Customer
    {
        public Customer(CustomerId id, FullName fullName, Age age)
        {
            Id = id;
            FullName = fullName;
            Age = age;
        }

        public CustomerId Id { get; private set; }
        public FullName FullName { get; private set; }
        public Age Age { get; private set; }
    }
}