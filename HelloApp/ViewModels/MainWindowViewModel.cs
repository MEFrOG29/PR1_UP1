using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HelloApp.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        public ViewModelBase currentPage;

        public static NavigationService Navigation {  get; private set; }

        [RelayCommand]
        private void Authorization()
        {
            MainWindowViewModel.Navigation.NavigateTo(new AuthorizationViewModel());
        }

        [RelayCommand]
        private void Registration()
        {
            MainWindowViewModel.Navigation.NavigateTo(new RegistrationViewModel());
        }

        public MainWindowViewModel()
        {
            Navigation = new NavigationService(this);
            Navigation.NavigateTo(new AuthorizationViewModel());
        }
    }
}
