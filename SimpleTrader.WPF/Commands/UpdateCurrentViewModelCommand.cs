using System;
using System.Windows.Input;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Factories;

namespace SimpleTrader.WPF.Commands
{
    internal class UpdateCurrentViewModelCommand : ICommand
    {
        private readonly INavigator _navigator;
        private readonly ISimpleTraderViewModelAbstractFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator,
            ISimpleTraderViewModelAbstractFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                var viewType = (ViewType) parameter;

                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}