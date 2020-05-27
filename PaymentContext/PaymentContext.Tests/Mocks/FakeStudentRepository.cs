using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace Paymentcontext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {

        }

        public bool DocumentsExists(string document)
        {
            if (document == "99999999999")
                return true;

            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "lucas@oliveira.com")
                return true;

            return false;
        }
    }
}