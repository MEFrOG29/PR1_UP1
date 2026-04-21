using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloApp.ViewModels
{
    public partial class RegistrationViewModel : ViewModelBase
    {
        [ObservableProperty]
        private UserCreditionals _user = new();

        private readonly NavigationService _navigation;

        public RegistrationViewModel(NavigationService navigation)
        {
            _navigation = navigation;
        }

        [RelayCommand]
        private void Authorization()
        {
            _navigation.GoBack();
        }
    }
}
