namespace Business
{
    public static class ConfigureService
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddTransient<IAboutBusiness, AboutBusiness>();
            services.AddTransient<IAboutFileBusiness, AboutFileBusiness>();
            services.AddTransient<ICareerBusiness, CareerBusiness>();
            services.AddTransient<ICareerFileBusiness, CareerFileBusiness>();
            services.AddTransient<ICategoryLanguageBusiness, CategoryLanguageBusiness>();
            services.AddTransient<IContactBusiness, ContactBusiness>();
            services.AddTransient<IContactFileBusiness, ContactFileBusiness>();
            services.AddTransient<IIdeasBusiness, IdeasBusiness>();
            services.AddTransient<IIdeasFileBusiness, IdeasFileBusiness>();
            services.AddTransient<IMembershipBusiness, MembershipBusiness>();
            services.AddTransient<INewsBusiness, NewsBusiness>();
            services.AddTransient<INewsFileBusiness, NewsFileBusiness>();
            services.AddTransient<IProjectBusiness, ProjectBusiness>();
            services.AddTransient<IProjectFileBusiness, ProjectFileBusiness>();
            services.AddTransient<IServiceBusiness, ServiceBusiness>();
            services.AddTransient<IServiceFileBusiness, ServiceFileBusiness>();
            services.AddTransient<ITeamBusiness, TeamBusiness>();
            services.AddTransient<ITeamFileBusiness, TeamFileBusiness>();           

            return services;
        }
        public static IServiceCollection AddContextService(this IServiceCollection services)
        {
            services.AddDbContext<CTAContext>(opts =>
            {
            });
            return services;
        }
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            services.AddTransient<IAboutFileRepository, AboutFileRepository>();
            services.AddTransient<IAboutRepository, AboutRepository>();
            services.AddTransient<ICareerFileRepository, CareerFileRepository>();
            services.AddTransient<ICareerRepository, CareerRepository>();
            services.AddTransient<ICategoryLanguageRepository, CategoryLanguageRepository>();
            services.AddTransient<IContactFileRepository, ContactFileRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IIdeasFileRepository, IdeasFileRepository>();
            services.AddTransient<IIdeasRepository, IdeasRepository>();
            services.AddTransient<IMembershipRepository, MembershipRepository>();
            services.AddTransient<INewsFileRepository, NewsFileRepository>();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<IProjectFileRepository, ProjectFileRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IServiceFileRepository, ServiceFileRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<ITeamFileRepository, TeamFileRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();

            return services;
        }
    }
}
