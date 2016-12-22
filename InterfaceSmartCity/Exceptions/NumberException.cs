using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Exceptions
{
    class NumberException : Exception
    {
        public NumberException()
		: base("Number must be between 1 and 8 caract.")
	    {
        }
    }
}
