using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSmartCity.Exceptions
{
    class TitleException : Exception
    {
        public TitleException()
		: base("Title must be between 4 and 30 caract.")
	    {
        }
    }
}
