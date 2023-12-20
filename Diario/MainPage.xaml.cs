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
        public MainPage()
        {
            InitializeComponent();
            con = new SQLiteConnection(cs);
            con.CreateTable<Item>();
            filtraPerData.Date = DateTime.Now;
            AggiornaEntita();
        }

        private void LeggiClicked(object sender, EventArgs e)
        {
            Errore.Text = "";
            try
            {
                id = GetIdFromEntita();
            } catch (Exception ex)
            {
                Errore.Text = ex.Message;
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
            Errore.Text = "";
            try
            {
                id = GetIdFromEntita();
            }
            catch (Exception ex)
            {
                Errore.Text = ex.Message;
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
            Errore.Text = "";
            Item item = new Item();
            item.data = DateTime.Now;
            item.testo = sstring.Text;
            con.Insert(item);
            AggiornaEntita();
        }

        private void FiltraPerClicked(object sender, EventArgs e)
        {
            AggiornaEntita(filtraPerData.Date);
        }
        private void EliminaClicked(object sender, EventArgs e)
        {
            Errore.Text = "";
            try
            {
                id = GetIdFromEntita();
            }
            catch (Exception ex)
            {
                Errore.Text = ex.Message;
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
                throw new Exception("Database vuoto");
            s = Dati.SelectedItem.ToString();
            return Int32.Parse(s.Substring(0, s.IndexOf("-") - 1));

        }

        private void AggiornaEntita(DateTime? data=null)
        {
            Dati.Items.Clear();
            if (data==null)
                elementi=con.Table<Item>().ToList();
            else {
                query = con.Table<Item>().Where(v => v.data >= data);
                elementi = query.ToList();
            }
            if (elementi.Count > 0) {
                foreach (Item elemento in elementi)
                    Dati.Items.Add($"{elemento.Id} - {elemento.data}");
                Dati.SelectedIndex = 0;
            }
        }

    }

}
