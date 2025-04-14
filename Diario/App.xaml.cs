using System.Globalization;

namespace Diario
{
    public partial class App : Application
    {
        private static ResourceDictionary dic;
        public static ResourceDictionary d { get => dic; }
        public static readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public App()
        {
            InitializeComponent();
            try
            {
                dic = Resources[CultureInfo.CurrentCulture.TwoLetterISOLanguageName] as ResourceDictionary;

            }
            catch (Exception ex)
            {
                dic = Resources["en"] as ResourceDictionary;
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}