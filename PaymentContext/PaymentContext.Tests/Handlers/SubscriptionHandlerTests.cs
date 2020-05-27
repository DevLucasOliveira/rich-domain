using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paymentcontext.Tests.Mocks;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;

namespace Paymentcontext.Tests
{
    [TestClass]
    public class SubscriptionHandlerCommandTests
    {
        // // Red, Green, Refactor

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Naruto";
            command.LastName = "Uzumaki";
            command.Email = "lucas@oliveira.com2";
            command.Document = "99999999999";
            command.BarCode = "12456789";
            command.BoletoNumber = "1234654987";
            command.PaymentNumber = "123121";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "ALDEIA FOLHA";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "naruto@uzumaki.com";
            command.Street = "folha";
            command.Number = "21";
            command.Neighborhood = "aldeia";
            command.City = "saergla";
            command.State = "awg";
            command.Country = "awrgaw";
            command.ZipCode = "1234567 ";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);

        }

    }
}