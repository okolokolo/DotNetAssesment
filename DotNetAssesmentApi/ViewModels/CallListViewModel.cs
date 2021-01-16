namespace DotNetAssesmentApi.ViewModels
{
    public class CallListViewModel
    {
        public CallListViewModel()
        {
            Name = new NameViewModel();
        }
        public NameViewModel Name { get; set; }
        public string Phone { get; set; }
    }
}
