using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Exceptions
{
    class DescriptionException : Exception
    {
        public DescriptionException()
		: base("Description must be between 20 and 120 caract.")
	    {
        }
    }
}
