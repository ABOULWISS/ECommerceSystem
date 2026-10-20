using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerceDomainLair
{
    public class NotificationTypeDomain
    {

        [Key]
        [Required]
        public int NotificationTypeId { get; set; }


        [Required]
        public string Body { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;


        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = string.Empty;



        public ICollection<NotificationDomain> Notifications { get; set; } = new List<NotificationDomain>();
    }
}
