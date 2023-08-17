namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BannerController : BaseController<Banner, IBannerBusiness>
    {
        private readonly IBannerBusiness _BannerBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public BannerController(IBannerBusiness BannerBusiness, IWebHostEnvironment WebHostEnvironment) : base(BannerBusiness, WebHostEnvironment)
        {
            _BannerBusiness = BannerBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}
