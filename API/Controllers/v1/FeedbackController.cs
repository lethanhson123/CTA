namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class FeedbackController : BaseController<Feedback, IFeedbackBusiness>
    {
        private readonly IFeedbackBusiness _FeedbackBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public FeedbackController(IFeedbackBusiness FeedbackBusiness, IWebHostEnvironment WebHostEnvironment) : base(FeedbackBusiness, WebHostEnvironment)
        {
            _FeedbackBusiness = FeedbackBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}
