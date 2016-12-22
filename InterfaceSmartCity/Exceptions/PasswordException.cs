using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Exceptions
{
    class PasswordException : Exception
    {
        public PasswordException()
		: base("Password must be between 4 and 20 caract.")
	    {
        }
    }
}
