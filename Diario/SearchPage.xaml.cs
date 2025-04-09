namespace Diario;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
		InitializeComponent();
        filtraPerData.Date = DateTime.Now;
        Search.Text = App.d["Ricerca"] as string;
        Title = App.d["Cerca"] as string;
    }

    private void FiltraPerClicked(object sender, EventArgs e)
    {
        MainPage.Instance.AggiornaEntita(filtraPerData.Date);
        Shell.Current.GoToAsync("//MainPage");
    }
}