using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace InterfaceSmartCity.ViewModel {
    class SearchViewModel {



        private INavigationService _navigationService = null;

        public SearchViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        //Search
        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                    _searchCommand = new RelayCommand(() => Search());
                return _searchCommand;
            }
        }

        private void Search()
        {
           
        }

        //Go Back
        private ICommand _goBackCommand;
        public ICommand GoBackCommand
        {
            get
            {
                if (_goBackCommand == null)
                    _goBackCommand = new RelayCommand(() => GoBack());
                return _goBackCommand;
            }
        }

        private void GoBack()
        {
            _navigationService.NavigateTo("Welcome");
        }






    }
}
