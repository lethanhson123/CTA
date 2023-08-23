namespace Business
{
    public static class ConfigureService
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection services)
        {
            services.AddTransient<IAboutBusiness, AboutBusiness>();
            services.AddTransient<IAboutFileBusiness, AboutFileBusiness>();
            services.AddTransient<IAwardBusiness, AwardBusiness>();
            services.AddTransient<IAwardFileBusiness, AwardFileBusiness>();
            services.AddTransient<IBannerBusiness, BannerBusiness>();
            services.AddTransient<IBannerFileBusiness, BannerFileBusiness>();
            services.AddTransient<ICandidateBusiness, CandidateBusiness>();
            services.AddTransient<ICareerBusiness, CareerBusiness>();
            services.AddTransient<ICareerFileBusiness, CareerFileBusiness>();
            services.AddTransient<ICategoryIdeasBusiness, CategoryIdeasBusiness>();
            services.AddTransient<ICategoryLanguageBusiness, CategoryLanguageBusiness>();
            services.AddTransient<IContactBusiness, ContactBusiness>();
            services.AddTransient<IContactFileBusiness, ContactFileBusiness>();
            services.AddTransient<IEmailBusiness, EmailBusiness>();
            services.AddTransient<IFeedbackBusiness, FeedbackBusiness>();
            services.AddTransient<IIdeasBusiness, IdeasBusiness>();
            services.AddTransient<IIdeasFileBusiness, IdeasFileBusiness>();
            services.AddTransient<IMembershipBusiness, MembershipBusiness>();
            services.AddTransient<IMenuBusiness, MenuBusiness>();
            services.AddTransient<INewsBusiness, NewsBusiness>();
            services.AddTransient<INewsFileBusiness, NewsFileBusiness>();
            services.AddTransient<INewsletterBusiness, NewsletterBusiness>();
            services.AddTransient<IProjectBusiness, ProjectBusiness>();
            services.AddTransient<IProjectFileBusiness, ProjectFileBusiness>();
            services.AddTransient<IQuoteBusiness, QuoteBusiness>();
            services.AddTransient<IServiceBusiness, ServiceBusiness>();
            services.AddTransient<IServiceFileBusiness, ServiceFileBusiness>();
            services.AddTransient<ISocialNetworkBusiness, SocialNetworkBusiness>();
            services.AddTransient<ITeamBusiness, TeamBusiness>();
            services.AddTransient<ITeamFileBusiness, TeamFileBusiness>();

            services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));
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
            services.AddTransient<IAwardFileRepository, AwardFileRepository>();
            services.AddTransient<IAwardRepository, AwardRepository>();
            services.AddTransient<IBannerFileRepository, BannerFileRepository>();
            services.AddTransient<IBannerRepository, BannerRepository>();
            services.AddTransient<ICandidateRepository, CandidateRepository>();
            services.AddTransient<ICareerFileRepository, CareerFileRepository>();
            services.AddTransient<ICareerRepository, CareerRepository>();
            services.AddTransient<ICategoryIdeasRepository, CategoryIdeasRepository>();
            services.AddTransient<ICategoryLanguageRepository, CategoryLanguageRepository>();
            services.AddTransient<IContactFileRepository, ContactFileRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<IIdeasFileRepository, IdeasFileRepository>();
            services.AddTransient<IIdeasRepository, IdeasRepository>();
            services.AddTransient<IMembershipRepository, MembershipRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<INewsFileRepository, NewsFileRepository>();
            services.AddTransient<INewsletterRepository, NewsletterRepository>();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<IProjectFileRepository, ProjectFileRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IQuoteRepository, QuoteRepository>();
            services.AddTransient<IServiceFileRepository, ServiceFileRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<ISocialNetworkRepository, SocialNetworkRepository>();
            services.AddTransient<ITeamFileRepository, TeamFileRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();

            return services;
        }
    }
}
