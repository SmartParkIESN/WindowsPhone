using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Exceptions
{
    class PriceException : Exception
    {
        public PriceException()
		: base("Price must be between 2 and 100 eu")
	    {
        }
    }
}
