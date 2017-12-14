namespace Enigma.ViewModels
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Current = new ViewModelLocator();

        private ViewModelLocator()
        {
            SettingsViewModel = new SettingsViewModel();
            DiagnosticsViewModel = new DiagnosticsViewModel();
        }

        public SettingsViewModel SettingsViewModel { get; }
        public DiagnosticsViewModel DiagnosticsViewModel { get; }
    }
}