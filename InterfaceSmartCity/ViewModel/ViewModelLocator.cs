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
            SimpleIoc.Default.Register<DetailViewModel> ();
            SimpleIoc.Default.Register<LoginViewModel> ();
            SimpleIoc.Default.Register<MessageViewModel> ();
            SimpleIoc.Default.Register<ProfileViewModel> ();
            SimpleIoc.Default.Register<SearchViewModel> ();
            SimpleIoc.Default.Register<SignUpViewModel> ();
            SimpleIoc.Default.Register<WelcomeViewModel> ();
            SimpleIoc.Default.Register<MyAnnouncementsViewModel>();

            NavigationService navigationPages = new NavigationService ();
            SimpleIoc.Default.Register<INavigationService> (() => navigationPages);
            navigationPages.Configure ("CreateAnnouncement", typeof (CreateAnnouncement));
            navigationPages.Configure ("CreateParking", typeof (CreateParking));
            navigationPages.Configure ("DetailParking", typeof (DetailParking));
            navigationPages.Configure ("Login", typeof (Login));
            navigationPages.Configure ("Message", typeof (Message));
            navigationPages.Configure ("Profile", typeof (Profile));
            navigationPages.Configure ("SearchParking", typeof (SearchParking));
            navigationPages.Configure ("SignUp", typeof (SignUp));
            navigationPages.Configure ("Welcome", typeof (ListParking));
            navigationPages.Configure("MyAnnouncements", typeof(MyAnnouncements));
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

        public DetailViewModel DetailParking {
            get {
                return ServiceLocator.Current.GetInstance<DetailViewModel> ();
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

        public SearchViewModel SearchParking {
            get {
                return ServiceLocator.Current.GetInstance<SearchViewModel> ();
            }
        }

        public SignUpViewModel SignUp {
            get {
                return ServiceLocator.Current.GetInstance<SignUpViewModel> ();
            }
        }

        public WelcomeViewModel ListParking {
            get {
                return ServiceLocator.Current.GetInstance<WelcomeViewModel> ();
            }
        }

        public MyAnnouncementsViewModel MyAnnouncements
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MyAnnouncementsViewModel>();
            }
        }
    }
}
