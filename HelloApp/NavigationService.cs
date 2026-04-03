using HelloApp.ViewModels;
using HelloApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloApp
{
    public class NavigationService
    {
        private readonly Stack<ViewModelBase> history = new();
        private readonly MainWindowViewModel _mainWindowViewModel;
        
        public NavigationService(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public void NavigateTo<T>(T viewModel, Action<T> action = null) where T : ViewModelBase
        {
            action?.Invoke(viewModel);

            if(_mainWindowViewModel.CurrentPage != null)
            {
                history.Push(_mainWindowViewModel.CurrentPage);
            }

            _mainWindowViewModel.CurrentPage = viewModel;
        }

        public void GoBack()
        {
            if(history.Count > 0)
            {
                _mainWindowViewModel.CurrentPage = history.Pop();
            }
        }
    }
}
