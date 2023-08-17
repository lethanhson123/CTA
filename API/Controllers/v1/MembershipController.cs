namespace API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MembershipController : BaseController<Membership, IMembershipBusiness>
    {
        private readonly IMembershipBusiness _MembershipBusiness;
        public MembershipController(IMembershipBusiness MembershipBusiness) : base(MembershipBusiness)
        {
            _MembershipBusiness = MembershipBusiness;
        }
    }
}
