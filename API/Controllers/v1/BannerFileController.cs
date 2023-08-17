namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BannerFileController : BaseController<BannerFile, IBannerFileBusiness>
    {
        private readonly IBannerFileBusiness _BannerFileBusiness;
        public BannerFileController(IBannerFileBusiness BannerFileBusiness) : base(BannerFileBusiness)
        {
            _BannerFileBusiness = BannerFileBusiness;
        }
    }
}
