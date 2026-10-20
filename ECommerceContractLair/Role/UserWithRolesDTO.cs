using System.Collections.Generic;

namespace ECommerceContractLair
{


    public class UserWithRolesDTO
    {

        public UserCoreDTO User { get; set; } = new();
        public List<string> Roles { get; set; } = new();
        public List<string> Permissions { get; set; } = new(); // flattened, for JWT claim population
        
    }


    
}