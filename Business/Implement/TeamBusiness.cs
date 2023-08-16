
namespace Business.Implement
{
    public class TeamBusiness : BaseBusiness<Team, ITeamRepository>, ITeamBusiness
    {
        private readonly ITeamRepository _TeamRepository;
        public TeamBusiness(ITeamRepository TeamRepository) : base(TeamRepository)
        {
            _TeamRepository = TeamRepository;
        }
    }
}
