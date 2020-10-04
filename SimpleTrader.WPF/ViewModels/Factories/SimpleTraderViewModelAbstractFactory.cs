using System;
using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public class SimpleTraderViewModelAbstractFactory : ISimpleTraderViewModelAbstractFactory
    {
        private readonly ISimpleTraderViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly ISimpleTraderViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;

        public SimpleTraderViewModelAbstractFactory(ISimpleTraderViewModelFactory<HomeViewModel> homeViewModelFactory,
            ISimpleTraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _portfolioViewModelFactory = portfolioViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                    break;
                case ViewType.Portfolio:
                    return _portfolioViewModelFactory.CreateViewModel();
                    break;
                default:
                    throw new ArgumentException("The type does not have a ViewModel", "viewType");
            }
        }
    }
}