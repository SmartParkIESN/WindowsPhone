using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using InterfaceSmartCity.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace InterfaceSmartCity.ViewModel {
    public class ListParkingViewModel : ViewModelBase, INotifyPropertyChanged{

        private ObservableCollection<Announcement>_announcement;
        public ObservableCollection<Announcement> Announcements {
            get { return _announcement; }
            set {
                _announcement = value;
                RaisePropertyChanged ("Announcements");
            }
        }

        private INavigationService _navigationService = null;

        public ListParkingViewModel (INavigationService navigationService) {
            Announcements = new ObservableCollection<Announcement> (AllAnnouncements.GetAllAnnouncements ());
            _navigationService = navigationService;
        }


        private Announcement _selectedAnnouncement;
        public Announcement SelectedAnnouncement {
            get { return _selectedAnnouncement; }
            set {
                _selectedAnnouncement = value;

                if(_selectedAnnouncement != null) {
                    RaisePropertyChanged ("SelectedAnnouncement");
                }
            }
        }

        private ICommand _detailParkingCommand;
        public ICommand DetailParkingCommand {
            get {
                if(this._detailParkingCommand == null) {
                    this._detailParkingCommand = new RelayCommand (() => DetailParking());
                }

                return this._detailParkingCommand;
            }
        }

        private void DetailParking () {
            if (CanExecute ()){
                _navigationService.NavigateTo ("DetailParking", SelectedAnnouncement);
            }
        }

        private bool CanExecute () {
            return (SelectedAnnouncement != null);
        }

        public void OnNaviguateTo(NavigationEventArgs e) {
            SelectedAnnouncement = (Announcement)e.Parameter;
        }
    }
}
