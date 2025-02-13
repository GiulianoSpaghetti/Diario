namespace Diario
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Home.Title = App.d["Home"] as string;
            Informazioni.Title = App.d["Informazioni"] as string;
        }
    }
}
