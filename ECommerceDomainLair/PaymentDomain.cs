using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDomainLair
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

    public class PaymentDomain
    {
        [Key]
        public int PaymentId { get; set; }

        [Required]
        public PaymentMethod Method { get; set; }

        [Required]
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        [Required]
        public decimal Amount { get; set; }


        [Required]
        [MaxLength(100)]
        public string TransactionId { get; set; } = string.Empty;

        [Required]
        [MaxLength(500)]
        public string GatewayResponse { get; set; } = string.Empty;
        
        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? PaidAt { get; set; }   // nullable — only set once payment succeeds


        
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public OrderDomain Order { get; set; } = null!;




    }
}
