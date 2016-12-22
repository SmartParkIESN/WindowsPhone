using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Exceptions
{
    class StreetException : Exception
    {
        public StreetException()
		: base("Street must be between 4 and 40 caract.")
	    {
        }
    }
}
