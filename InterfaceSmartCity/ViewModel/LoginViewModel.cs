using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using InterfaceSmartCity.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.ViewModel {
    public class LoginViewModel : ViewModelBase, INotifyPropertyChanged {
        private String _nameUser;
        private String _passwordUser;

        /*public String NameUser {
            get { return _nameUser; }
            set { OnNotifyPropertyChanged ("NameUser"); }
        }

        public String PasswordUser {
            get { return _passwordUser; }
            set { OnNotifyPropertyChanged ("PasswordUser"); }
        } */

        private ObservableCollection<User>_users;
        public ObservableCollection<User> Users {
            get { return _users; }
            set {
                _users = value;
                /*
                 * Dans la propriété, nous devons y signaler de faire attention aux changements.
                 * Celà se fait grâce à RaisePropertyChanged, 
                 * l'argument de cette méthode est le nom de la propriété.
                 */
                RaisePropertyChanged ("Students");
            }
        }

       /* public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged(string propertyName) {
            if(PropertyChanged != null) {
            PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
            }
        }*/

        private INavigationService _navigationService = null;

        public LoginViewModel (INavigationService navigationService) {
            Users = new ObservableCollection<User> (AllUsers.GetAllUsers ());

            //On ajoute un paramètre pour la navigation dans le constructeur
            _navigationService = navigationService;
        }
        
    }
}
