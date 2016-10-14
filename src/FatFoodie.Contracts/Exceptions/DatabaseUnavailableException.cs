using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatFoodie.Contracts.Exceptions
{
    public class DatabaseUnavailableException : Exception
    {
        public DatabaseUnavailableException(string message) : base(message)
        {
        }
    }
}
