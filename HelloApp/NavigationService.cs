using CommunityToolkit.Mvvm.ComponentModel;
using HelloApp.ViewModels;
using HelloApp.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloApp
{
    public partial class NavigationService: ObservableObject
    {
        private readonly Stack<ViewModelBase> history = new();

        [ObservableProperty]
        private ViewModelBase currentView;

        public NavigationService()
        {
        }

        public void NavigateTo<T>(T viewModel, Action<T> action = null) where T : ViewModelBase
        {
            action?.Invoke(viewModel);

            if(CurrentView!= null)
            {
                history.Push(CurrentView);
            }

            CurrentView = viewModel;
        }

        public void NavigateTo<T>(Action<T>? action = null) where T :ViewModelBase
        {
            var viewModel = App.Services.GetRequiredService<T>();
            NavigateTo(viewModel, action);
        }


        public void GoBack()
        {
            if(history.Count > 0)
            {
                CurrentView = history.Pop();
            }
        }
    }
}
