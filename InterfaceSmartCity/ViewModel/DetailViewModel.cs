using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using InterfaceSmartCity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;
using System.ComponentModel;

namespace InterfaceSmartCity.ViewModel
{
    class DetailViewModel
    {

        private Geopoint _location = null;

        public Geopoint Location
        {
            get { return _location; }
            set
            {
                if (_location == value)
                {
                    return;
                }
                _location = value;
                OnNotifyPropertyChanged("Location");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Announcement SelectedAnnouncement { get; set; }

        private INavigationService _navigationService;
        public DetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Messenger.Default.Register<Announcement>(this, a => { SelectedAnnouncement = a; });

            /*Location = new Geopoint(new BasicGeoposition()
            {
                Latitude = SelectedAnnouncement.Parking.Latitude,
                Longitude = SelectedAnnouncement.Parking.Latitude
            });*/
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
