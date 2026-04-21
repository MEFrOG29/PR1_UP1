using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HelloApp.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly NavigationService _navigation;

        [ObservableProperty]
        private ViewModelBase currentPage;


        public MainWindowViewModel(NavigationService navigation)
        {
            _navigation = navigation;

            _navigation.PropertyChanged += Navigation_PropertyChanged;

            _navigation.NavigateTo<AuthorizationViewModel>();

            CurrentPage = _navigation.CurrentView;
        }

        private void Navigation_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(NavigationService.CurrentView))
            {
                // Мы берем НОВОЕ значение из сервиса и кладем в СВОЕ свойство
                CurrentPage = _navigation.CurrentView;
            }
        }
    }
}
