namespace Diario;

public partial class InfoPage : ContentPage
{
	public InfoPage()
	{
		InitializeComponent();
        Title = App.d["Informazioni"] as string;
    }
}