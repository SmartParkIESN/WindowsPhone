using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Exceptions
{
    class PasswordVerifException : Exception
    {
        public PasswordVerifException()
		: base("Passwords don't match")
	    {
        }
    }
}
