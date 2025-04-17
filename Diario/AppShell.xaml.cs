namespace Diario
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Home.Title = App.Dictionary["Home"] as string;
            Search.Title = App.Dictionary["Cerca"] as string;
            Informazioni.Title = App.Dictionary["Informazioni"] as string;
        }
    }
}
