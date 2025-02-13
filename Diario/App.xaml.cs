using System.Globalization;

namespace Diario
{
    public partial class App : Application
    {
        public static ResourceDictionary d;
        public static readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public App()
        {
            InitializeComponent();
            try
            {
                d = Resources[CultureInfo.CurrentCulture.TwoLetterISOLanguageName] as ResourceDictionary;

            }
            catch (Exception ex)
            {
                d = Resources["en"] as ResourceDictionary;
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}