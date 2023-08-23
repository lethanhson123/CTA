
namespace Business.Implement
{
    public class SocialNetworkBusiness : BaseBusiness<SocialNetwork, ISocialNetworkRepository>, ISocialNetworkBusiness
    {
        private readonly ISocialNetworkRepository _SocialNetworkRepository;
        public SocialNetworkBusiness(ISocialNetworkRepository SocialNetworkRepository) : base(SocialNetworkRepository)
        {
            _SocialNetworkRepository = SocialNetworkRepository;
        }
    }
}
