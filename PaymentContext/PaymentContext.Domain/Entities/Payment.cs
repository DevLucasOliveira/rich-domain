using System;

namespace PaymentContext.Domain.Entities
{
    public class Payment 
    {
        public string Number { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set;} 
        public string Payer { get; set; }
        public string Document { get; set; }
        public string Address { get; set; }
    }
    public class BoletoPayment : Payment
    {
        public string BarCode { get; set; }
        public string boletoNumber { get; set; }
    }
    public class CreditPayment : Payment 
    {
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }
    }
    public class PayPalment : Payment
    {
        public string TransactionCode { get; set; }
    }
}