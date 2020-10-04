using System;
using System.Windows.Input;
using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
    internal class UpdateCurrentViewModelCommand : ICommand
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
                var viewType = (ViewType) parameter;

                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel =
                            new HomeViewModel(MajorIndexListingViewModel.LoadMajorIndexViewModel(new MajorIndexService()));
                        break;
                    case ViewType.Portfolio:
                        _navigator.CurrentViewModel = new PortfolioViewModel();
                        break;
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}