using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Exceptions
{
    class PlaceException : Exception
    {
        public PlaceException()
		: base("You have to choose a place !")
	    {
        }
    }
}
