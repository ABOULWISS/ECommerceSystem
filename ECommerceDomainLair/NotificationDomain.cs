using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDomainLair
{
    public class NotificationDomain
    {


        [Key]
        [Required]
        public int NotificationId { get; set; }


        [Required]
        [MaxLength(500)]
        public string DynamicData { get; set; } = string.Empty;


        [Required]
        public bool IsRead { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; }




        [ForeignKey(nameof(CustomerId))]
        [Required]
        public int CustomerId { get; set; }
        public CustomerDomain Customer { get; set; } = null!;


        [ForeignKey(nameof(NotificationTypeId))]
        [Required]
        public int NotificationTypeId { get; set; }
        public NotificationTypeDomain NotificationType { get; set; } = null!;
    }
}
