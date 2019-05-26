using System.Threading.Tasks;
using Domain.Payments.Contracts;

namespace Domain.Payments
{
    public interface IPaymentRepository
    {
        //TODO: Handle transaction here, open on GET, close and commit on SAVE
        Payment Get(PaymentId id);
        Task SaveAndCommit(Payment payment);
    }
}