namespace Enigma.ViewModels
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Current = new ViewModelLocator();

        private ViewModelLocator()
        {
            SettingsViewModel = new SettingsViewModel();
        }

        public SettingsViewModel SettingsViewModel { get; }
    }
}