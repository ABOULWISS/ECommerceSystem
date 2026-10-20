namespace ECommerceContractLair
{
    public enum PaymentMethod
    {
        CreditCard,
        PayPal,
        Cash,
        BankTransfer
    }

    public enum PaymentStatus
    {
        Pending,
        Success,
        Failed,
        Refunded
    }

    public class PaymentCoreDTO
    {
        public int PaymentId { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
        public decimal Amount { get; set; }
        public string TransactionId { get; set; } = string.Empty;
        public string GatewayResponse { get; set; } = string.Empty;
        public DateTime? PaidAt { get; set; }
        public int OrderId { get; set; }
    }
}
