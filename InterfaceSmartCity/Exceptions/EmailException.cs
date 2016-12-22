using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Exceptions
{
    class EmailException : Exception
    {
        public EmailException()
		: base("Email is not correct !")
	    {
        }
    }
}
