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
    class ProfileViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private String _pseudo;
        private String _mail;
        private String _password;
        private String _passwordConf;
        private String _phoneNumber;
        private String _infosEdit;

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

        public String InfosEdit
        {
            get { return _infosEdit; }
            set
            {
                _infosEdit = value;
                RaisePropertyChanged("InfosEdit");
            }
        }


        private INavigationService _navigationService = null;

        public ProfileViewModel(INavigationService navigationService)
        {

            UserConnected userConnected = new UserConnected();
            userConnected = userConnected.getINSTANCE();

            Pseudo = userConnected.getUserConnected().Pseudo;
            Mail = userConnected.getUserConnected().Email;
            PhoneNumber = userConnected.getUserConnected().PhoneNumber;

            //On ajoute un paramètre pour la navigation dans le constructeur
            _navigationService = navigationService;
        }

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
            _navigationService.NavigateTo("Welcome");
        }

        //Editk
        private ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {               
                if (_editCommand == null)
                    _editCommand = new RelayCommand(() => Edit());
                return _editCommand;
            }
        }

        private async void Edit()
        {
            UserConnected userConnected = new UserConnected();
            userConnected = userConnected.getINSTANCE();

            User user = userConnected.getUserConnected();

            user.Email = Mail;
            user.PhoneNumber = PhoneNumber;
            user.Password = Password;

            UserDAO userDAO = new UserDAO();

            try
            {
                InfosEdit = await userDAO.ModifyUser(user, _passwordConf);              
            }
            catch(EmailException ex)
            {
                InfosEdit = ex.Message;
            }
            catch (PasswordException ex)
            {
                InfosEdit = ex.Message;
            }
            catch (PasswordVerifException ex)
            {
                InfosEdit = ex.Message;
            }
            catch (Exception ex)
            {
                InfosEdit = "Connection error";
            }

        }

    }
}
