


using System;
using System.ComponentModel.DataAnnotations;
 
namespace ECommerceDomainLair
{
    // Explicit join entity for User <-> Role (many-to-many).
    // Using an explicit join (instead of EF's implicit skip-navigation) lets us
    // add metadata later, e.g. AssignedAt, AssignedByUserID, ExpiresAt.
    public class UserRoleDomain
    {
        [Key]
        [Required]
        public int UserRoleID { get; set; }
 
        [Required]
        public int UserID { get; set; }
        public UserDomain? User { get; set; }
 
        [Required]
        public int RoleID { get; set; }
        public RoleDomain? Role { get; set; }
 
        [Required]
        public DateTime AssignedAt { get; set; }
    }
}
 


 
