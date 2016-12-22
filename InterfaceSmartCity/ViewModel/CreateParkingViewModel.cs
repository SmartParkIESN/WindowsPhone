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
    class CreateParkingViewModel : ViewModelBase, INotifyPropertyChanged
    {



        private String _name;
        private String _street;
        private String _number;
        private List<Place> _places;
        private long _selectedPlaceId;
        private String _description;
        private String _infosCreateParking;

        private INavigationService _navigationService = null;

        public CreateParkingViewModel(INavigationService navigationService)
        {
            loadPlace();
            _navigationService = navigationService;
        }

        private async void loadPlace()
        {
            PlaceDAO placeDAO = new PlaceDAO();
            Places = new List<Place>(await placeDAO.getAllPlaces());
        }

        public String InfosCreateParking
        {
            get { return _infosCreateParking; }
            set
            {
                _infosCreateParking = value;
                RaisePropertyChanged("InfosCreateParking");
            }
        }

        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        public String Street
        {
            get { return _street; }
            set
            {
                _street = value;
                RaisePropertyChanged("Street");
            }
        }

        public String Number
        {
            get { return _number; }
            set
            {
                _number = value;
                RaisePropertyChanged("Number");
            }
        }

        public List<Place> Places
        {
            get { return _places; }
            set
            {
                _places = value;
                RaisePropertyChanged("Places");
            }
        }

        public long SelectedPlaceId
        {
            get { return _selectedPlaceId; }
            set
            {
                _selectedPlaceId = value;
                RaisePropertyChanged("SelectedPlace");
            }
        }

        public String Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("Description");
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
            _navigationService.NavigateTo("MyParkings");
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

            ParkingDAO parkingDAO = new ParkingDAO();
            Parking parking = new Parking(Name, Street, Number, "1", Description, 48, 48, SelectedPlaceId, userConnected.getUserConnected().UserId);

            try
            {
                InfosCreateParking = await parkingDAO.PostParking(parking);
                _navigationService.NavigateTo("MyParkings");
            }
            catch(TitleException ex)
            {
                InfosCreateParking = ex.Message;
            }
            catch(StreetException ex)
            {
                InfosCreateParking = ex.Message;
            }
            catch (NumberException ex)
            {
                InfosCreateParking = ex.Message;
            }
            catch (DescriptionException ex)
            {
                InfosCreateParking = ex.Message;
            }
            catch (PlaceException ex)
            {
                InfosCreateParking = ex.Message;
            }
            catch(Exception ex)
            {
                InfosCreateParking = "Connection error";
            }  

        }


    }
}
