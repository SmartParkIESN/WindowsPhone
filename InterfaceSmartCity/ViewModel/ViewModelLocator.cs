using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using InterfaceSmartCity.View;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.ViewModel {
    class ViewModelLocator {
        public ViewModelLocator () {
            ServiceLocator.SetLocatorProvider (() => SimpleIoc.Default);
            SimpleIoc.Default.Register<CreateAnnouncementViewModel> ();
            SimpleIoc.Default.Register<CreateParkingViewModel> ();
            SimpleIoc.Default.Register<DetailParkingViewModel> ();
            SimpleIoc.Default.Register<LoginViewModel> ();
            SimpleIoc.Default.Register<MessageViewModel> ();
            SimpleIoc.Default.Register<ProfileViewModel> ();
            SimpleIoc.Default.Register<SearchParkingViewModel> ();
            SimpleIoc.Default.Register<SignUpViewModel> ();
            SimpleIoc.Default.Register<ListParkingViewModel> ();

            NavigationService navigationPages = new NavigationService ();
            SimpleIoc.Default.Register<INavigationService> (() => navigationPages);
            navigationPages.Configure ("CreateAnnouncement", typeof (CreateAnnouncement));
            navigationPages.Configure ("CreateParking", typeof (CreateParking));
            navigationPages.Configure ("DetailParking", typeof (DetailParking));
            navigationPages.Configure ("LoginViewModel", typeof (LoginViewModel));
            navigationPages.Configure ("Message", typeof (Message));
            navigationPages.Configure ("ProfileViewModel", typeof (ProfileViewModel));
            navigationPages.Configure ("SearchParking", typeof (SearchParking));
            navigationPages.Configure ("SignUp", typeof (SignUp));
            navigationPages.Configure ("ListParking", typeof (ListParking));
        }

        public LoginViewModel Login {
            get {
                return ServiceLocator.Current.GetInstance<LoginViewModel> ();
            }
        }

        public CreateAnnouncementViewModel CreateAnnouncement {
            get {
                return ServiceLocator.Current.GetInstance<CreateAnnouncementViewModel> ();
            }
        }

        public CreateParkingViewModel CreateParking {
            get {
                return ServiceLocator.Current.GetInstance<CreateParkingViewModel> ();
            }
        }

        public DetailParkingViewModel DetailParking {
            get {
                return ServiceLocator.Current.GetInstance<DetailParkingViewModel> ();
            }
        }

        public MessageViewModel Message {
            get {
                return ServiceLocator.Current.GetInstance<MessageViewModel> ();
            }
        }

        public ProfileViewModel Profile {
            get {
                return ServiceLocator.Current.GetInstance<ProfileViewModel> ();
            }
        }

        public SearchParkingViewModel SearchParking {
            get {
                return ServiceLocator.Current.GetInstance<SearchParkingViewModel> ();
            }
        }

        public SignUpViewModel SignUp {
            get {
                return ServiceLocator.Current.GetInstance<SignUpViewModel> ();
            }
        }

        public ListParkingViewModel ListParking {
            get {
                return ServiceLocator.Current.GetInstance<ListParkingViewModel> ();
            }
        }
    }
}
