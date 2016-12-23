using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using InterfaceSmartCity.Model;
using InterfaceSmartCity.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace InterfaceSmartCity.ViewModel {
    class SearchViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private String _priceMin;
        private String _priceMax;
        private String _infosSearch;

        private INavigationService _navigationService = null;

        public SearchViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public String PriceMin
        {
            get { return _priceMin; }
            set
            {
                _priceMin = value;
                RaisePropertyChanged("PriceMin");
            }
        }

        public String PriceMax
        {
            get { return _priceMax; }
            set
            {
                _priceMax = value;
                RaisePropertyChanged("PriceMax");
            }
        }

        public String InfosSearch
        {
            get { return _infosSearch; }
            set
            {
                _infosSearch = value;
                RaisePropertyChanged("InfosSearch");
            }
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
            int priceMi;
            int priceMa;
            int[] price = new int[2];

            if(PriceMin != null || PriceMax != null)
                {
                    if (Int32.TryParse(PriceMin, out priceMi))
                    {
                        if (Int32.TryParse(PriceMax, out priceMa))
                        {

                            if(priceMi < 0)
                            {
                                InfosSearch = "Min price must be > 0 !";
                            }
                            else
                            {
                                price[0] = priceMi;
                                price[1] = priceMa;

                                _navigationService.NavigateTo("Welcome");
                                Messenger.Default.Send(price);
                            }
                            
                         }
                        else
                        {
                            InfosSearch = "Price must be an integer number !";
                        }
                    }
                    else
                    {
                        InfosSearch = "Price must be an integer number !";
                    }
                 }
            else
            {
                InfosSearch = "You have to choose a min and a max !";
            }
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
