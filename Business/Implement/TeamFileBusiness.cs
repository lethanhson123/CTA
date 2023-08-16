
namespace Business.Implement
{
    public class TeamFileBusiness : BaseBusiness<TeamFile, ITeamFileRepository>, ITeamFileBusiness
    {
        private readonly ITeamFileRepository _TeamFileRepository;
        public TeamFileBusiness(ITeamFileRepository TeamFileRepository) : base(TeamFileRepository)
        {
            _TeamFileRepository = TeamFileRepository;
        }
    }
}
