using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using InterfaceSmartCity.Exceptions;
using InterfaceSmartCity.Model;
using InterfaceSmartCity.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InterfaceSmartCity.ViewModel {
    class CreateAnnouncementViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private String _title;
        private int _price;
        private List<Parking> _parkings;
        private long _selectedParkingId;
        private String _infosCreateAnnouncement;

        private INavigationService _navigationService = null;

        public CreateAnnouncementViewModel(INavigationService navigationService)
        {
            loadParking();
            _navigationService = navigationService;
        }

        private async void loadParking()
        {
            ParkingDAO parkingDAO = new ParkingDAO();
            Parkings = new List<Parking>(await parkingDAO.getMyParkings());
        }

        public String InfosCreateAnnouncement
        {
            get { return _infosCreateAnnouncement; }
            set
            {
                _infosCreateAnnouncement = value;
                RaisePropertyChanged("InfosCreateAnnouncement");
            }
        }

        public String Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                RaisePropertyChanged("Price");
            }
        }


        public List<Parking> Parkings
        {
            get { return _parkings; }
            set
            {
                _parkings = value;
                RaisePropertyChanged("Parkings");
            }
        }

        public long SelectedParkingId
        {
            get { return _selectedParkingId; }
            set
            {
                _selectedParkingId = value;
                RaisePropertyChanged("SelectedParkingId");
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
            _navigationService.NavigateTo("MyAnnouncements");
        }

        //Create
        private ICommand _createCommand;
        public ICommand CreateCommand
        {
            get
            {
                if (_createCommand == null)
                    _createCommand = new RelayCommand(() => Create());
                return _createCommand;
            }
        }

        private async void Create()
        {
            UserConnected userConnected = new UserConnected();
            userConnected = userConnected.getINSTANCE();
            AnnouncementDAO announcementDAO = new AnnouncementDAO();
            Announcement announcement = new Announcement(Title, Price, DateTime.Now, DateTime.Now, false, SelectedParkingId);

            try
            {
                InfosCreateAnnouncement = await announcementDAO.PostAnnouncement(announcement);
                _navigationService.NavigateTo("MyAnnouncements");
            }
            catch(TitleException ex)
            {
                InfosCreateAnnouncement = ex.Message;
            }
            catch (PriceException ex)
            {
                InfosCreateAnnouncement = ex.Message;
            }
            catch (ParkingException ex)
            {
                InfosCreateAnnouncement = ex.Message;
            }


        }

    }
}
