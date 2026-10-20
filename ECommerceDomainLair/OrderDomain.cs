using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceDomainLair
{

    public enum OrderStatus

    {
        OrderCreated,
        OrderProcessing,
        OrderShipped,
        OrderDelivered,
        OrderCancelled,

    }
    public class OrderDomain
    {
        [Key]
        [Required]
        public int OrderID { get; set; }


        [Required]
        public decimal Subtotal { get; set; }


        public decimal DiscountAmount { get; set; }


        [Required]
        public decimal Tax { get; set; }


        [Required]
        public decimal Total { get; set; }


        [Required]
        [MaxLength(500)]
        public string ShippingAddressSnapShot { get; set; } = string.Empty;


        public DateTime CreatedAt { get; set; }



        public DateTime UpdatedAt { get; set; }

        public OrderStatus Status { get; set; } 





        public int CustomerId { get; set; }


        [ForeignKey(nameof(CustomerId))]
        public CustomerDomain Customer { get; set; } = null!;




        
        public int AddressId { get; set; }


        [ForeignKey(nameof(AddressId))]
        public AddressDomain Address { get; set; } = null!;



        public List<OrderItemsDomain> Items { get; set; } = new List<OrderItemsDomain>();

        public ICollection<OrderDiscountDomain> OrderDiscount { get; set; } = new List<OrderDiscountDomain>();

        public ICollection<PaymentDomain> Payments { get; set; } = new List<PaymentDomain>();

    }


}
