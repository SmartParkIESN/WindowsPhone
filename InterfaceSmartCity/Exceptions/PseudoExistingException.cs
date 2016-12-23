using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Exceptions
{
    class PseudoExistingException : Exception
    {
        public PseudoExistingException()
		: base("This pseudo is already taken !")
	    {
        }
    }
}
