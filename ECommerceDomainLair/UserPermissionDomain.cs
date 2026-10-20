






using System;
using System.ComponentModel.DataAnnotations;
 
namespace ECommerceDomainLair
{
    // Explicit join entity for User <-> Role (many-to-many).
    // Using an explicit join (instead of EF's implicit skip-navigation) lets us
    // add metadata later, e.g. AssignedAt, AssignedByUserID, ExpiresAt.
    public class UserPermissionDomain
    {


        [Key]
        [Required]
        public int UserPermissionID { get; set; }
 


        [Required]
        public int UserID { get; set; }
        public UserDomain? User { get; set; }
 


        [Required]
        public int PermissionID { get; set; }
        public PermissionDomain? Permission { get; set; }
 


        [Required]
        public DateTime AssignedAt { get; set; }



        
    }
}
 

