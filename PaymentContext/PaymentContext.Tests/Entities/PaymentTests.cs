
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace Paymentcontext.Tests
{
    [TestClass]
    public class PaymentTests
    {
        private readonly Name _name;
        private readonly Email _email;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public PaymentTests()
        {
            _name = new Name("Lucas", "Oliveira");
            _document = new Document("14825231080", EDocumentType.CPF);
            _email = new Email("lucasoliveira.si@outlook.com");
            _address = new Address("Rua 1", "890", "Bahia", "Sp", "Maceío", "Brazil", "01552010");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenTotalIsZero()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 0, 0, "devlucasoliveira", _document, _address, _email);
            Assert.IsTrue(payment.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenTotalGreaterThanZero()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 0, "devlucasoliveira", _document, _address, _email);
            Assert.IsTrue(payment.Valid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenTotalPaidIsLowerThanTotal()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 7, "devlucasoliveira", _document, _address, _email);
            Assert.IsTrue(payment.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSucessWhenTotalPaidIsAreEqualsTotal()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "devlucasoliveira", _document, _address, _email);
            Assert.IsTrue(payment.Valid);
        }





    }



}