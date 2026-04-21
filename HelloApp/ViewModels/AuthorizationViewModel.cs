using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloApp.ViewModels
{
    public partial class AuthorizationViewModel : ViewModelBase
    {
        public string api => App.Configuration.GetSection("ApiKeys")["SomeApi"];

        private readonly NavigationService _navigation;

        public AuthorizationViewModel(NavigationService navigation)
        {
            _navigation = navigation;
        }

        [RelayCommand]
        private void Registration()
        {
            _navigation.NavigateTo<RegistrationViewModel>();
        }
    }
}
