using System.ComponentModel.DataAnnotations;
 
namespace ECommerceDomainLair
{
    // Explicit join entity for Role <-> Permission (many-to-many).
    public class RolePermissionDomain
    {
        [Key]
        [Required]
        public int RolePermissionID { get; set; }
 
        [Required]
        public int RoleID { get; set; }
        public RoleDomain? Role { get; set; }
 
        [Required]
        public int PermissionID { get; set; }
        public PermissionDomain? Permission { get; set; }
    }
}
 