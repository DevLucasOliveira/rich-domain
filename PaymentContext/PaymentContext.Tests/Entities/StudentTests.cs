using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace Paymentcontext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Lucas", "Oliveira");
            _document = new Document("14825231080", EDocumentType.CPF);
            _email = new Email("lucasoliveira.si@outlook.com");
            _address = new Address("Rua 1", "890", "Bahia", "Sp", "Maceío", "Brazil", "01552010");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadNoActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now.AddDays(2), DateTime.Now.AddDays(5), 10, 8, "devlucasoliveira", _document, _address, _email);
            _subscription.AddPayment(payment);
            _subscription.Inactivate();
            _student.AddSubscription(_subscription);

            Assert.AreEqual(_student.Valid, true);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);
            Assert.AreEqual(_student.Valid, false);

        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now.AddDays(2), DateTime.Now.AddDays(5), 10, 10, "devlucasoliveira", _document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.AreEqual(_student.Valid, true);

        }


    }
}