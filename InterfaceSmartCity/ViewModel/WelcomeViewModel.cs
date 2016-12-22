using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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
using Windows.UI.Xaml.Navigation;

namespace InterfaceSmartCity.ViewModel {
    public class WelcomeViewModel : ViewModelBase, INotifyPropertyChanged{

        private ObservableCollection<Announcement>_announcement;
        public ObservableCollection<Announcement> Announcements {
            get { return _announcement; }
            set {
                _announcement = value;
                RaisePropertyChanged ("Announcements");
            }
        }

        private INavigationService _navigationService = null;

        public WelcomeViewModel (INavigationService navigationService) {
            loadAnnouncement();
            _navigationService = navigationService;
        }

        private async void loadAnnouncement()
        {
            AnnouncementDAO announcementDAO = new AnnouncementDAO();
            Announcements = new ObservableCollection<Announcement>(await announcementDAO.getAllAnnouncements());
        }


        private Announcement _selectedAnnouncement;
        public Announcement SelectedAnnouncement {
            get { return _selectedAnnouncement; }
            set {
                _selectedAnnouncement = value;

                if(_selectedAnnouncement != null) {
                    RaisePropertyChanged ("SelectedAnnouncement");
                }
                DetailParking();
            }
        }      

        private void DetailParking()
        {
            if (CanExecute())
            {
                _navigationService.NavigateTo("DetailParking");
                Messenger.Default.Send(SelectedAnnouncement);
            }
        }

        //search
        private ICommand _goSearchCommand;
        public ICommand GoSearchCommand
        {
            get
            {
                if (_goSearchCommand == null)
                    _goSearchCommand = new RelayCommand(() => GoSearch());
                return _goSearchCommand;
            }
        }

        private void GoSearch()
        {
            _navigationService.NavigateTo("SearchParking");
        }

        //My announcements
        private ICommand _goMyAnnouncementsCommand;
        public ICommand GoMyAnnouncementsCommand
        {
            get
            {
                if (_goMyAnnouncementsCommand == null)
                    _goMyAnnouncementsCommand = new RelayCommand(() => GoMyAnnouncements());
                return _goMyAnnouncementsCommand;
            }
        }

        private void GoMyAnnouncements()
        {
            _navigationService.NavigateTo("MyAnnouncements");
        }

        //My parkings
        private ICommand _goMyParkingsCommand;
        public ICommand GoMyParkingsCommand
        {
            get
            {
                if (_goMyParkingsCommand == null)
                    _goMyParkingsCommand = new RelayCommand(() => GoMyParkings());
                return _goMyParkingsCommand;
            }
        }

        private void GoMyParkings()
        {
            _navigationService.NavigateTo("MyParkings");
        }

        //Profil
        private ICommand _goMyProfilCommand;
        public ICommand GoMyProfilCommand
        {
            get
            {
                if (_goMyProfilCommand == null)
                    _goMyProfilCommand = new RelayCommand(() => GoMyprofil());
                return _goMyProfilCommand;
            }
        }

        private void GoMyprofil()
        {
            _navigationService.NavigateTo("Profile");
        }

        //Log Out
        private ICommand _goLogoutCommand;
        public ICommand GoLogoutCommand
        {
            get
            {
                if (_goLogoutCommand == null)
                    _goLogoutCommand = new RelayCommand(() => GoLogout());
                return _goLogoutCommand;
            }
        }

        private void GoLogout()
        {
            UserConnected userConnected = new UserConnected();
            userConnected = userConnected.getINSTANCE();
            userConnected.setConnected(false);
            userConnected.setUser(null);
            _navigationService.NavigateTo("Login");
        }

        //Refresh
        private ICommand _refreshCommand;
        public ICommand RefreshCommand
        {
            get
            {
                if (_refreshCommand == null)
                    _refreshCommand = new RelayCommand(() => loadAnnouncement());
                return _refreshCommand;
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
