using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Exceptions
{
    class ParkingException : Exception
    {
        public ParkingException()
		: base("You have to choose one of yours parkings !")
	    {
        }
    }
}
