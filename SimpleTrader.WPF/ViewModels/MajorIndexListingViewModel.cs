using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.WPF.ViewModels
{
    public class MajorIndexListingViewModel : ViewModelBase
    {
        private readonly IMajorIndexService _majorIndexService;
        private MajorIndex _dowJones;
        private MajorIndex _nasdaq;
        private MajorIndex _sp500;

        public MajorIndexListingViewModel(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public MajorIndex DowJones
        {
            get => _dowJones;
            set
            {
                _dowJones = value;
                OnPropertyChanged(nameof(DowJones));
            }
        }

        public MajorIndex Nasdaq
        {
            get => _nasdaq;
            set
            {
                _nasdaq = value;
                OnPropertyChanged(nameof(Nasdaq));
            }
        }

        public MajorIndex SP500
        {
            get => _sp500;
            set
            {
                _sp500 = value;
                OnPropertyChanged(nameof(SP500));
            }
        }

        public static MajorIndexListingViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            var majorIndexViewModel = new MajorIndexListingViewModel(majorIndexService);
            majorIndexViewModel.LoadMajorIndex();
            return majorIndexViewModel;
        }

        private void LoadMajorIndex()
        {
            _majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith(async task =>
            {
                if (task.Exception == null) DowJones = await task.ConfigureAwait(false);
            });
            _majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith(async task =>
            {
                if (task.Exception == null) Nasdaq = await task.ConfigureAwait(false);
            });
            _majorIndexService.GetMajorIndex(MajorIndexType.SP500).ContinueWith(async task =>
            {
                if (task.Exception == null) SP500 = await task.ConfigureAwait(false);
            });
        }
    }
}