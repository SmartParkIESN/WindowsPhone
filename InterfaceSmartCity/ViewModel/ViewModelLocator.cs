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
            SimpleIoc.Default.Register<ProfileViewModel> ();
            SimpleIoc.Default.Register<SearchViewModel> ();
            SimpleIoc.Default.Register<SignUpViewModel> ();
            SimpleIoc.Default.Register<WelcomeViewModel> ();
            SimpleIoc.Default.Register<MyAnnouncementsViewModel>();
            SimpleIoc.Default.Register<MyParkingsViewModel>();

            NavigationService navigationPages = new NavigationService ();
            SimpleIoc.Default.Register<INavigationService> (() => navigationPages);
            navigationPages.Configure ("CreateAnnouncement", typeof (CreateAnnouncement));
            navigationPages.Configure ("CreateParking", typeof (CreateParking));
            navigationPages.Configure ("DetailParking", typeof (DetailParking));
            navigationPages.Configure ("Login", typeof (Login));
            navigationPages.Configure ("Profile", typeof (Profile));
            navigationPages.Configure ("SearchParking", typeof (SearchParking));
            navigationPages.Configure ("SignUp", typeof (SignUp));
            navigationPages.Configure ("Welcome", typeof (ListParking));
            navigationPages.Configure("MyAnnouncements", typeof(MyAnnouncements));
            navigationPages.Configure("MyParkings", typeof(MyParkings));
        }

        public LoginViewModel Login {
            get {
                SimpleIoc.Default.Unregister<LoginViewModel>();
                SimpleIoc.Default.Register<LoginViewModel>();
                return ServiceLocator.Current.GetInstance<LoginViewModel> ();
            }
        }

        public CreateAnnouncementViewModel CreateAnnouncement {
            get {
                SimpleIoc.Default.Unregister<CreateAnnouncementViewModel>();
                SimpleIoc.Default.Register<CreateAnnouncementViewModel>();
                return ServiceLocator.Current.GetInstance<CreateAnnouncementViewModel> ();
            }
        }

        public CreateParkingViewModel CreateParking {
            get {
                SimpleIoc.Default.Unregister<CreateParkingViewModel>();
                SimpleIoc.Default.Register<CreateParkingViewModel>();
                return ServiceLocator.Current.GetInstance<CreateParkingViewModel> ();
            }
        }

        public DetailViewModel DetailParking {
            get {
                SimpleIoc.Default.Unregister<DetailViewModel>();
                SimpleIoc.Default.Register<DetailViewModel>();
                return ServiceLocator.Current.GetInstance<DetailViewModel> ();
            }
        }

        public ProfileViewModel Profile {
            get {
                SimpleIoc.Default.Unregister<ProfileViewModel>();
                SimpleIoc.Default.Register<ProfileViewModel>();
                return ServiceLocator.Current.GetInstance<ProfileViewModel> ();
            }
        }

        public SearchViewModel SearchParking {
            get {
                SimpleIoc.Default.Unregister<SearchViewModel>();
                SimpleIoc.Default.Register<SearchViewModel>();
                return ServiceLocator.Current.GetInstance<SearchViewModel> ();
            }
        }

        public SignUpViewModel SignUp {
            get {
                SimpleIoc.Default.Unregister<SignUpViewModel>();
                SimpleIoc.Default.Register<SignUpViewModel>();
                return ServiceLocator.Current.GetInstance<SignUpViewModel> ();
            }
        }

        public WelcomeViewModel ListParking {
            get {
                SimpleIoc.Default.Unregister<WelcomeViewModel>();
                SimpleIoc.Default.Register<WelcomeViewModel>();
                return ServiceLocator.Current.GetInstance<WelcomeViewModel> ();
            }
        }

        public MyAnnouncementsViewModel MyAnnouncements
        {
            get
            {
                SimpleIoc.Default.Unregister<MyAnnouncementsViewModel>();
                SimpleIoc.Default.Register<MyAnnouncementsViewModel>();
                return ServiceLocator.Current.GetInstance<MyAnnouncementsViewModel>();
            }
        }

        public MyParkingsViewModel MyParkings
        {
            get
            {
                SimpleIoc.Default.Unregister<MyParkingsViewModel>();
                SimpleIoc.Default.Register<MyParkingsViewModel>();
                return ServiceLocator.Current.GetInstance<MyParkingsViewModel>();
            }
        }
    }
}
