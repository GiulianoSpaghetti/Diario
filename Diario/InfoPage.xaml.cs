namespace Diario;

public partial class InfoPage : ContentPage
{

	public readonly Uri uri = new Uri("https://github.com/giulianospaghetti/diario");
	public InfoPage()
	{
		InitializeComponent();
        Title = App.Dictionary["Informazioni"] as string;
    }

	private void OnSito_Click(object sender, EventArgs e)
	{
		Browser.OpenAsync(uri);
	}
}