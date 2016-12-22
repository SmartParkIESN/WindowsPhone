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
    class SignUpViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private String _pseudo;
        private String _mail;
        private String _password;
        private String _passwordConf;
        private String _phoneNumber;
        private String _infosSignUp;

        public String Pseudo
        {
            get { return _pseudo; }
            set
            {
                _pseudo = value;
                RaisePropertyChanged("Pseudo");
            }
        }

        public String Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                RaisePropertyChanged("Mail");
            }
        }

        public String Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }

        public String PasswordConf
        {
            get { return _passwordConf; }
            set
            {
                _passwordConf = value;
                RaisePropertyChanged("PasswordConf");
            }
        }

        public String PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                RaisePropertyChanged("PhoneNumber");
            }
        }

        public String InfosSignUp
        {
            get { return _infosSignUp; }
            set
            {
                _infosSignUp = value;
                RaisePropertyChanged("InfosSignUp");
            }
        }    


        private INavigationService _navigationService = null;

        public SignUpViewModel(INavigationService navigationService)
        {
            //On ajoute un paramètre pour la navigation dans le constructeur
            _navigationService = navigationService;
        }

        //Go to Sign Up
        private ICommand _signUpCommand;
        public ICommand SignUpCommand
        {
            get
            {
                if (_signUpCommand == null)
                    _signUpCommand = new RelayCommand(() => SignUp());
                return _signUpCommand;
            }
        }

        private async void SignUp()
        {
            
              User user = new User(_pseudo, _mail, _password, _phoneNumber);
              UserDAO usersDAO = new UserDAO();
              try
              {
                InfosSignUp = await usersDAO.SignUp(user, _passwordConf);
              }
              catch (EmailException ex)
              {
                  InfosSignUp = ex.Message;
              }
              catch (PseudoException ex)
              {
                  InfosSignUp = ex.Message;
              }
              catch (PasswordException ex)
              {
                  InfosSignUp = ex.Message;
              }
              catch (PasswordVerifException ex)
              {
                  InfosSignUp = ex.Message;
              }
        }
        //

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
            _navigationService.NavigateTo("Login");
        }



    }
}
