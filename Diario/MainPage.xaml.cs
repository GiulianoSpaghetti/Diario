using CommunityToolkit.Maui.Alerts;
using SQLite;
using System.Runtime.Intrinsics.Arm;

namespace Diario
{
    public partial class MainPage : ContentPage
    {
        private static string cs = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "test.db");
        private static SQLiteConnection con;
        private static string s;
        private static int id;
        private static SQLite.TableQuery<Item> query;
        private static List<Item> elementi;
        public static MainPage Instance = null;
        public MainPage()
        {
            InitializeComponent();
            Read.Text = App.d["Leggi"] as string;
            Modify.Text = App.d["Modifica"] as string;
            Insert.Text = App.d["Inserisci"] as string;
            Delete.Text = App.d["Elimina"] as string;
            Title = App.d["Home"] as string;
            con = new SQLiteConnection(cs);
            con.CreateTable<Item>();
            AggiornaEntita();
            if (Instance == null)
                Instance = this;
        }

        private void LeggiClicked(object sender, EventArgs e)
        {
            try
            {
                id = GetIdFromEntita();
            } catch (Exception ex)
            {
                Avviso(ex.Message);
                return;
            }
            query = con.Table<Item>().Where(v => v.Id.Equals(id));
            foreach (Item item in query)
            {
                sstring.Text=item.testo;
            }
        }

        private void ModificaClicked(object sender, EventArgs e)
        {
            try
            {
                id = GetIdFromEntita();
            }
            catch (Exception ex)
            {
                Avviso(ex.Message);
                return;
            }
            query = con.Table<Item>().Where(v => v.Id.Equals(id));
            foreach (Item item in query)
            {
                item.testo=sstring.Text;
                item.data = DateTime.Now;
                con.Update(item);
            }
            AggiornaEntita();

        }
        private void InserisciClicked(object sender, EventArgs e)
        {
            Item item = new Item();
            item.data = DateTime.Now;
            item.testo = sstring.Text;
            con.Insert(item);
            AggiornaEntita();
        }
        private void EliminaClicked(object sender, EventArgs e)
        {
            try
            {
                id = GetIdFromEntita();
            }
            catch (Exception ex)
            {
                Avviso(ex.Message);
                return;
            }
            query = con.Table<Item>().Where(v => v.Id.Equals(id));
            foreach (Item item in query)
            {
                con.Delete(item);
            }
            AggiornaEntita();
        }
        private int GetIdFromEntita()
        {
            if (Dati.Items.Count == 0)
                throw new Exception(App.d["DatabaseVuoto"] as string);
            s = Dati.SelectedItem.ToString();
            return Int32.Parse(s.Substring(0, s.IndexOf("-") - 1));

        }

        public void AggiornaEntita(DateTime? data=null)
        {
            sstring.Text = "";
            Dati.Items.Clear();
            if (data==null)
                elementi=con.Table<Item>().ToList();
            else {
                query = con.Table<Item>().Where(v => v.data >= data);
                elementi = query.ToList();
            }
            if (elementi.Count > 0)
            {
                foreach (Item elemento in elementi)
                    Dati.Items.Add($"{elemento.Id} - {elemento.data}");
                Dati.SelectedIndex = 0;
            }
            if (data != null)
            {
                if (elementi.Count > 0)
                    Avviso($"{App.d["RicercaEffettuata"]} {elementi.Count} {App.d["elementi"]}.");
                else
                    Avviso($"{App.d["ImpossibileTrovareElementi"]}");
            }
            Dati.IsEnabled = elementi.Count>0;
        }
        private async void Avviso(String s)
        {
            await Snackbar.Make(s).Show(App.cancellationTokenSource.Token);
        }

    }

}
