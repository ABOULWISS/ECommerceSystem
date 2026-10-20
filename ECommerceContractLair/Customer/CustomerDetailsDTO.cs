



namespace ECommerceContractLair
{
    public class CustomerDetailsDTO
    {
        public CustomerCoreDTO Customer { get; set; } = null!;
        public UserCoreDTO User { get; set; } = null!;
        public ICollection<AddressCoreDTO> Addresses { get; set; } = new List<AddressCoreDTO>();
    }
}
