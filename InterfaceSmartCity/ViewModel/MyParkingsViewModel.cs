using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using InterfaceSmartCity.Model;
using InterfaceSmartCity.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InterfaceSmartCity.ViewModel
{
    class MyParkingsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService = null;

        public MyParkingsViewModel(INavigationService navigationService)
        {
            loadParking();
            _navigationService = navigationService;
        }

        private ObservableCollection<Parking> _parking;
        public ObservableCollection<Parking> Parkings
        {
            get { return _parking; }
            set
            {
                _parking = value;
                RaisePropertyChanged("Parkings");
            }
        }

        private Parking _selecteParking;
        public Parking SelectedParking
        {
            get { return _selecteParking; }
            set
            {
                _selecteParking = value;

                if (_selecteParking != null)
                {
                    RaisePropertyChanged("SelectedParking");
                }
            }
        }


        private async void loadParking()
        {
            ParkingDAO parkingDAO = new ParkingDAO();
            Parkings = new ObservableCollection<Parking>(await parkingDAO.getMyParkings());
        }

        //Profil
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

        //Remove
        private ICommand _removeCommand;
        public ICommand RemoveParkingCommand
        {
            get
            {
                if (_removeCommand == null)
                    _removeCommand = new RelayCommand(() => Remove());
                return _removeCommand;
            }
        }

        private void Remove()
        {
            if(SelectedParking != null)
            {
                ParkingDAO parkingDAO = new ParkingDAO();
                parkingDAO.removeParking(SelectedParking);
                loadParking();
            }
        }

        //Add
        private ICommand _addCommand;
        public ICommand AddParkingCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand(() => AddParking());
                return _addCommand;
            }
        }

        private void AddParking()
        {
            _navigationService.NavigateTo("CreateParking");
        }

        //Refresh
        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                    _refreshCommand = new RelayCommand(() => loadParking());
                return _refreshCommand;
            }
        }
    }
}
