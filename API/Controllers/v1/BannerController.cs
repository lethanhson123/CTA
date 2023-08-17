namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BannerController : BaseController<Banner, IBannerBusiness>
    {
        private readonly IBannerBusiness _BannerBusiness;
        public BannerController(IBannerBusiness BannerBusiness) : base(BannerBusiness)
        {
            _BannerBusiness = BannerBusiness;
        }
    }
}
