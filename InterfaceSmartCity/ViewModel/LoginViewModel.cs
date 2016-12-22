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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Xml.Linq;
using InterfaceSmartCity.Services;
using InterfaceSmartCity.Exceptions;

namespace InterfaceSmartCity.ViewModel {
    public class LoginViewModel : ViewModelBase, INotifyPropertyChanged {

        private String _nameUser;
        private String _passwordUser;
        private String _InfoConnection;

        public String NameUser {
            get { return _nameUser; }
            set
            {
                _nameUser = value;
                RaisePropertyChanged("NameUser");
            }
        }

        public String PasswordUser {
            get { return _passwordUser; }
            set
            {
                _passwordUser = value;
                RaisePropertyChanged("PasswordUser");
            }
        }

        public String InfoConnection
        {
            get { return _InfoConnection; }
            set
            {
                _InfoConnection = value;
                RaisePropertyChanged("InfoConnection");
            }
        }

        private INavigationService _navigationService = null;

        public LoginViewModel (INavigationService navigationService) {

            //On ajoute un paramètre pour la navigation dans le constructeur
            _navigationService = navigationService;
        }


        //Go to Sign Up
        private ICommand _goToSignUpCommand;
        public ICommand GoToSignUpCommand
        {
            get
            {
                if (_goToSignUpCommand == null)
                    _goToSignUpCommand = new RelayCommand(() => GoToSignUp());
                return _goToSignUpCommand;
            }
        }

        private void GoToSignUp()
        {
            _navigationService.NavigateTo("SignUp");
        }
        //

        //Log In
        private ICommand _logInCommand;
        public ICommand LogInCommand
        {
            get
            {
                if (_logInCommand == null)
                    _logInCommand = new RelayCommand(() => LogIn());
                return _logInCommand;
            }
        }

        private async void LogIn()
        {
            UserDAO userDAO = new UserDAO();

            try
            {
                InfoConnection = await userDAO.logIn(NameUser, PasswordUser);            
               _navigationService.NavigateTo("Welcome");
            }
            catch (PseudoException ex)
            {
                InfoConnection = ex.Message;
            }
            catch (PasswordException ex)
            {
                InfoConnection = ex.Message;
            }
            catch (LoginException ex)
            {
                InfoConnection = ex.Message;
            }
            catch (Exception ex)
            {
                InfoConnection = "Connection error";
            }
            
        }


    }
}
