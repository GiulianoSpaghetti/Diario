namespace Diario;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		InitializeComponent();
        filtraPerData.Date = DateTime.Now;
        Search.Text = App.Dictionary["Ricerca"] as string;
        Title = App.Dictionary["Cerca"] as string;
    }

    private void FiltraPerClicked(object sender, EventArgs e)
    {
        MainPage.MainPageInstance.AggiornaEntita(filtraPerData.Date);
        Shell.Current.GoToAsync("//MainPage");
    }
}