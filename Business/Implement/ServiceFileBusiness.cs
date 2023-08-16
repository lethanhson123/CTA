
namespace Business.Implement
{
    public class ServiceFileBusiness : BaseBusiness<ServiceFile, IServiceFileRepository>, IServiceFileBusiness
    {
        private readonly IServiceFileRepository _ServiceFileRepository;
        public ServiceFileBusiness(IServiceFileRepository ServiceFileRepository) : base(ServiceFileRepository)
        {
            _ServiceFileRepository = ServiceFileRepository;
        }
    }
}
