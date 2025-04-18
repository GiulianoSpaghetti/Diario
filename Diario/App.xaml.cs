using System.Globalization;

namespace Diario
{
    public partial class App : Application
    {
        public static ResourceDictionary Dictionary { get; init; }
        public static readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        public App()
        {
            InitializeComponent();
            try
            {
                Dictionary = Resources[CultureInfo.CurrentCulture.TwoLetterISOLanguageName] as ResourceDictionary;

            }
            catch (Exception ex)
            {
                Dictionary = Resources["en"] as ResourceDictionary;
            }
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}