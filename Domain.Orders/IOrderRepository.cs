using System.Threading.Tasks;
using Domain.Orders.Contracts;

namespace Domain.Orders
{
    public interface IOrderRepository
    {
        //TODO: Handle transaction here, open on GET, close and commit on SAVE
        Order Get(OrderId id);
        Task SaveAndCommit(Order order);
    }
}