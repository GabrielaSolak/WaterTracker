namespace WaterTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(settingsPage), typeof(settingsPage));
        }
    }
}
