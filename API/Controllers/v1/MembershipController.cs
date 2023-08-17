namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MembershipController : BaseController<Membership, IMembershipBusiness>
    {
        private readonly IMembershipBusiness _MembershipBusiness;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public MembershipController(IMembershipBusiness MembershipBusiness, IWebHostEnvironment WebHostEnvironment) : base(MembershipBusiness, WebHostEnvironment)
        {
            _MembershipBusiness = MembershipBusiness;
            _WebHostEnvironment = WebHostEnvironment;
        }
    }
}
