namespace ECommerceContractLair
{



    public class UserCoreDTO
    {
        public int UserID { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string ? Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }



}
