using InterfaceSmartCity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Services
{
    class UserConnected
    {
        private User user { get; set; }
        private Boolean connected { get; set; }

        private static UserConnected INSTANCE = null;

        public UserConnected getINSTANCE()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new UserConnected();
            }
            return INSTANCE;
        }

        public UserConnected()
        {
            connected = false;
        }

        public User getUserConnected()
        {
            return user;
        }

        public Boolean getConnected()
        {
            return connected;
        }

        public void setConnected(Boolean co)
        {
            connected = co;
        }

        public void setUser(User u)
        {
            user = u;
        }
    }
}
