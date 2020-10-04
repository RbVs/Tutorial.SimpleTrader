using System;
using System.Windows.Input;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
    class UpdateCurrentViewModelCommand : ICommand
    {
        private readonly INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType) parameter;

            switch (viewType)
            {
                case ViewType.Home:
                    _navigator.CurrentViewModel = new HomeViewModel();
                    break;
                case ViewType.Portfolio:
                    _navigator.CurrentViewModel = new PortfolioViewModel();
                    break;
                default:
                    break;
            }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
