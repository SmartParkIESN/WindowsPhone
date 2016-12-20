using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
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
                OnNotifyPropertyChanged("Pseudo");
            }
        }

        public String Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                OnNotifyPropertyChanged("Mail");
            }
        }

        public String Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnNotifyPropertyChanged("Password");
            }
        }

        public String PasswordConf
        {
            get { return _passwordConf; }
            set
            {
                _passwordConf = value;
                OnNotifyPropertyChanged("PasswordConf");
            }
        }

        public String PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                OnNotifyPropertyChanged("PhoneNumber");
            }
        }

        public String InfosSignUp
        {
            get { return _infosSignUp; }
            set
            {
                _infosSignUp = value;
                OnNotifyPropertyChanged("InfosSignUp");
            }
        }    

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private INavigationService _navigationService = null;

        public SignUpViewModel(INavigationService navigationService)
        {
            Password = "test";
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

        private async void  SignUp()
        {
            if(!_password.Equals(_passwordConf))
            {
                InfosSignUp = "Passwords doesn't match";
            }
            else
            {
                User user = new User(_pseudo, _mail, _password, _phoneNumber);
                UserDAO usersDAO = new UserDAO();
                InfosSignUp = await usersDAO.SignUp(user);
            } 
        }
        //



    }
}
