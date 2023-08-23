namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class QuoteController : BaseController<Quote, IQuoteBusiness>
    {
        private readonly IQuoteBusiness _QuoteBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public QuoteController(IQuoteBusiness QuoteBusiness, IWebHostEnvironment WebHostEnvironment) : base(QuoteBusiness, WebHostEnvironment)
        {
            _QuoteBusiness = QuoteBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}
