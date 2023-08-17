
namespace Business.Implement
{
    public class BannerBusiness : BaseBusiness<Banner, IBannerRepository>, IBannerBusiness
    {
        private readonly IBannerRepository _BannerRepository;
        public BannerBusiness(IBannerRepository BannerRepository) : base(BannerRepository)
        {
            _BannerRepository = BannerRepository;
        }
    }
}
