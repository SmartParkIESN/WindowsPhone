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
    class MyAnnouncementsViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private INavigationService _navigationService = null;

        public MyAnnouncementsViewModel(INavigationService navigationService)
        {
            loadAnnouncement();
            _navigationService = navigationService;
        }

        private ObservableCollection<Announcement> _announcement;
        public ObservableCollection<Announcement> Announcements
        {
            get { return _announcement; }
            set
            {
                _announcement = value;
                RaisePropertyChanged("Announcements");
            }
        }

        private Announcement _selectedAnnouncement;
        public Announcement SelectedAnnouncement {
            get { return _selectedAnnouncement; }
            set {
                _selectedAnnouncement = value;

                if(_selectedAnnouncement != null) {
                    RaisePropertyChanged("SelectedAnnouncement");
                }
            }
        }


        private async void loadAnnouncement()
        {
            AnnouncementDAO announcementDAO = new AnnouncementDAO();
            Announcements = new ObservableCollection<Announcement>(await announcementDAO.getMyAnnouncements());
        }

        //Back
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

        //Add
        private ICommand _addCommand;
        public ICommand AddAnnouncementCommand
        {
            get
            {
                if (_addCommand == null)
                    _addCommand = new RelayCommand(() => AddAnnoucement());
                return _addCommand;
            }
        }

        private void AddAnnoucement()
        {
            _navigationService.NavigateTo("CreateAnnouncement");
        }

        //Remove
        private ICommand _removeCommand;
        public ICommand RemoveAnnouncementCommand
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
            if(SelectedAnnouncement != null)
            {
                AnnouncementDAO announcementDAO = new AnnouncementDAO();
                announcementDAO.removeAnnouncement(SelectedAnnouncement);
                loadAnnouncement();
            }         
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

    }
}
