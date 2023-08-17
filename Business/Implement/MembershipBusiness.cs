
namespace Business.Implement
{
    public class MembershipBusiness : BaseBusiness<Membership, IMembershipRepository>, IMembershipBusiness
    {
        private readonly IMembershipRepository _MembershipRepository;
        public MembershipBusiness(IMembershipRepository MembershipRepository) : base(MembershipRepository)
        {
            _MembershipRepository = MembershipRepository;
        }
    }
}
