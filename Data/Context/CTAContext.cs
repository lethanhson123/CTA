namespace Data.Context
{
    public partial class CTAContext : DbContext
    {
        public CTAContext()
        {
        }
        public CTAContext(DbContextOptions<CTAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Data.Model.About> About { get; set; }
        public virtual DbSet<Data.Model.AboutFile> AboutFile { get; set; }
        public virtual DbSet<Data.Model.Banner> Banner { get; set; }
        public virtual DbSet<Data.Model.BannerFile> BannerFile { get; set; }
        public virtual DbSet<Data.Model.Career> Career { get; set; }
        public virtual DbSet<Data.Model.CareerFile> CareerFile { get; set; }
        public virtual DbSet<Data.Model.CategoryLanguage> CategoryLanguage { get; set; }
        public virtual DbSet<Data.Model.Contact> Contact { get; set; }
        public virtual DbSet<Data.Model.ContactFile> ContactFile { get; set; }
        public virtual DbSet<Data.Model.Ideas> Ideas { get; set; }
        public virtual DbSet<Data.Model.IdeasFile> IdeasFile { get; set; }
        public virtual DbSet<Data.Model.Membership> Membership { get; set; }
        public virtual DbSet<Data.Model.News> News { get; set; }
        public virtual DbSet<Data.Model.NewsFile> NewsFile { get; set; }
        public virtual DbSet<Data.Model.Project> Project { get; set; }
        public virtual DbSet<Data.Model.ProjectFile> ProjectFile { get; set; }
        public virtual DbSet<Data.Model.Service> Service { get; set; }
        public virtual DbSet<Data.Model.ServiceFile> ServiceFile { get; set; }
        public virtual DbSet<Data.Model.Team> Team { get; set; }
        public virtual DbSet<Data.Model.TeamFile> TeamFile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GlobalHelper.SQLServerConectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
