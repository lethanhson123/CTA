namespace Website.Models
{   
    public partial class BaseViewModel : BaseModel
    {
        public string? QueryString { get; set; }
        public IFormFile? File { get; set; }
        public List<IFormFile>? Files { get; set; }
        public Data.Model.Career? Career { get; set; }
        public List<Data.Model.Project>? Projects { get; set; }
        public List<Data.Model.About>? Abouts { get; set; }
        public List<Data.Model.Award>? Awards { get; set; }
        public List<Data.Model.News>? Newss { get; set; }
        public List<Data.Model.Ideas>? Ideass { get; set; }
        public List<Data.Model.Team>? Teams { get; set; }
        public int? PageIndex { get; set; }
        public bool? IsShowPage { get; set; }
    }
}
