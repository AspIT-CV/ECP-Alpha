namespace AndroidApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ArrangerPage), typeof(ArrangerPage));
        }
    }
}