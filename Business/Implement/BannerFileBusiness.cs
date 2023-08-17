
namespace Business.Implement
{
    public class BannerFileBusiness : BaseBusiness<BannerFile, IBannerFileRepository>, IBannerFileBusiness
    {
        private readonly IBannerFileRepository _BannerFileRepository;
        public BannerFileBusiness(IBannerFileRepository BannerFileRepository) : base(BannerFileRepository)
        {
            _BannerFileRepository = BannerFileRepository;
        }
    }
}
