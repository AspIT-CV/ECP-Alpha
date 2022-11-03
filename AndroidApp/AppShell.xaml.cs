namespace AndroidApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(OrganiserPage), typeof(OrganiserPage));
            Routing.RegisterRoute(nameof(VolunteerPage), typeof(VolunteerPage));
        }
    }
}