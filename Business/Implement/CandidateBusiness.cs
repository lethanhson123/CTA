
namespace Business.Implement
{
    public class CandidateBusiness : BaseBusiness<Candidate, ICandidateRepository>, ICandidateBusiness
    {
        private readonly ICandidateRepository _CandidateRepository;
        public CandidateBusiness(ICandidateRepository CandidateRepository) : base(CandidateRepository)
        {
            _CandidateRepository = CandidateRepository;
        }
    }
}
