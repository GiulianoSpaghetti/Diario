namespace Diario
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Home.Title = App.d["Home"] as string;
            Search.Title = App.d["Cerca"] as string;
            Informazioni.Title = App.d["Informazioni"] as string;
        }
    }
}
