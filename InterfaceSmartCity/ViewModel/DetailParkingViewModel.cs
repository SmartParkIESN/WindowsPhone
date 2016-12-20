using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using InterfaceSmartCity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.ViewModel
{
    class DetailParkingViewModel
    {
        public Announcement SelectedAnnouncement { get; set; }

        private INavigationService _navigationService;
        public DetailParkingViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Messenger.Default.Register<Announcement>(this, a => { SelectedAnnouncement = a; });

        }
    }
}
